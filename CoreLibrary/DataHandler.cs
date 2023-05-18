using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Data;

namespace CoreLibrary
{
    public class DataHandler
    {
        //Test Data
        private Dictionary<string, string> Params { get; set; }
        //OrderID List used for Load tests
        public List<string> OrderIdList { get; set; }
        private static volatile DataHandler instance;
        private static object syncRoot = new Object();
        private DataHandler()
        {
            OrderIdList = new List<string>();
            Params = new Dictionary<string, string>();
        }
        //Singleton instantiation
        public static DataHandler Instance
        {
            get
            {
                if (instance == null)
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DataHandler();
                    }
                return instance;
            }
        }
        /// <summary>
        /// InitializeParameter
        /// Initialize single parameter. Parameter is stored in the Params dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void InitializeParameter(string key, string value)
        {
            try
            {
                lock (syncRoot)
                {
                    if (!Params.ContainsKey(key))
                    {
                        Params.Add(key, value);
                        Console.WriteLine("Adding parameter \"{0}\" with value \"{1}\"", key, value);
                    }
                    else
                    {
                        Params[key] = value;
                        Console.WriteLine("Overwriting parameter \"{0}\" with value \"{1}\"", key, value);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();// UITestException("Parameter cannot be added or updated");
            }
        }
        /// <summary>
        /// remove a parameter from the datahandler dictionary if it exists
        /// </summary>
        /// <param name="key"></param>
        public void RemoveParameter(string key)
        {
            if (Params.ContainsKey(key))
                Params.Remove(key);
        }
        /// <summary>
        /// export parameters to file
        /// </summary>
        /// <param name="type">export file type (csv, xml). csv is selected by default</param>
        public void BulkExport(string type = "csv")
        {
            Func<string, string> surroundWithDoubleQuotes = t =>
            {
                return "\"" + t.Replace("\"", "\\\"") + "\"";
            };

            MergeDictionaries(Path.Combine(ConfigurationManager.AppSettings["ParametersPath"], "Parameters." + type));

            try
            {
                string parameters = string.Empty;
                string name = "Parameters";
                if (type == "xml")
                {
                    XDocument xDoc = XDocument.Parse("<Parameters></Parameters>");
                    foreach (KeyValuePair<string, string> param in Params)
                    {
                        xDoc.Root.Add(new XElement(param.Key.Replace(" ", "").Replace("/", "").Replace(".", "").Replace("#", ""), param.Value));
                    }
                    name += ".xml";
                    parameters = xDoc.ToString();
                }
                else
                {
                    parameters = String.Join(",", Params.Select(d => surroundWithDoubleQuotes(d.Key))) + Environment.NewLine + String.Join(",", Params.Select(d => surroundWithDoubleQuotes(d.Value)));
                    name += ".csv";
                }
                if (!string.IsNullOrEmpty(parameters))
                    File.WriteAllText(ConfigurationManager.AppSettings["ParametersPath"] + name, parameters);
            }
            catch (Exception)
            {
                throw new Exception();// UITestException("Parameters could not be exported");
            }
        }
        /// <summary>
        /// export only speficic parameters to file
        /// </summary>
        /// <param name="type">export file type (csv, xml). csv is selected by default</param>
        //public void LiteExport(string type = "csv")
        //{
        //    Func<string, string> surroundWithDoubleQuotes = t =>
        //    {
        //        return "\"" + t.Replace("\"", "\\\"") + "\"";
        //    };
        //    try
        //    {
        //        string parameters = string.Empty;
        //        string name = "Parameters";
        //        if (type == "xml")
        //        {
        //            XDocument xDoc = XDocument.Parse("<Parameters></Parameters>");
        //            xDoc.Root.Add(new XElement("URL", GetParam("URL")));
        //            xDoc.Root.Add(new XElement("Username", GetParam("Username")));
        //            xDoc.Root.Add(new XElement("Password", GetParam("Password")));
        //            xDoc.Root.Add(new XElement("OrderNo", GetParam("OrderNo", "")));
        //            name += ".xml";
        //            parameters = xDoc.ToString();
        //        }
        //        else
        //        {
        //            parameters = String.Join(",", Params.Select(d => surroundWithDoubleQuotes(d.Key))) + Environment.NewLine + String.Join(",", Params.Select(d => surroundWithDoubleQuotes(d.Value)));
        //            name += ".csv";
        //        }
        //        if (!string.IsNullOrEmpty(parameters))
        //            File.WriteAllText(ConfigurationManager.AppSettings["ParametersPath"] + name, parameters);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();//UITestException("Parameters could not be exported");
        //    }
        //}
        /// <summary>
        /// Merges old and new parameters into one dictionary
        /// </summary>
        /// <param name="filename">import file</param>
        public void MergeDictionaries(string filename)
        {
            Dictionary<string, string> newParams = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in DataHandler.Instance.Params)
            {
                newParams.Add(kvp.Key, kvp.Value);
            }
            ImportData(filename);
            foreach (KeyValuePair<string, string> kvp in newParams)
            {
                DataHandler.Instance.InitializeParameter(kvp.Key, kvp.Value);
            }
        }
        /// <summary>
        /// Import data from an external data source into the params dictionary
        /// </summary>
        /// <param name="filename">import file</param>
        public void ImportData(string filename)
        {
            //System.Diagnostics.Debugger.Break();
            string file = string.Empty;
            DirectoryInfo di = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
            file = Path.Combine(Path.GetDirectoryName(di.FullName), @"Data\" + filename);
            try
            {

                if (Path.GetExtension(file) == ".xml")
                {
                    XDocument xDoc = XDocument.Load(filename);
                    foreach (XElement xe in xDoc.Root.Descendants())
                    {
                        DataHandler.Instance.InitializeParameter(xe.Name.ToString(), xe.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());// UITestException("Cannot load data source document", ex);
            }
        }
        /// <summary>
        /// retrieve param
        /// </summary>
        /// <param name="key">param name</param>
        /// <returns>param value</returns>
        public string GetParam(string key)
        {
            Console.WriteLine(string.Format("Retrieving parameter \"{0}\" with value \"{1}\"", key, Params[key]));
            return Params[key];
        }
        /// <summary>
        /// If param key exists retrieve the value. If not return default value
        /// </summary>
        /// <param name="key">param name</param>
        /// <param name="defalutValue">returned if param does not exist</param>
        /// <returns></returns>
        public string GetParam(string key, string defalutValue)
        {
            if (Params.ContainsKey(key))
            {
                Console.WriteLine(string.Format("Retrieving parameter \"{0}\" with value \"{1}\"", key, Params[key]));
                return Params[key];
            }
            Console.WriteLine(string.Format("parameter \"{0}\" does not exist. Using default value \"{1}\"", key, defalutValue));
            return defalutValue;
        }
        public void ClearDictionary()
        {
            Params.Clear();
        }
        /// <summary>
        /// check if the dictionary contains any of the provided keys
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Any(params string[] keys)
        {
            return Params.Keys.Intersect(keys).Any();
        }
        /// <summary>
        /// Loop a void function which takes no parameters
        /// </summary>
        /// <param name="paramsFile">xml file with input params. file needs to have nodes: //Iterations/Iteration</param>
        /// <param name="Looper">function to loop</param>
        public void LoopVoidFunction(string paramsFile, Action Looper)
        {
            string sy = GetParam("ResultsDirectory");

            String fileName = Path.Combine(GetParam("ResultsDirectory"), "Data\\" + paramsFile);
            //  string fileName = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Data\\" + paramsFile).Replace (".xml\\",".xml");

            XDocument paramsDoc = XDocument.Load(fileName);
            foreach (XElement iteration in paramsDoc.XPathSelectElements("//Iterations/Iteration"))
            {
                foreach (XElement parameter in iteration.Descendants())
                {
                    InitializeParameter(parameter.Name.ToString(), parameter.Value.ToString());

                }
                Looper();
            }

        }

        //public void Read_Data_Excel(string FileName, string SheetName)
        //{
        //    String fileName = Path.Combine(GetParam("ResultsDirectory"), "Data\\" + FileName + ".xlsx");

        //    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //    using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {

        //            DataRowCollection row = reader.AsDataSet().Tables[SheetName].Rows;



        //            foreach (DataRow rs in row)
        //            {

        //                InitializeParameter(rs.ItemArray[0].ToString(), rs.ItemArray[1].ToString());
        //            }

        //        }
        //    }


        //}



        //public void Read_TableData_Excel(string FileName, string SheetName, Action Looper)
        //{
        //    String fileName = Path.Combine(GetParam("ResultsDirectory"), "Data\\" + FileName + ".xlsx");

        //    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //    using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {

        //            DataRowCollection row = reader.AsDataSet().Tables[SheetName].Rows;

        //            DataTable dtTable = reader.AsDataSet().Tables[SheetName];

        //            try
        //            {
        //                for (int i = 1; i < dtTable.Rows.Count; i++)
        //                {
        //                    DataRow drs = dtTable.Rows[i];
        //                    for (int j = 0; j < dtTable.Columns.Count; j++)
        //                    {
        //                        // string ss = dtTable.Rows[i][j].ToString();
        //                        InitializeParameter(dtTable.Rows[0][j].ToString(), dtTable.Rows[i][j].ToString());
        //                    }
        //                    Looper();
        //                }
        //            }
        //            catch (Exception ex)
        //            {

        //            }

        //        }
        //    }


        //} /* method */


        public void ReadConfigAppsettingData()
        {
            // string ss = Convert.ToString(ConfigurationManager.AppSettings["URL"]);
            DataHandler.Instance.InitializeParameter("URL", ConfigurationManager.AppSettings["URL"]);
            DataHandler.Instance.InitializeParameter("Environment", ConfigurationManager.AppSettings["Environment"]);

            DataHandler.Instance.InitializeParameter("Browser", ConfigurationManager.AppSettings["Browser"]);
            DataHandler.Instance.InitializeParameter("Username", ConfigurationManager.AppSettings["Username"]);

            DataHandler.Instance.InitializeParameter("Password", ConfigurationManager.AppSettings["Password"]);
            DataHandler.Instance.InitializeParameter("RUsername", ConfigurationManager.AppSettings["RUsername"]);

            DataHandler.Instance.InitializeParameter("RPassword", ConfigurationManager.AppSettings["RPassword"]);
            DataHandler.Instance.InitializeParameter("LoginUser", ConfigurationManager.AppSettings["LoginUser"]);
            DataHandler.Instance.InitializeParameter("LoginUser", ConfigurationManager.AppSettings["LoginUser"]);

            DataHandler.Instance.InitializeParameter("ReportCredentials", ConfigurationManager.AppSettings["ReportCredentials"]);

        }
    }

    public static class Helpers
    {

        public static bool ToBool(this string key)
        {
            bool convertedBool;
            if (Boolean.TryParse(key, out convertedBool))
                return convertedBool;
            else
                throw new Exception(string.Format("Could not cast {0} param", key));
        }
    }
}