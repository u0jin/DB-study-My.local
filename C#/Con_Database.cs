using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace _DB연동_0327_
{
    class Con_Database
    {
        static String constring1 = "Server=117.17.142.111;Database=cosmosDB;Uid=ujin;Pwd=1234;Charset=utf8";

        MySqlConnection conn = new MySqlConnection(constring1); //데이터베이스와 연결을 담당하는 객체 생성

         Form1 frm1;


        MySqlDataAdapter adapter;


        public string sConnstring = "";

        public Con_Database(Form1 _frm1)
        {
            frm1 = _frm1;

        }

        public void ConnectDB()
        {
            //GridVeiw1에 보여줌

            try
            {
                conn.Open();

                string sql = "SELECT * FROM data ORDER BY id";
              
                adapter = new MySqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                
                adapter.Fill(ds,"data");
                frm1.dataGridView1.DataSource = ds.Tables[0];

                conn.Close();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                conn.Close();
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

       
        public void load_Research()
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM data where name LIKE '%"+frm1.Text+"%' ";

                adapter = new MySqlDataAdapter(sql, conn);
                DataSet ds4 = new DataSet();

                adapter.Fill(ds4, "data");
                frm1.dataGridView1.DataSource = ds4.Tables[0];
              //  DataView DV = new DataView(ds4.Tables[0]);


               // DV.RowFilter = string.Format(" id LIKE '%" + frm1.Text + "%' OR name LIKE '%" + frm1.Text + "%' OR phone_number LIKE '%" + frm1.Text + "%' OR e-maiil LIKE '%" + frm1.Text + "%' OR address LIKE '%" + frm1.Text + "%' ");


              // frm1.dataGridView1.DataSource = DV;
            //    frm1.dataGridView1.AutoSize = true;


               conn.Close();
            }

            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                conn.Close();
            }

            }
        }

    }
