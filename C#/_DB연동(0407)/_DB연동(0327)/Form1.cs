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
            
            string Mysql = "SELECT * FROM data where name LIKE '%" + textBox1.Text + "%' ";
            DataTable dt = db.GetDBTable(Mysql);
            dataGridView1.DataSource = dt;
            db.CloseDB();


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                 button1_Click(sender,e);
               // button1_Click(null, null); 왜 둘이 같은 동작을 하는걸까요???
            }
        }

        //특정 키 버튼 처리-키를 처음 누를때 처리되는것
      

    
    }
}
