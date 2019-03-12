using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BrowserFormNavi.Model
{

    public class DBAccess
    {

        private static string connectionString;
        private SqlConnection sqlConnection;
        private DataTable dataTable = new DataTable();

        public DBAccess()
        {
            connectionString = @"Data Source=localhost;Initial Catalog=Browserformnavi;User ID=sa;Password=sa;";
            // Set the connection string with pooling option
            connectionString += "Connection Timeout = 30; Connection Lifetime = 0; Min Pool Size = 0; Max Pool Size = 100; Pooling = true; ";

            // create connection
            sqlConnection = new SqlConnection(connectionString);
        }

        public int CheckDBConnection()
        {
            sqlConnection.Open();
            MessageBox.Show("Connection Open  !");

            return 0;
        }

        //public int GetDBdata(string queryName, object[] parameters)
        //{
        //    dataTable.Clear();
        //    sqlConnection.Open();


        //    DBAdapter.Fill(dataTable);
        //    sqlConnection.Close();

        //    return 0;
        //}

        public int InsertInputFormData(string url, int domain_id, string tag, string classAttribute, string role, string type, string name, string inputFieldID)
        {

            string sql = "INSERT INTO UIComponent (url, domain_id, tag, class, role, type, name, inputFieldID) " +
                         "SELECT @url, @domain_id, @tag, @class, @role, @type, @name, @inputFieldID " +
                         "WHERE NOT EXISTS " +
                         "(SELECT * FROM UIComponent WHERE url=@url AND domain_id=@domain_id AND tag=@tag AND class=@class AND role=@role AND type=@type AND name=@name AND inputFieldID=@inputFieldID) ";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@url", url));
            sqlCommand.Parameters.Add(new SqlParameter("@domain_id", domain_id));
            sqlCommand.Parameters.Add(new SqlParameter("@tag", tag));
            sqlCommand.Parameters.Add(new SqlParameter("@class", classAttribute));
            sqlCommand.Parameters.Add(new SqlParameter("@role", role));
            sqlCommand.Parameters.Add(new SqlParameter("@type", type));
            sqlCommand.Parameters.Add(new SqlParameter("@name", name));
            sqlCommand.Parameters.Add(new SqlParameter("@inputFieldID", inputFieldID));

            sqlCommand.Connection = sqlConnection;
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message.ToString(), "Error Message");
                LogWriter.LogWrite(e.Message.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

            return 0;
        }


        public int LoadInputPrimaryKey(string url, int domain_id, string tag, string classAttribute, string role, string type, string name, string inputFieldID)
        {
            dataTable.Clear();
            sqlConnection.Open();

            // select the exact match 
            SqlDataAdapter DBAdapter = new SqlDataAdapter("Select UIComponent.id " +
                                                            "FROM UIComponent " +
                                                            "WHERE url=@url " +
                                                            "AND domain_id=@domain_id " +
                                                            "AND tag=@tag " +
                                                            "AND class=@class " +
                                                            "AND role=@role " +
                                                            "AND type=@type " +
                                                            "AND name=@name " +
                                                            "AND inputFieldID=@inputFieldID ", sqlConnection);

            DBAdapter.SelectCommand.Parameters.AddWithValue("@url", url);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain_id", domain_id);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@tag", tag);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@class", classAttribute);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@role", role);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", type);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", inputFieldID);

            DBAdapter.Fill(dataTable);
            sqlConnection.Close();

            return 0;
        }

        public int RetriveExactFormParamValue(string url, int domain_id, string tag, string classAttribute, string role, string type, string name, string inputFieldID)
        {
            dataTable.Clear();
            sqlConnection.Open();

            // select the exact match 
            SqlDataAdapter DBAdapter = new SqlDataAdapter("Select historicalParam.* " +
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
                                                            "ORDER BY COUNT DESC", sqlConnection);

            DBAdapter.SelectCommand.Parameters.AddWithValue("@url", url);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain_id", domain_id);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@tag", tag);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@class", classAttribute);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@role", role);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", type);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", inputFieldID);

            DBAdapter.Fill(dataTable);
            sqlConnection.Close();

            return 0;
        }

        public int RetriveSimilarValue(string domain)
        {

            sqlConnection.Open();
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
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message.ToString(), "Error Message");
                LogWriter.LogWrite(e.Message.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

            return 0;
        }

        public int LoadDomainsWithDataMiningSettings()
        {
            dataTable.Clear();
            sqlConnection.Open();

            // select the eisting settings
            SqlDataAdapter DBAdapter = new SqlDataAdapter("Select distinct domain.* from domain INNER JOIN dataMiningSettings ON domain_id = domain.id", sqlConnection);

            DBAdapter.Fill(dataTable);
            sqlConnection.Close();

            return 0;
        }

        public int LoadDomainSettings(string domain)
        {
            dataTable.Clear();
            sqlConnection.Open();

            // select the eisting settings
            SqlDataAdapter DBAdapter = new SqlDataAdapter("Select * from dataMiningSettings INNER JOIN domain ON domain_id = domain.id where domain=@domain ", sqlConnection);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain", domain);

            DBAdapter.Fill(dataTable);
            sqlConnection.Close();

            return 0;
        }

        public int LoadDomain(string domain)
        {
            dataTable.Clear();
            sqlConnection.Open();

            // select the eisting settings
            SqlDataAdapter DBAdapter = new SqlDataAdapter("Select id from domain where domain=@domain", sqlConnection);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain", domain);

            DBAdapter.Fill(dataTable);
            sqlConnection.Close();
            return 0;
        }

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

        public int ColToString(string colName1, ref string colValue1, string colName2, ref string colValue2)
        {
            if (dataTable.Rows.Count > 0)
            {
                // access directly only the first row 
                colValue1 = dataTable.Rows[0][colName1].ToString();
                colValue2 = dataTable.Rows[0][colName2].ToString();
            }

            return 0;
        }

    }
}
