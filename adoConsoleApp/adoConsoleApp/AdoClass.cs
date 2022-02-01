using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace adoConsoleApp
{
    class AdoClass
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public AdoClass()
        {
            try
            {
                con = new SqlConnection("Data Source=localhost ; Initial Catalog=ShoppingDB ; Integrated Security=True");
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                Console.WriteLine("Connection Done");
                cmd.CommandText = "select * from Customer";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
                }
                con.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
