using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExamDataBase
{
    public partial class MyQueryForm : Form
    {
        public MyQueryForm()
        {
            InitializeComponent();
        }

        private void MyQuery_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Storage.DataBase.getConnect();
            String cmdText = this.richTextBox1.Text;
            cmd.CommandText = cmdText;
            try
            {
                Storage.DataBase.OpenConnection();

                cmd.ExecuteNonQuery();

                Storage.DataBase.CloseConnection();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
