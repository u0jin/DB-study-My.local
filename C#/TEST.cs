using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace TEST
{
    class TEST
    {
        static String constring1 = "Server=117.17.142.111;Database=cosmosDB;Uid=ujin;Pwd=1234;Charset=utf8";
        
        MySqlConnection conn = new MySqlConnection(constring1);
        
       // Form1 form1;


     //   MySqlDataAdapter adapter;


        public string sConnstring = "";

        //public DB(Form1 _frm1)
        //{
        //    form1 = _frm1;

        //}

        public void ConnectDB()
        {
            try
            {
                conn.Open();

                sConnstring = constring1;

                
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                conn.Close();
            }


            if (conn.State.ToString().Equals("Closed"))
            {
                conn.ConnectionString = sConnstring;
                conn.Open();
            }

        }

        public void CloseDB()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }


        public DataTable GetDBTable(string sql)
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            return dt;

        }

    }
}
