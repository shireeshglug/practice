using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace adoConsoleApp
{
    class DisconnectedADO
    {
        DataSet ds = new DataSet();
        DataTable dataTable;
        SqlDataAdapter buildingAdapter;
        SqlCommandBuilder commandBuilder;
        SqlConnection con;
        public DisconnectedADO()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost; Initial Catalog = ShoppingDB; Integrated Security = True";
            buildingAdapter = new SqlDataAdapter("select * from building", con);

            commandBuilder = new SqlCommandBuilder(buildingAdapter);

            buildingAdapter.Fill(ds, "building");
            //retrive and fill data to the dataset object
            ds.Tables["building"].PrimaryKey = new DataColumn[] { ds.Tables["building"].Columns[0] };
            dataTable = ds.Tables["building"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString());//first column data
            }
        }

        public void AddBuilding()
        {
            DataRow dr = dataTable.NewRow();
            dr[0] = 3;
            dr[1] = "sumedha";
            dr[2] = 23044;
            dataTable.Rows.Add(dr);
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString());//first column data

            }
        }
        public void save()
        {
            buildingAdapter.Update(ds,"building");
        }

        public void Update()
        {
            DataRow dr = dataTable.Rows.Find(2);
            dr[1] = "keerthi";

        }

        public void Display()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString());
            }
        }

        public void Delete()
        {
            DataRow dr = dataTable.Rows.Find(2);
            dr.Delete();
        }
    }
}

