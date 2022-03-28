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
    public partial class InsertForm : Form
    {    
        private List<Label> labelsList = new List<Label>();
        private List<TextBox> textBoxList = new List<TextBox>();
        private List<Column> columnList;
        private int countParametrs = 0;
        private String tableName;
        
        public InsertForm()
        {           
            InitializeComponent();           
            for(int i = 0; i < Storage.TableNamesList.Count(); i++)
                this.comboBox1.Items.Add(Storage.TableNamesList[i]);

        }

        private void  SendQueryAdapter(object sender, EventArgs e)
        {
            if (sendQuery())
            {
                Storage.MenuForm.Refresh();
                this.Close();
            }
        }

        private bool sendQuery()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Storage.DataBase.getConnect();
            StringBuilder cmdText = new StringBuilder();


            cmdText.Append("INSERT INTO [" + tableName + "] (  ");

            for (int i = 0; i < countParametrs; i++)
            {                 
                if (!columnList[i].AutoInc)
                    if (textBoxList[i].Text.Length > 1 || !(textBoxList[i].Text.Length < 1) & !(columnList[i].Default_value.ToString().Length > 0))
                        cmdText.Append("[" + columnList[i].ColumnName + "], ");
            }  

            cmdText.Remove(cmdText.Length - 2, 2);
            cmdText.Append(") ");


            cmdText.AppendLine(" VALUES(  ");

            for (int i = 0; i < countParametrs; i++)
            {
                if (!columnList[i].AutoInc)
                    if (textBoxList[i].Text.Length > 1 || !(textBoxList[i].Text.Length < 1) & !(columnList[i].Default_value.ToString().Length > 0))
                        if (columnList[i].Type.Equals("date") || columnList[i].Type.Equals("varchar"))
                            cmdText.AppendLine(" '" + textBoxList[i].Text.ToString()  + "',");
                        else
                            cmdText.AppendLine(" " + textBoxList[i].Text.ToString() + ",");
            }
            cmdText.Remove(cmdText.Length - 3, 3);
            cmdText.Append("); ");
            /*
            for (int i = 0; i < countParametrs; i++)
            {
                if(!columnList[i].AutoInc)
                    cmdText.AppendLine(" [@PARAMETR" + i.ToString() + "],");
            }
            cmdText.Remove(cmdText.Length - 3, 3);
            cmdText.Append("); ");
            cmd.CommandText = cmdText.ToString();

            
            for (int i = 0; i < countParametrs; i++)
            {
                if (!columnList[i].AutoInc)
                    cmd.Parameters.AddWithValue("@PARAMETR" + i.ToString(), textBoxList[i].Text);
            }                         
            */

            cmd.CommandText = cmdText.ToString();


            Console.WriteLine(cmdText.ToString());
            try
            {
                Storage.DataBase.OpenConnection();

                cmd.ExecuteNonQuery();

                Storage.DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        internal List<Column> InitColumnsAdapter()
        {
            columnList = Storage.InitColumns(tableName);

            return columnList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            tableName = comboBox1.Text;


            if (countParametrs != 0)
                Refresh();

            InitTables.tablesInfoToDataGrid(comboBox1.Text, this.dataGridView1);

            InitColumnsAdapter();


            foreach (DataGridViewColumn columnName in this.dataGridView1.Columns)
            {
                Label newLabel = new Label();
                TextBox newTextBox;

                                
                /*
                 * Label newLabel
                 */
                newLabel.AutoSize = true;
                newLabel.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point(12 + (100 * count), 40);
                newLabel.Name = "label" + count.ToString();
                newLabel.TabIndex = 1;
                newLabel.Size = new System.Drawing.Size(120, 60);
                newLabel.Text = columnName.HeaderText;


                switch (columnList[count].Type)
                {                  
                    case "int":
                        {
                            Label newLabel1 = new Label();

                            newLabel1.AutoSize = true;
                            newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 90);
                            newLabel1.Name = "labelType" + count.ToString();
                            newLabel1.Size = new System.Drawing.Size(130, 17);
                            newLabel1.TabIndex = 4;
                            newLabel1.Text = "Целочисленное";

                            this.Controls.Add(newLabel1);

                            labelsList.Add(newLabel1);
                            break;
                        }
                    case "varchar":
                        {
                            Label newLabel1 = new Label();

                            newLabel1.AutoSize = true;
                            newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 90);
                            newLabel1.Name = "labelType" + count.ToString();
                            newLabel1.Size = new System.Drawing.Size(130, 17);
                            newLabel1.TabIndex = 4;
                            newLabel1.Text = "Строка";

                            this.Controls.Add(newLabel1);

                            labelsList.Add(newLabel1);
                            break;
                        }
                    case "date":
                        {
                            Label newLabel1 = new Label();

                            newLabel1.AutoSize = true;
                            newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 90);
                            newLabel1.Name = "labelType" + count.ToString();
                            newLabel1.Size = new System.Drawing.Size(130, 17);
                            newLabel1.TabIndex = 4;
                            newLabel1.Text = "Дата ГГГГ/ММ/ДД";

                            this.Controls.Add(newLabel1);

                            labelsList.Add(newLabel1);
                            break;
                        }
                    case "float":
                        {
                            Label newLabel1 = new Label();

                            newLabel1.AutoSize = true;
                            newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 90);
                            newLabel1.Name = "labelType" + count.ToString();
                            newLabel1.Size = new System.Drawing.Size(130, 17);
                            newLabel1.TabIndex = 4;
                            newLabel1.Text = "дробное 100.01";

                            this.Controls.Add(newLabel1);

                            labelsList.Add(newLabel1);
                            break;
                        }

                }

                if (!columnList[count].AutoInc)
                {
                    newTextBox = new TextBox();
                    newTextBox.Location = new System.Drawing.Point(12 + (100 * count), 60);
                    newTextBox.Name = "textBox" + count.ToString();
                    newTextBox.Size = new System.Drawing.Size(100, 22);
                    newTextBox.TabIndex = 2;


                    this.Controls.Add(newTextBox);

                    textBoxList.Add(newTextBox);
                }

                if (columnList[count].AutoInc)
                {                    
                    Label newLabel2 = new Label();


                    newLabel2.AutoSize = true;
                    newLabel2.Location = new System.Drawing.Point(12 + (100 * count), 130);
                    newLabel2.Name = "labelAuto" + count.ToString();
                    newLabel2.Size = new System.Drawing.Size(130, 17);
                    newLabel2.TabIndex = 4;
                    newLabel2.Text = "АвтоСчетчик";
                                 
                    this.Controls.Add(newLabel2);

                    labelsList.Add(newLabel2);

                    // невидимый текст бокс для корректной работы цикла
                    newTextBox = new TextBox();
                    newTextBox.Location = new System.Drawing.Point(12 + (100 * count), 60);
                    newTextBox.Name = "textBox" + count.ToString();
                    newTextBox.Size = new System.Drawing.Size(100, 22);
                    newTextBox.TabIndex = 2;
                   
                    textBoxList.Add(newTextBox);
                }
                
                if (columnList[count].Key)
                {
                    Label newLabel1 = new Label();


                    newLabel1.AutoSize = true;
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 110);
                    newLabel1.Name = "labelKey" + count.ToString();
                    newLabel1.Size = new System.Drawing.Size(130, 17);
                    newLabel1.TabIndex = 4;
                    newLabel1.Text = "Ключ";
                   

                    this.Controls.Add(newLabel1);

                    labelsList.Add(newLabel1);
                }

                if (columnList[count].NotNull)
                {
                    Label newLabel1 = new Label();

                    newLabel1.AutoSize = true;
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 150);
                    newLabel1.Name = "labelNotNull" + count.ToString();
                    newLabel1.Size = new System.Drawing.Size(130, 17);
                    newLabel1.TabIndex = 4;
                    newLabel1.Text = "Не пустой";

                    this.Controls.Add(newLabel1);

                    labelsList.Add(newLabel1);
                }

                if (columnList[count].Uniq)
                {
                    Label newLabel1 = new Label();

                    newLabel1.AutoSize = true;
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 170);
                    newLabel1.Name = "labelUniq" + count.ToString();
                    newLabel1.Size = new System.Drawing.Size(130, 17);
                    newLabel1.TabIndex = 4;
                    newLabel1.Text = "Уникальный";

                    this.Controls.Add(newLabel1);

                    labelsList.Add(newLabel1);
                }

                if (columnList[count].Default_value.ToString().Length > 0)
                {
                    Label newLabel1 = new Label();
                    Label newLabel2 = new Label();

                    newLabel1.AutoSize = true;
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 190);
                    newLabel1.Name = "labelDefault" + count.ToString();
                    newLabel1.Size = new System.Drawing.Size(130, 17);
                    newLabel1.TabIndex = 4;
                    newLabel1.Text = "По умолчанию";

                    newLabel2.AutoSize = true;
                    newLabel2.Location = new System.Drawing.Point(12 + (100 * count), 205);
                    newLabel2.Name = "labelDvalue" + count.ToString();
                    newLabel2.Size = new System.Drawing.Size(130, 17);
                    newLabel2.TabIndex = 4;
                    newLabel2.Text = columnList[count].Default_value.ToString();


                    this.Controls.Add(newLabel1);
                    this.Controls.Add(newLabel2);

                    labelsList.Add(newLabel1);
                    labelsList.Add(newLabel2);
                }

                this.Controls.Add(newLabel);
                
                
                labelsList.Add(newLabel);
                
                count++;
            }
            countParametrs = count;
        }

        public override void Refresh()
        {           

            labelsList.Clear();
            textBoxList.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            for (int i = 0; i < countParametrs; i++)
            {
                this.Controls.Remove(this.Controls["label" + i.ToString()]);                
                this.Controls.Remove(this.Controls["textBox" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelKey" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelAuto" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelNotNull" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelType" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelUniq" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelDefault" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelDvalue" + i.ToString()]);
            }     
            
        }
        
        private void InsertQuery_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
