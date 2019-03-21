using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace BrowserFormNavi.Model
{

    public class DBAccess
    {
        public static string connectionString;
        public static SqlConnection sqlConnection;
        public static DataTable dataTable = new DataTable();
        public static SqlDataAdapter DBAdapter;

        //internal delegate void GetDBDataDelegate(object instance, string strMethodName, object[] arguments);

        public DBAccess()
        {
            connectionString = @"Data Source=localhost;Initial Catalog=Browserformnavi;User ID=sa;Password=sa;";
            // Set the connection string with pooling option
            connectionString += "Connection Timeout = 30; Connection Lifetime = 0; Min Pool Size = 0; Max Pool Size = 100; Pooling = true; ";

            // create connection
            sqlConnection = new SqlConnection(connectionString);

            // create adapter
            DBAdapter = new SqlDataAdapter("", sqlConnection);
        }

        public int CheckDBConnection()
        {
            sqlConnection.Open();
            MessageBox.Show("Connection Open !");

            return 0;
        }

        //public void GetDBData(dynamic instance, string methodName, object[] parameters)
        //{
        //    if (instance.InvokeRequired)
        //    {
        //        GetMethodDelegate gmd = new GetMethodDelegate(GetDBData);
        //        instance.Invoke(gmd, new object[] { instance, methodName, parameters });
        //    }
        //    else
        //    {
        //        // reset instance var
        //        dataTable.Clear();
        //        DBAdapter.SelectCommand.Cancel();
        //        DBAdapter.SelectCommand.Parameters.Clear();
        //        //openconnection
        //        sqlConnection.Open();

        //        // invoke correct method
        //        Type type = instance.GetType();
        //        MethodInfo methodInfo = type.GetMethod(methodName);
        //        methodInfo.Invoke(instance, parameters);

        //        // fill values and close connection
        //        DBAdapter.Fill(dataTable);
        //        sqlConnection.Close();
        //    }
        //}

        public int GetDBData(string methodName, object[] parameters)
        {
            // reset instance var
            dataTable.Clear();
            DBAdapter.SelectCommand.Cancel();
            DBAdapter.SelectCommand.Parameters.Clear();
            //openconnection
            sqlConnection.Open();

            // invoke correct method
            try
            {
                MethodInfo method = this.GetType().GetMethod(methodName);
                method.Invoke(this, new object[] { parameters });
            }
            catch (Exception ex)
            {
                // Extract some information from this exception, and then 
                if (ex.Source != null)
                    LogWriter.LogWrite("IOException source: " + ex.Source + ". Call Query:" + methodName);

                // throw it to the parent method.
                throw;
            }
            // fill values and close connection
            DBAdapter.Fill(dataTable);
            sqlConnection.Close();

            return 0;
        }

        public int InsertInputFormData(string url, int domain_id, string tag, string classAttribute, string dataTestId, string ariaPressed, string role, string type, string name, string inputFieldID)
        {

            string sql = "INSERT INTO UIComponent (url, domain_id, tag, class, dataTestId, ariaPressed, role, type, name, inputFieldID) " +
                         "SELECT @url, @domain_id, @tag, @class, @dataTestId, @ariaPressed, @role, @type, @name, @inputFieldID " +
                         "WHERE NOT EXISTS " +
                         "(SELECT * FROM UIComponent WHERE url=@url AND domain_id=@domain_id AND tag=@tag AND class=@class AND dataTestId=@dataTestId AND ariaPressed=@ariaPressed AND role=@role AND type=@type AND name=@name AND inputFieldID=@inputFieldID) ";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@url", url));
            sqlCommand.Parameters.Add(new SqlParameter("@domain_id", domain_id));
            sqlCommand.Parameters.Add(new SqlParameter("@tag", tag));
            sqlCommand.Parameters.Add(new SqlParameter("@class", classAttribute));
            sqlCommand.Parameters.Add(new SqlParameter("@dataTestId", dataTestId));
            sqlCommand.Parameters.Add(new SqlParameter("@ariaPressed", ariaPressed));
            sqlCommand.Parameters.Add(new SqlParameter("@role", role));
            sqlCommand.Parameters.Add(new SqlParameter("@type", type));
            sqlCommand.Parameters.Add(new SqlParameter("@name", name));
            sqlCommand.Parameters.Add(new SqlParameter("@inputFieldID", inputFieldID));

            sqlCommand.Connection = sqlConnection;

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


            return 0;
        }


        public int UIComponentPrimaryKey(object[] parameters)
        { 
            // select the exact match 
            DBAdapter.SelectCommand.CommandText =   "Select UIComponent.id " +
                                                    "FROM UIComponent " +
                                                    "WHERE url=@url " +
                                                    "AND domain_id=@domain_id " +
                                                    "AND tag=@tag " +
                                                    "AND class=@class " +
                                                    "AND dataTestId=@dataTestId " +
                                                    "AND ariaPressed=@ariaPressed " +
                                                    "AND role=@role " +
                                                    "AND type=@type " +
                                                    "AND name=@name " +
                                                    "AND inputFieldID=@inputFieldID ";

            DBAdapter.SelectCommand.Parameters.AddWithValue("@url", parameters[0]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain_id", parameters[1]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@tag", parameters[2]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@class", parameters[3]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@dataTestId", parameters[4]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@ariaPressed", parameters[5]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@role", parameters[6]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", parameters[7]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", parameters[8]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", parameters[9]);

            return 0;
        }

        public int ExactFormParamValue(object[] parameters)
        {
            // select the exact match 
            DBAdapter.SelectCommand.CommandText =   "Select historicalParam.* " +
                                                    "FROM UIComponent INNER JOIN historicalParam ON UIComponent.id = UIComponent_id " +
                                                    "WHERE url=@url " +
                                                    "AND domain_id=@domain_id " +
                                                    "AND tag=@tag " +
                                                    "AND class=@class " +
                                                    "AND role=@role " +
                                                    "AND type=@type " +
                                                    "AND name=@name " +
                                                    "AND inputFieldID=@inputFieldID " +
                                                    "AND error = 0 " +
                                                    "ORDER BY COUNT DESC";

            DBAdapter.SelectCommand.Parameters.AddWithValue("@url", parameters[0]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain_id", parameters[1]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@tag", parameters[2]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@class", parameters[3]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@role", parameters[4]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", parameters[5]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", parameters[6]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", parameters[7]);

            return 0;
        }

        public int RetriveSimilarValue(object[] parameters)
        {
            // select the exact match 
            SqlCommand cmd = new SqlCommand("Select * from login where url=@url " +
                                                "OR domain=@domain " +
                                                "OR password=@password" +
                                                "OR formPageSpecificID=@formPageSpecificID " +
                                                "OR tag=@tag" +
                                                "OR type=@type " +
                                                "OR name=@name" +
                                                "OR inputFieldID=@inputFieldID ", sqlConnection);
            return 0;
        }

        public int SaveHistorcalInputParam(int UIComponent_id, string value, string sChecked)
        {
            string sql = "UPDATE historicalParam SET count = count+1 WHERE UIComponent_id=@UIComponent_id AND value=@value AND checked=@sChecked " +
                         "IF @@ROWCOUNT = 0 " +
                         "INSERT INTO historicalParam(UIComponent_id, value, checked) VALUES(@UIComponent_id, @value, @sChecked)";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@UIComponent_id", UIComponent_id));
            sqlCommand.Parameters.Add(new SqlParameter("@value", value));
            sqlCommand.Parameters.Add(new SqlParameter("@sChecked", sChecked));

            sqlCommand.Connection = sqlConnection;

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return 0;
        }

        public int DomainsWithDataMiningSettings(object[] parameters)
        {
            // select the eisting settings
            DBAdapter.SelectCommand.CommandText = "Select distinct domain.* from domain INNER JOIN dataMiningSettings ON domain_id = domain.id";
            return 0;
        }

        public int DomainSettings(object[] parameters)
        {
            // select the eisting settings
            DBAdapter.SelectCommand.CommandText = "Select * from dataMiningSettings INNER JOIN domain ON domain_id = domain.id where domain=@domain";
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain", parameters[0]);
            return 0;
        }

        public int Domain(object[] parameters)
        {
            // select the eisting settings
            DBAdapter.SelectCommand.CommandText = "Select id from domain where domain=@domain";
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain", parameters[0]);
            return 0;
        }
        
        public int RuleAppliance(object[] parameters)
        {
            // select the eisting settings
            DBAdapter.SelectCommand.CommandText = "Select * from ruleAppliance";
            return 0;
        }

        public int RuleOfAppliance(object[] parameters)
        {
            // select the eisting settings
            DBAdapter.SelectCommand.CommandText = "SELECT [rule].* " +
                                                    "FROM ruleAppliance " +
                                                    "INNER JOIN [rule] ON ruleAppliance.id = appliance_id " +
                                                    "WHERE appliance = @appliance";
            DBAdapter.SelectCommand.Parameters.AddWithValue("@appliance", parameters[0]);
            return 0;
        }

        public int ConditionOfRuleId(object[] parameters)
        {
            // select the eisting settings
            DBAdapter.SelectCommand.CommandText = "SELECT condition.* " +
                                                    "FROM rule_to_condition " +
                                                    "INNER JOIN condition ON condition_id = condition.id " +
                                                    "WHERE rule_id = @ruleId";
            DBAdapter.SelectCommand.Parameters.AddWithValue("@ruleId", parameters[0]);
            return 0;
        }
        
        public int ActionOfRuleId(object[] parameters)
        {
            // select the eisting settings
            DBAdapter.SelectCommand.CommandText =   "SELECT ruleAction.* " +
                                                    "FROM ruleAction " +
                                                    "INNER JOIN [rule] ON ruleAction_id = ruleAction.id " +
                                                    "WHERE [rule].id = @ruleId";
            DBAdapter.SelectCommand.Parameters.AddWithValue("@ruleId", parameters[0]);
            return 0;
        }

        

        //
        // DBAdapter to data strucutres
        //

        public int ColToHashSet(string colName, ref HashSet<string> sHashSet)
        {
            for (int i = 0; i < dataTable.Rows.Count; ++i)
            {
                sHashSet.Add(dataTable.Rows[i][colName].ToString());
            }

            return 0;
        }

        public int ColToInt(string colName, ref int intValue)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    intValue = Convert.ToInt32(dataRow[colName]);
                }
            }

            return 0;
        }

        public int ColsToStringArray(string[] colNames, ref string[] colValues)
        {
            if (dataTable.Rows.Count > 0)
            {
                // access directly only the first row 
                for (int i = 0; i < colNames.Length; i++)
                {
                    colValues[i] = dataTable.Rows[0][colNames[i]].ToString();
                }
            }

            return 0;
        }

        public int TableToStringArray(string[] colNames, ref string[,] tableArray)
        {
            // resize array to contain all the rows
            tableArray = new string[dataTable.Rows.Count, colNames.Length];

            // loop over all the rows 
            for (int rowNr = 0; rowNr < dataTable.Rows.Count; rowNr++)
            {
                // access directly only the first row 
                for (int i = 0; i < colNames.Length; i++)
                {
                    tableArray[rowNr,i] += dataTable.Rows[rowNr][colNames[i]].ToString();
                }
            }

            return 0;
        }

    }
}
