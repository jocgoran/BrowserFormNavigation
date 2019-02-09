using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BrowserFormNavi.Model
{
    sealed class DBAccess
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

        public int checkDBConnection()
        {
            sqlConnection.Open();
            MessageBox.Show("Connection Open  !");

            return 0;
        }

        public int insertInputFormData(string url, string domain, string tag, string type, string name, string inputFieldID)
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

        public int retriveExactFormDataValue(string url, string domain, string tag, string type, string name, string inputFieldID, 
                                             ref string value, ref string sCheckbox)
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
                    sCheckbox = dataRow["checked"].ToString();
                }
            }
            sqlConnection.Close();

            return 0;
        }

        public int retriveSimilarValue(string domain)
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
    }


}
