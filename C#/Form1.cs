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

            //dataGridView1.Visible = true;
            //textBox1.Text = "";

            //textBox1.Enabled = true;
            



            string Mysql = "SELECT * FROM data where name LIKE '%" + textBox1.Text + "%' ";
            DataTable dt = db.GetDBTable(Mysql);
            dataGridView1.DataSource = dt;
            db.CloseDB();
            //MessageBox.Show("결과: "+textBox1.Text);


        }
        private void Search_keyDown(object sender, System.Windows.Forms.KeyEventArgs e)//검색창에 키를 입력하였을때
        {
            if (e.KeyCode == Keys.Enter) MessageBox.Show("키입력 확인");
                //button1_Click(null, null);//엔터 누르면 검색버튼 불러오기

        }
        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //        // button1_Click(sender,e);
        //        button1_Click(null, null);
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) MessageBox.Show("키입력 확인");
            //button1_Click(null, null);//엔터 누르면 검색버튼 불러오기

        }


        //특정 키 버튼 처리-키를 처음 누를때 처리되는것
      

    
    }
}
