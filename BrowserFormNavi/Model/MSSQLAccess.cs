﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static BrowserFormNavi.Program;
using System.Configuration;

namespace BrowserFormNavi.Model
{

    public class MSSQLAccess
    {
        private static string connectionString;
        private static SqlConnection sqlConnection;
        private static SqlDataAdapter DBAdapter;
        private static SqlCommandBuilder builder;

        private static readonly Mutex mutex = new Mutex();

        //internal delegate void GetDBDataDelegate(object instance, string strMethodName, object[] arguments);

        public MSSQLAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BrowserFormNavigation"].ConnectionString; 
            // Set the connection string with pooling option
            connectionString += "Connection Timeout = 30; Connection Lifetime = 0; Min Pool Size = 0; Max Pool Size = 100; pooling = true; ";

            // create connection
            sqlConnection = new SqlConnection(connectionString);

            // create adapter
            DBAdapter = new SqlDataAdapter("", sqlConnection);
            builder = new SqlCommandBuilder(DBAdapter);
        }

        public int CheckDBConnection()
        {
            sqlConnection.Open();
            MessageBox.Show("Connection Open !");

            return 0;
        }

        public int InsertDBData(string methodName, object[] parameters)
        {
            // Wait until it is safe to enter.
            mutex.WaitOne();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " has entered the protected area for Query: " + methodName);

            // reset instance var
            builder.RefreshSchema();
            DBAdapter.InsertCommand = builder.GetInsertCommand();
            DBAdapter.InsertCommand.Cancel();
            DBAdapter.InsertCommand.Parameters.Clear();
            //openconnection
            sqlConnection.Open();

            // invoke correct method
            try
            {
                MethodInfo method = this.GetType().GetMethod(methodName);
                method.Invoke(this, new object[] { parameters });

                // execute the insert
                DBAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Extract some information from this exception, and then 
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.Message);
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.StackTrace);
            }

            sqlConnection.Close();

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
            builder.RefreshSchema();
            DBAdapter.UpdateCommand = builder.GetUpdateCommand();
            DBAdapter.UpdateCommand.Cancel();
            DBAdapter.UpdateCommand.Parameters.Clear();

            //openconnection
            sqlConnection.Open();

            try
            {
            // invoke correct method
            MethodInfo method = this.GetType().GetMethod(methodName);
            method.Invoke(this, new object[] { parameters });

            // execute the insert
            DBAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Extract some information from this exception, and then 
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.Message);
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.StackTrace);
            }

            sqlConnection.Close();

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

            builder.RefreshSchema();
            DBAdapter.SelectCommand.Cancel();
            DBAdapter.SelectCommand.Parameters.Clear();
            //openconnection
            sqlConnection.Open();

            try
            { 
                // invoke correct method
                MethodInfo method = this.GetType().GetMethod(methodName);
                method.Invoke(this, new object[] { parameters });

                // fill values and close connection
                DBAdapter.Fill(contextualDataTable);
            }
            catch (Exception ex)
            {
                // Extract some information from this exception, and then 
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.Message);
                LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.StackTrace);
            }

            sqlConnection.Close();

            // release mutual exclusion code
            mutex.ReleaseMutex();
            //LogWriter.LogWrite("Thread Nr: " + Thread.CurrentThread.ManagedThreadId + " is leaving the protected area for Query: " + methodName);
            return 0;
        }

        public int InsertInputFormData(object[] parameters)
        {
            DBAdapter.InsertCommand.CommandText = "INSERT INTO UIComponent (url, domain_id, tag, class, dataTestId, ariaPressed, dataInterestId, role, type, name, inputFieldID) " +
                                                "SELECT @url, @domain_id, @tag, @class, @dataTestId, @ariaPressed, @dataInterestId, @role, @type, @name, @inputFieldID " +
                                                "WHERE NOT EXISTS " +
                                                "(SELECT * FROM UIComponent WHERE url=@url AND domain_id=@domain_id AND tag=@tag AND class=@class AND dataTestId=@dataTestId AND ariaPressed=@ariaPressed AND dataInterestId=@dataInterestId AND role=@role AND type=@type AND name=@name AND inputFieldID=@inputFieldID) ";

            DBAdapter.InsertCommand.Parameters.AddWithValue("@url", parameters[0].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@domain_id", Convert.ToInt32(parameters[1]));
            DBAdapter.InsertCommand.Parameters.AddWithValue("@tag", parameters[2].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@class", parameters[3].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@dataTestId", parameters[4].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@ariaPressed", parameters[5].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@dataInterestId", parameters[6].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@role", parameters[7].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@type", parameters[8].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@name", parameters[9].ToString());
            DBAdapter.InsertCommand.Parameters.AddWithValue("@inputFieldID", parameters[10].ToString());

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
                                                    "AND dataInterestId=@dataInterestId " +
                                                    "AND role=@role " +
                                                    "AND type=@type " +
                                                    "AND name=@name " +
                                                    "AND inputFieldID=@inputFieldID ";

            DBAdapter.SelectCommand.Parameters.AddWithValue("@url", parameters[0]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain_id", Convert.ToInt32(parameters[1]));
            DBAdapter.SelectCommand.Parameters.AddWithValue("@tag", parameters[2]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@class", parameters[3]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@dataTestId", parameters[4]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@ariaPressed", parameters[5]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@dataInterestId", parameters[6]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@role", parameters[7]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", parameters[8]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", parameters[9]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", parameters[10]);

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
                                                    "AND dataTestid=@dataTestid " +
                                                    "AND ariaPressed=@ariaPressed " +
                                                    "AND dataInterestId=@dataInterestId " +
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
            DBAdapter.SelectCommand.Parameters.AddWithValue("@dataTestid", parameters[4]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@ariaPressed", parameters[5]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@dataInterestId", parameters[6]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@role", parameters[7]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", parameters[8]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", parameters[9]);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", parameters[10]);

            return 0;
        }

        public int HistoricDataOfAttributeName(object[] parameters)
        {
            // select the exact match 
            DBAdapter.SelectCommand.CommandText = "Select historicalParam.* " +
                                                    "FROM UIComponent INNER JOIN historicalParam ON UIComponent.id = UIComponent_id " +
                                                    "WHERE dataInterestId=@dataInterestId " +
                                                    "AND error = 0 ";

            DBAdapter.SelectCommand.Parameters.AddWithValue("@dataInterestId", parameters[0]);

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
            DBAdapter.UpdateCommand.CommandText = "UPDATE historicalParam SET count = count+1 WHERE UIComponent_id=@UIComponent_id AND value=@value AND checked=@sChecked AND invoked=@bInvoked " +
                                                     "IF @@ROWCOUNT = 0 " +
                                                     "INSERT INTO historicalParam(UIComponent_id, value, checked, invoked) VALUES(@UIComponent_id, @value, @sChecked, @bInvoked)";

            DBAdapter.UpdateCommand.Parameters.AddWithValue("@UIComponent_id", parameters[0]);
            DBAdapter.UpdateCommand.Parameters.AddWithValue("@value", parameters[1]);
            DBAdapter.UpdateCommand.Parameters.AddWithValue("@sChecked", parameters[2]);
            DBAdapter.UpdateCommand.Parameters.AddWithValue("@bInvoked", Convert.ToInt32(parameters[3]));
            return 0;
        }

#pragma warning disable IDE0060 // Nicht verwendete Parameter entfernen
        public int DomainsWithDataMiningSettings(object[] parameters)
#pragma warning restore IDE0060 // Nicht verwendete Parameter entfernen
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

#pragma warning disable IDE0060 // Nicht verwendete Parameter entfernen       
        public int RuleAppliance(object[] parameters)
#pragma warning restore IDE0060 // Nicht verwendete Parameter entfernen
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

    }
}
