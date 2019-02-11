using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BrowserFormNavi.Model
{
    public class DBAccess
    {

        public string connectionString;
        public SqlConnection sqlConnection;

        public DBAccess()
        {
            connectionString = @"Data Source=localhost;Initial Catalog=Browserformnavi;User ID=sa;Password=SsvpZsvd1357;";
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

        public int InsertInputFormData(string url, string domain, string tag, string type, string name, string inputFieldID)
        {

            string sql = "INSERT INTO form (url, domain, tag, type, name, inputFieldID) " +
                         "SELECT @url, @domain, @tag, @type, @name, @inputFieldID " +
                         "WHERE NOT EXISTS " +
                         "(SELECT * FROM form WHERE url=@url AND domain=@domain AND tag=@tag AND type=@type AND name=@name AND inputFieldID=@inputFieldID) ";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@url", url));
            sqlCommand.Parameters.Add(new SqlParameter("@domain", domain));
            sqlCommand.Parameters.Add(new SqlParameter("@tag", tag));
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
            }

            return 0;
        }

        public int GetInputPrimaryKey(string url, string domain, string tag, string type, string name, string inputFieldID, ref int FormPK)
        {
            sqlConnection.Open();
            DataTable tFormPk = new DataTable();

            // select the exact match 
            SqlDataAdapter DBAdapter = new SqlDataAdapter("Select id " +
                                                            "FROM form " +
                                                            "WHERE url=@url " +
                                                            "AND domain=@domain " +
                                                            "AND tag=@tag " +
                                                            "AND type=@type " +
                                                            "AND name=@name " +
                                                            "AND inputFieldID=@inputFieldID ", sqlConnection);

            DBAdapter.SelectCommand.Parameters.AddWithValue("@url", url);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain", domain);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@tag", tag);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", type);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", inputFieldID);

            DBAdapter.Fill(tFormPk);

            if (tFormPk.Rows.Count > 0)
            {
                foreach (DataRow dataRow in tFormPk.Rows)
                {
                    FormPK = Convert.ToInt32(dataRow["id"]);
                }
            }
            sqlConnection.Close();

            return 0;
        }

        public int RetriveExactFormParamValue(string url, string domain, string tag, string type, string name, string inputFieldID,
                                             ref string value, ref string sChecked)
        {

            sqlConnection.Open();
            DataTable exactMatchHistParam = new DataTable();

            // select the exact match 
            SqlDataAdapter DBAdapter = new SqlDataAdapter("Select historicalParam.* " +
                                                            "FROM form INNER JOIN historicalParam ON form.id = form_id " +
                                                            "WHERE url=@url " +
                                                            "AND domain=@domain " +
                                                            "AND tag=@tag " +
                                                            "AND type=@type " +
                                                            "AND name=@name " +
                                                            "AND inputFieldID=@inputFieldID " +
                                                            "AND error = 0", sqlConnection);

            DBAdapter.SelectCommand.Parameters.AddWithValue("@url", url);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@domain", domain);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@tag", tag);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@type", type);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
            DBAdapter.SelectCommand.Parameters.AddWithValue("@inputFieldID", inputFieldID);

            DBAdapter.Fill(exactMatchHistParam);

            if (exactMatchHistParam.Rows.Count > 0)
            {
                foreach (DataRow dataRow in exactMatchHistParam.Rows)
                {
                    value = dataRow["value"].ToString();
                    sChecked = dataRow["checked"].ToString();
                }
            }
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

        public int SaveHistorcalInputParam(int FormPK, string value, string sChecked)
        {
            string sql = "UPDATE historicalParam SET count = count+1 WHERE form_id=@FormPK AND value=@value AND checked=@sChecked " +
                         "IF @@ROWCOUNT = 0 " +
                         "INSERT INTO historicalParam(form_id, value, checked) VALUES(@FormPK, @value, @sChecked)";
                       
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@FormPK", FormPK));
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
            }

            return 0;
        }

    }
}
