using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DB연동_0327_
{
    public partial class Form1 : Form
    {
        Con_Database db;

        public Form1()
        {
            InitializeComponent();
            db = new Con_Database(this);

            db.ConnectDB();


        }

        private void button1_Click(object sender, EventArgs e)
        {

    
            string Mysql = "SELECT * FROM data WHERE Name= " + textBox1.Text + " ";
            DataTable dt = db.GetDBTable(Mysql);

            
           

            dataGridView1.DataSource = dt;
            db.CloseDB();



        }
        private void Search_keyDown(object sender, KeyEventArgs e)//검색창에 키를 입력하였을때
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);//엔터 누르면 검색버튼 불러오기

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
    }
}
