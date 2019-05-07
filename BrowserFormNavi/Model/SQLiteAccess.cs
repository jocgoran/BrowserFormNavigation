using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static BrowserFormNavi.Program;
using System.Data.SQLite;

namespace BrowserFormNavi.Model
{

    public class SQLiteAccess
    {
        private static SQLiteConnection sqLiteConnection;
        private static SQLiteCommand sqLiteCommand;
        private static SQLiteDataAdapter sqLiteDataAdapter;

        private readonly static Mutex mutex = new Mutex();

        //internal delegate void GetDBDataDelegate(object instance, string strMethodName, object[] arguments);

        public SQLiteAccess()
        {
            // Set the connection string to SQLite
            string connectionString = "Data Source=BrowserFormNavi.sqlite; Version = 3; New = True; Compress = True;";

            // create connection
            sqLiteConnection = new SQLiteConnection(connectionString);

            // create command
            sqLiteCommand = sqLiteConnection.CreateCommand();

            sqLiteDataAdapter = new SQLiteDataAdapter(sqLiteCommand)
            {
                InsertCommand = sqLiteCommand,
                UpdateCommand = sqLiteCommand
            };
        }

        public int CheckDBConnection()
        {
            sqLiteConnection.Open();
            MessageBox.Show("Connection Open !");

            return 0;
        }

        public int InsertDBData(string methodName, object[] parameters)
        {
            // Wait until it is safe to enter.
            mutex.WaitOne();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " has entered the protected area for Query: " + methodName);

            // reset instance var
            sqLiteDataAdapter.InsertCommand.Cancel();
            sqLiteDataAdapter.InsertCommand.Parameters.Clear();

            //openconnection
            sqLiteConnection.Open();

            // invoke correct method
            try
            {
                MethodInfo method = this.GetType().GetMethod(methodName);
                method.Invoke(this, new object[] { parameters });

                // execute the insert
                sqLiteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Extract some information from this exception, and then 
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.Message);
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.StackTrace);
            }

            sqLiteConnection.Close();

            // release mutual exclusion code
            mutex.ReleaseMutex();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " is leaving the protected area for Query: " + methodName);
            return 0;
        }

        public int UpdateDBData(string methodName, object[] parameters)
        {
            // Wait until it is safe to enter.
            mutex.WaitOne();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " has entered the protected area for Query: " + methodName);

            // reset instance var
            sqLiteDataAdapter.UpdateCommand.Cancel();
            sqLiteDataAdapter.UpdateCommand.Parameters.Clear();

            //openconnection
            sqLiteConnection.Open();

            try
            {
            // invoke correct method
            MethodInfo method = this.GetType().GetMethod(methodName);
            method.Invoke(this, new object[] { parameters });

                // execute the insert
                sqLiteDataAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Extract some information from this exception, and then 
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.Message);
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.StackTrace);
            }

            sqLiteConnection.Close();

            // release mutual exclusion code
            mutex.ReleaseMutex();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " is leaving the protected area for Query: " + methodName);
            return 0;
        }

        public int GetDBData(string methodName, object[] parameters, ref DataTable contextualDataTable)
        {
            // Wait until it is safe to enter.
            mutex.WaitOne();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " has entered the protected area for Query: " + methodName);

            sqLiteDataAdapter.SelectCommand.Cancel();
            sqLiteDataAdapter.SelectCommand.Parameters.Clear();
            //openconnection
            sqLiteConnection.Open();

            try
            { 
                // invoke correct method
                MethodInfo method = this.GetType().GetMethod(methodName);
                method.Invoke(this, new object[] { parameters });

                // fill values and close connection
                sqLiteDataAdapter.Fill(contextualDataTable);
            }
            catch (Exception ex)
            {
                // Extract some information from this exception, and then 
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.Message);
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.StackTrace);
            }

            sqLiteConnection.Close();

            // release mutual exclusion code
            mutex.ReleaseMutex();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " is leaving the protected area for Query: " + methodName);
            return 0;
        }

        public int InsertInputFormData(object[] parameters)
        {
            sqLiteDataAdapter.InsertCommand.CommandText = "INSERT INTO UIComponent (url, domain_id, tag, class, dataTestId, ariaPressed, dataInterestId, role, type, name, inputFieldID) " +
                                                        "SELECT @url, @domain_id, @tag, @class, @dataTestId, @ariaPressed, @dataInterestId, @role, @type, @name, @inputFieldID " +
                                                        "WHERE NOT EXISTS " +
                                                        "(SELECT * FROM UIComponent WHERE url=@url AND domain_id=@domain_id AND tag=@tag AND class=@class AND dataTestId=@dataTestId AND ariaPressed=@ariaPressed AND dataInterestId=@dataInterestId AND role=@role AND type=@type AND name=@name AND inputFieldID=@inputFieldID) ";

            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@url", parameters[0].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@domain_id", Convert.ToInt32(parameters[1]));
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@tag", parameters[2].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@class", parameters[3].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@dataTestId", parameters[4].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@ariaPressed", parameters[5].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@dataInterestId", parameters[6].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@role", parameters[7].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@type", parameters[8].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@name", parameters[9].ToString());
            sqLiteDataAdapter.InsertCommand.Parameters.AddWithValue("@inputFieldID", parameters[10].ToString());

            return 0;
        }


        public int UIComponentPrimaryKey(object[] parameters)
        {
            // select the exact match 
            sqLiteDataAdapter.SelectCommand.CommandText =   "Select UIComponent.id " +
                                                    "FROM UIComponent " +
                                                    "WHERE url=@url " +
                                                    "AND domain_id=@domain_id " +
                                                    "AND tag=@tag " +
                                                    "AND class=@class " +
                                                    "AND dataTestId=@dataTestId " +
                                                    "AND ariaPressed=@ariaPressed " +
                                                    "AND dataInterestId=@dataInterestId " +
                                                    "AND role=@role " +
                                                    "AND type=@type " +
                                                    "AND name=@name " +
                                                    "AND inputFieldID=@inputFieldID ";

            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@url", parameters[0]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@domain_id", Convert.ToInt32(parameters[1]));
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@tag", parameters[2]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@class", parameters[3]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@dataTestId", parameters[4]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@ariaPressed", parameters[5]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@dataInterestId", parameters[6]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@role", parameters[7]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@type", parameters[8]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@name", parameters[9]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", parameters[10]);

            return 0;
        }

        public int ExactFormParamValue(object[] parameters)
        {
            // select the exact match 
            sqLiteDataAdapter.SelectCommand.CommandText =   "Select historicalParam.* " +
                                                    "FROM UIComponent INNER JOIN historicalParam ON UIComponent.id = UIComponent_id " +
                                                    "WHERE url=@url " +
                                                    "AND domain_id=@domain_id " +
                                                    "AND tag=@tag " +
                                                    "AND class=@class " +
                                                    "AND dataTestid=@dataTestid " +
                                                    "AND ariaPressed=@ariaPressed " +
                                                    "AND dataInterestId=@dataInterestId " +
                                                    "AND role=@role " +
                                                    "AND type=@type " +
                                                    "AND name=@name " +
                                                    "AND inputFieldID=@inputFieldID " +
                                                    "AND error = 0 " +
                                                    "ORDER BY COUNT DESC";

            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@url", parameters[0]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@domain_id", parameters[1]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@tag", parameters[2]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@class", parameters[3]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@dataTestid", parameters[4]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@ariaPressed", parameters[5]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@dataInterestId", parameters[6]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@role", parameters[7]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@type", parameters[8]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@name", parameters[9]);
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", parameters[10]);

            return 0;
        }

        public int HistoricDataOfAttributeName(object[] parameters)
        {
            // select the exact match 
            sqLiteDataAdapter.SelectCommand.CommandText = "Select historicalParam.* " +
                                                    "FROM UIComponent INNER JOIN historicalParam ON UIComponent.id = UIComponent_id " +
                                                    "WHERE dataInterestId=@dataInterestId " +
                                                    "AND error = 0 ";

            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@dataInterestId", parameters[0]);

            return 0;
        }

        //public int RetriveSimilarValue(object[] parameters)
        //{
        //    // select the exact match 
        //    SqlCommand cmd = new SqlCommand("Select * from login where url=@url " +
        //                                        "OR domain=@domain " +
        //                                        "OR password=@password" +
        //                                        "OR formPageSpecificID=@formPageSpecificID " +
        //                                        "OR tag=@tag" +
        //                                        "OR type=@type " +
        //                                        "OR name=@name" +
        //                                        "OR inputFieldID=@inputFieldID ", sqlConnection);
        //    return 0;
        //}

            public int SaveHistorcalInputParam(object[] parameters)
        {
            sqLiteDataAdapter.UpdateCommand.CommandText = "INSERT INTO historicalParam(UIComponent_id, value, checked, invoked) VALUES(@UIComponent_id, @value, @sChecked, @bInvoked) " +
                                                          "ON CONFLICT(UIComponent_id,value, checked, invoked) DO UPDATE SET " +
                                                          "count = count + 1 WHERE UIComponent_id = @UIComponent_id AND value = @value AND checked= @sChecked AND invoked = @bInvoked";
      
            sqLiteDataAdapter.UpdateCommand.Parameters.AddWithValue("@UIComponent_id", parameters[0]);
            sqLiteDataAdapter.UpdateCommand.Parameters.AddWithValue("@value", parameters[1]);
            sqLiteDataAdapter.UpdateCommand.Parameters.AddWithValue("@sChecked", parameters[2]);
            sqLiteDataAdapter.UpdateCommand.Parameters.AddWithValue("@bInvoked", Convert.ToInt32(parameters[3]));
            return 0;
        }

#pragma warning disable IDE0060 // Nicht verwendete Parameter entfernen
        public int DomainsWithDataMiningSettings(object[] parameters)
#pragma warning restore IDE0060 // Nicht verwendete Parameter entfernen
        {
            // select the eisting settings
            sqLiteDataAdapter.SelectCommand.CommandText = "Select distinct domain.* from domain INNER JOIN dataMiningSettings ON domain_id = domain.id";
            return 0;
        }

        public int DomainSettings(object[] parameters)
        {
            // select the eisting settings
            sqLiteDataAdapter.SelectCommand.CommandText = "Select * from dataMiningSettings INNER JOIN domain ON domain_id = domain.id where domain=@domain";
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@domain", parameters[0]);
            return 0;
        }

        public int Domain(object[] parameters)
        {
            // select the eisting settings
            sqLiteDataAdapter.SelectCommand.CommandText = "Select id from domain where domain=@domain";
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@domain", parameters[0]);
            return 0;
        }

#pragma warning disable IDE0060 // Nicht verwendete Parameter entfernen        
        public int RuleAppliance(object[] parameters)
#pragma warning restore IDE0060 // Nicht verwendete Parameter entfernen
        {
            // select the eisting settings
            sqLiteDataAdapter.SelectCommand.CommandText = "Select * from ruleAppliance";
            return 0;
        }

        public int RuleOfAppliance(object[] parameters)
        {
            // select the eisting settings
            sqLiteDataAdapter.SelectCommand.CommandText = "SELECT [rule].* " +
                                                    "FROM ruleAppliance " +
                                                    "INNER JOIN [rule] ON ruleAppliance.id = appliance_id " +
                                                    "WHERE appliance = @appliance";
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@appliance", parameters[0]);
            return 0;
        }

        public int ConditionOfRuleId(object[] parameters)
        {
            // select the eisting settings
            sqLiteDataAdapter.SelectCommand.CommandText = "SELECT condition.* " +
                                                    "FROM rule_to_condition " +
                                                    "INNER JOIN condition ON condition_id = condition.id " +
                                                    "WHERE rule_id = @ruleId";
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@ruleId", parameters[0]);
            return 0;
        }
        
        public int ActionOfRuleId(object[] parameters)
        {
            // select the eisting settings
            sqLiteDataAdapter.SelectCommand.CommandText =   "SELECT ruleAction.* " +
                                                    "FROM ruleAction " +
                                                    "INNER JOIN [rule] ON ruleAction_id = ruleAction.id " +
                                                    "WHERE [rule].id = @ruleId";
            sqLiteDataAdapter.SelectCommand.Parameters.AddWithValue("@ruleId", parameters[0]);
            return 0;
        }
    }
}
