using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace test
{
    class ADO
    {

        private string conect;
        public ADO()
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "lab17";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "Work15notwolf";
            conect = mysqlCSB.ConnectionString;
         
        }
        private string first_request = @"SELECT * FROM обои";
        private string second_request = @"SELECT * FROM партия";

        //datagrid
        public DataTable ForDataGrid()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = conect;
               // Открываем соединение с базой данных
                con.Open();

                MySqlCommand com = new MySqlCommand(first_request, con);

                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    ////есть записи?
                    if (dr.HasRows)
                    {
                        ////заполняем объект DataTable
                        dt.Load(dr);
                    }
                    return dt;
                }
            }
        }



        public List<String> mySqlCommand()
        {
            
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = conect;
                con.Open();

                List<String> result = new List<string>();

                MySqlCommand com = new MySqlCommand(second_request, con);

                /*
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader[0].ToString());
                }
            */


                using (MySqlDataReader reader = com.ExecuteReader())

                {
                    result.Add("|");
                    result.Add("id");
                    result.Add("id");
                    result.Add("Name");
                    result.Add("Data");
                    result.Add("|");

                    while (reader.Read())
                    {

                        result.Add("|");
                        result.Add(reader[0].ToString());
                        result.Add(reader[1].ToString());
                        result.Add(reader[2].ToString());
                        result.Add(reader[3].ToString());
                        result.Add("|");

                    }
                }

                return result;
            }
        }



    }
}
