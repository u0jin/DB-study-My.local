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
        //connector 객체 생성 -> MySqlConnection 클래스가 담당

        Form1 frm1;

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        // 조회를 할때 커넥션을 open하지않고 비연결 모드로 가져오기 가능->MySqlDataAdapter 클래스

        MySqlCommand comm = new MySqlCommand();

     //   MySqlDataReader sd = comm.ExecuteReader();


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
                conn.Open(); //데이터베이스에 연결

                string sql = "SELECT * FROM data ORDER BY id";

                adapter = new MySqlDataAdapter(sql, conn);

         //       adapter.SelectCommand= new MySqlCommand(sql, conn);
                

                //데이터를 수정 , 삭제, 저장 (리턴값을 받지 않음)하는 기능 등 모든 명령처리 -> MySqlCommand 클래스
                // connection 객체와 상관없이 생성하고 실행
                //데이터소스와 DataSet과의 통신을위해 DataAdapter 객체가 commmand 객체 사용

                MySqlDataReader sd = comm.ExecuteReader();

             //  String colum= sd["name"].ToString();


                DataSet ds = new DataSet();

              adapter.Fill(ds, "data");
                
              //  adapter.Fill(ds,"name");
                frm1.dataGridView1.DataSource = ds.Tables[0];

                conn.Close(); //데이터베이스 연결해제


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                conn.Close(); //데이터베이스 연결해제
            }

        }

        public void CloseDB()
        {
            if (conn != null)
            {
                conn.Close(); //데이터베이스 연결해제
            }
        }


        public DataTable GetDBTable(string sql)
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataTable dt = new DataTable();

            adapter.Fill(dt);  //mysqlDataAdapter 의 fill()함수 이용
            // dataset 객체에 조회한 데이터를 채움.
            return dt;

        }

       
        public void load_Research()
        {
            try
            {
                conn.Open(); //데이터베이스 연결
                string sql = "SELECT * FROM data ORDER BY id";

                adapter = new MySqlDataAdapter(sql, conn);
                DataSet ds4 = new DataSet();

                adapter.Fill(ds4, "data");

//                adapter.Fill(ds4, "name");
                
                //DataSet에 fill 할때 키값을 넣고 나중에 꺼내쓸거야
                

                DataView DV = new DataView(ds4.Tables[0]);


                DV.RowFilter = string.Format(" id LIKE '%" + frm1.Text + "%' OR name LIKE '%" + frm1.Text + "%' OR phone_number LIKE '%" + frm1.Text + "%' OR e-maiil LIKE '%" + frm1.Text + "%' OR address LIKE '%" + frm1.Text + "%' ");


                frm1.dataGridView1.DataSource = DV;
                frm1.dataGridView1.AutoSize = true;


               conn.Close(); //데이터베이스 연결해제
            }

            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                conn.Close(); //데이터베이스 연결해제
            }

            }
        }

    }
