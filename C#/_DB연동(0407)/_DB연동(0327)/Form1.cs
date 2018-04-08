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
       int index=1; //전역변수 (Column의 index 선택하는)
                    //Default 검색은 NAME
       object rc;
        public Form1()
        {
            InitializeComponent();
            db = new Con_Database(this);
         
            db.ConnectDB();
        }

        
        //index==0 -> ID순
        //index==1 -> NAME순
        //index==2 -> PhoneNumber순 
        //index==3 -> Address순
        //index==4 -> E-Mail순
        private void button_Click(object sender, EventArgs e)  
        {
            string Mysql="";

            if (index == 0)
            {
                Mysql = "SELECT * FROM data where id LIKE '%" + textBox1.Text + "%' ";
            }
            else if(index==1)
            {
                Mysql = "SELECT * FROM data where name LIKE '%" + textBox1.Text + "%' ";
            }
            else if (index == 2)
            {
                Mysql = "SELECT * FROM data where phone_number LIKE '%" + textBox1.Text + "%' ";
            }
            else if (index == 3)
            {
                Mysql = "SELECT * FROM data where e_mail LIKE '%" + textBox1.Text + "%' ";
            }
            else if (index == 4)
            {
                Mysql = "SELECT * FROM data where address LIKE '%" + textBox1.Text + "%' ";
            }

            DataTable dt = db.GetDBTable(Mysql);
            dataGridView1.DataSource = dt;
            db.CloseDB();


        }
     

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {        //특정 키 버튼 처리-키를 처음 누를때 처리되는것

            if (e.KeyChar == '\r')
            {
                button_Click(sender, e);    //이름 기준
               // button_Click(null, null); 왜 둘이 같은 동작을 하는걸까요???
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { //간지용
            button_Click(sender, e);        //이름 기준
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
              //  MessageBox(comboBox1.SelectedIndex.ToString());
              //  MessageBox.Show(comboBox1.SelectedIndex.ToString());// 인덱스 출력
                index = comboBox1.SelectedIndex;
                //this.itemSelected = comboDropDown.SelectedItem as string;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] data = { "ID", "Name", "Phone_number", "E-mail", "Address" };
            //comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = "Column";
            comboBox1.Items.AddRange(data); //배열
    
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{ //현재셀의 row index
        //    object rc = dataGridView1.CurrentCell.Value;  //for find the row index number
        //    MessageBox.Show("Current Row Index is = " + rc.ToString());
        //}

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { //행을 선택-> 그 id값을 불러옴
            rc = dataGridView1.CurrentCell.Value;  //for find the row index number
           // MessageBox.Show("Current Row Index is = " + rc.ToString());
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //db.deleteFunc() 호출
            try
            {
                db.deleteFunc(rc);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please click row header");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        { //수정->저장 & 추가-> 저장

            //추가 버튼
            try
            {
                db.addFunc();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Please click row header");
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //girdview에서 셀을 추가할때 발생
            //db.add(new object[] { "string", 1, true, null });
            dataGridView1.Rows.Add(1);
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Add(1);
            //컨트롤 바인딩을 해제시켜 줘야함
        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dataGridView1.Rows.Add(1);
        //}

     

    
    }
}
