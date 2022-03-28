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
    public partial class CreateTableForm : Form
    {
        private int countParametrs = 0;
        private List<TextBox> columnNameList = new List<TextBox>();
        private List<TextBox> defaultList = new List<TextBox>();
        private List<ComboBox> typeList = new List<ComboBox>();
        private List<CheckBox> keyList = new List<CheckBox>();
        private List<CheckBox> uniqList = new List<CheckBox>();
        private List<CheckBox> notNullList = new List<CheckBox>();
        private List<CheckBox> autoIncList = new List<CheckBox>();
        private List<Button> buttonList = new List<Button>();


        public CreateTableForm()
        {
            InitializeComponent();
            columnNameList.Add(this.columnName1);
            typeList.Add(this.comboBox1);
            defaultList.Add(this.default1);
            keyList.Add(this.key1);
            uniqList.Add(this.uniq1);
            notNullList.Add(this.notNull1);
            autoIncList.Add(this.autoInc1);

            Button newDeleteButton = new Button();

            newDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            newDeleteButton.Location = new System.Drawing.Point(873, 60 + (40 * countParametrs));
            newDeleteButton.Name = "button" + (countParametrs + 1).ToString();
            newDeleteButton.Size = new System.Drawing.Size(35, 35);
            newDeleteButton.TabIndex = 19;
            newDeleteButton.Text = "-" + (countParametrs + 1).ToString();
            newDeleteButton.UseVisualStyleBackColor = true;
            newDeleteButton.Click += new System.EventHandler(this.DeleteParametr);

            this.Controls.Add(newDeleteButton);

            buttonList.Add(newDeleteButton);

            countParametrs++;
        }

        private void fillColums(List<Column> columns)
        {         
            for (int i = 0; i < countParametrs; i++)
            {
                Column column = new Column(columnNameList[i].Text,
                    typeList[i].Text,
                    keyList[i].Checked,
                    autoIncList[i].Checked,
                    notNullList[i].Checked,
                    defaultList[i].Text,
                    uniqList[i].Checked
                    );
                columns.Add(column);
            }
        }        

        private void CreateTable_Load(object sender, EventArgs e)
        {

        }

        private void SendQueryAdapter(object sender, EventArgs e)
        {
            if (sendQuery())
            {
                Storage.MenuForm.Refresh();
                this.Close();
            }
        }
        private bool sendQuery()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                List<Column> columns = new List<Column>();


                fillColums(columns);
                cmd.Connection = Storage.DataBase.getConnect();


                StringBuilder cmdText = new StringBuilder();
                cmdText.Append("CREATE TABLE [" + this.tableNameBox.Text + "] (");

                /*
                for (int i = 0; i < countParametrs; i++)
                {
                    cmdText.Append("@COLUMNNAME" + i.ToString());
                    cmdText.Append(" @TYPE" + i.ToString());
                    cmdText.Append(" @KEY" + i.ToString());
                    cmdText.Append(" @AUTOINC" + i.ToString());
                    cmdText.Append(" @NOTNULL" + i.ToString());
                    cmdText.Append(" @DEFAULTS" + i.ToString());
                    cmdText.Append(" @UNIQ" + i.ToString());
                    cmdText.Append("\n");
                }
                cmdText.Append(");");
                */
                

                for (int i = 0; i < countParametrs; i++)
                {
                    if (!defaultList[i].Text.Equals(""))
                        switch (typeList[i].Text)
                        {
                            case "int":
                                {
                                    Int32.Parse(defaultList[i].Text);
                                    break;
                                }
                            case "float":
                                {
                                    float.Parse(defaultList[i].Text);
                                    break;
                                }
                            case "date":
                                {
                                    DateTime.Parse(defaultList[i].Text);
                                    break;
                                }
                            case "varchar(100)":
                                {
                                    if (defaultList[i].Text.Length < 101)
                                        break;
                                    else
                                    {
                                        throw new MyException("LimitLength");
                                    }
                                }
                        }
                    if (columns[i].ColumnName.Length > 0)
                        cmdText.Append(columns[i].ToSql());
                }
                cmdText.Remove(cmdText.Length - 2, 2);
                cmdText.Append(");");

                Console.WriteLine(cmdText.ToString());
                Console.WriteLine(this.tableNameBox.Text);
                cmd.CommandText = cmdText.ToString();

                //cmd.Parameters.AddWithValue("@NAMETABLE", this.tableNameBox.Text);

                Storage.DataBase.OpenConnection();

                cmd.ExecuteNonQuery();

                Storage.DataBase.CloseConnection();
                return true;
            }
            catch(MyException ex)
            {
                Console.WriteLine(ex);
                return false;
            }           
            catch(FormatException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddColumn(object sender, EventArgs e)
        {
            TextBox newColumnName = new TextBox();
            ComboBox newComdoBox = new ComboBox();
            TextBox newDefault = new TextBox();
            CheckBox newCheckKey = new CheckBox();
            CheckBox newCheckUniq = new CheckBox();
            CheckBox newCheckNull = new CheckBox();
            CheckBox newCheckAutoInc = new CheckBox();
            Button newDeleteButton = new Button();

            this.button3.Location = new System.Drawing.Point(9, 100 + (40 * countParametrs));
            this.button3.Refresh();
           
            /*
             * TextBox newColumnName
             */
            newColumnName.Location = new System.Drawing.Point(9, 70 + (40 * countParametrs));
            newColumnName.Name = "columnName" + (countParametrs + 1).ToString();
            newColumnName.Size = new System.Drawing.Size(248, 22);
            newColumnName.TabIndex = 2;

            /*
             *  ComboBox newComdoBox
             */
            newComdoBox.FormattingEnabled = true;
            newComdoBox.Location = new System.Drawing.Point(277, 68 + (40 * countParametrs));
            newComdoBox.Name = "comboBox" + (countParametrs + 1).ToString();
            newComdoBox.Size = new System.Drawing.Size(121, 24);
            newComdoBox.TabIndex = 3;
            newComdoBox.Items.Add("int");
            newComdoBox.Items.Add("varchar(100)");
            newComdoBox.Items.Add("float");
            newComdoBox.Items.Add("date");
            newComdoBox.DropDownStyle = ComboBoxStyle.DropDownList;

            /*
             * TextBox newDefault
             */
            newDefault.Location = new System.Drawing.Point(415, 70 + (40 * countParametrs));
            newDefault.Name = "default" + (countParametrs + 1).ToString();
            newDefault.Size = new System.Drawing.Size(139, 20);
            newDefault.TabIndex = 8;

            /*
             * CheckBox newCheckKey
             */            
            newCheckKey.AutoSize = true;
            newCheckKey.Location = new System.Drawing.Point(580, 75 + (40 * countParametrs));
            newCheckKey.Name = "key" + (countParametrs + 1).ToString();
            newCheckKey.Size = new System.Drawing.Size(15, 14);
            newCheckKey.TabIndex = 10;
            newCheckKey.UseVisualStyleBackColor = true;

            /*
             * CheckBox newCheckUniq
             */            
            newCheckUniq.AutoSize = true;
            newCheckUniq.Location = new System.Drawing.Point(631, 75 + (40 * countParametrs));
            newCheckUniq.Name = "uniq" + (countParametrs + 1).ToString();
            newCheckUniq.Size = new System.Drawing.Size(15, 14);
            newCheckUniq.TabIndex = 12;
            newCheckUniq.UseVisualStyleBackColor = true;

            /*
             *  CheckBox newCheckNull
             */            
            newCheckNull.AutoSize = true;
            newCheckNull.Location = new System.Drawing.Point(705, 75 + (40 * countParametrs));
            newCheckNull.Name = "notNull" + (countParametrs + 1).ToString();
            newCheckNull.Size = new System.Drawing.Size(15, 14);
            newCheckNull.TabIndex = 14;
            newCheckNull.UseVisualStyleBackColor = true;

            /*
             * CheckBox newCheckAutoInc
             */           
            newCheckAutoInc.AutoSize = true;
            newCheckAutoInc.Location = new System.Drawing.Point(789, 75 + (40 * countParametrs));
            newCheckAutoInc.Name = "autoInc" + (countParametrs + 1).ToString();
            newCheckAutoInc.Size = new System.Drawing.Size(15, 14);
            newCheckAutoInc.TabIndex = 18;
            newCheckAutoInc.UseVisualStyleBackColor = true;

            /*
             * Button newDeleteButton
             */
            newDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            newDeleteButton.Location = new System.Drawing.Point(873, 60 + (40 * countParametrs));
            newDeleteButton.Name = "button" + (countParametrs + 1).ToString();
            newDeleteButton.Size = new System.Drawing.Size(35, 35);
            newDeleteButton.TabIndex = 19;
            newDeleteButton.Text = "-" + (countParametrs + 1).ToString();
            newDeleteButton.UseVisualStyleBackColor = true;
            newDeleteButton.Click += new System.EventHandler(this.DeleteParametr);

            // добавляем на панель
            this.Controls.Add(newColumnName);
            this.Controls.Add(newComdoBox);           
            this.Controls.Add(newDefault);          
            this.Controls.Add(newCheckKey);
            this.Controls.Add(newCheckUniq);
            this.Controls.Add(newCheckNull);
            this.Controls.Add(newCheckAutoInc);
            this.Controls.Add(newDeleteButton);
            
            // сохраняем для будущего заполнения
            columnNameList.Add(newColumnName);
            typeList.Add(newComdoBox);
            defaultList.Add(newDefault);
            keyList.Add(newCheckKey);
            uniqList.Add(newCheckUniq);
            notNullList.Add(newCheckNull);
            autoIncList.Add(newCheckAutoInc);
            buttonList.Add(newDeleteButton);

            if (countParametrs > 5)
            {
                this.button1.Location = new System.Drawing.Point(714, 378 + (40 * (countParametrs - 5)));
                this.button2.Location = new System.Drawing.Point(12, 378 + (40 * (countParametrs - 5)));

                this.button1.Refresh();
                this.button2.Refresh();
            }
                //увеличиваем количество столбцов
            countParametrs++;
        }

        private void DeleteParametr(object sender, EventArgs e)
        {
            String howButton = sender.ToString();

            howButton = howButton.Remove(0, howButton.Length - 1);

            if (columnNameList.Count() > 0)
            {
                Console.WriteLine(howButton);

                this.Controls.Remove(this.Controls["columnName" + howButton]);
                this.Controls.Remove(this.Controls["comboBox" + howButton]);
                this.Controls.Remove(this.Controls["key" + howButton]);
                this.Controls.Remove(this.Controls["default" + howButton]);
                this.Controls.Remove(this.Controls["notNull" + howButton]);
                this.Controls.Remove(this.Controls["uniq" + howButton]);
                this.Controls.Remove(this.Controls["autoInc" + howButton]);
                this.Controls.Remove(this.Controls["button" + howButton]);

                columnNameList.RemoveAt(int.Parse(howButton) - 1);
                typeList.RemoveAt(int.Parse(howButton) - 1);
                defaultList.RemoveAt(int.Parse(howButton) - 1);
                keyList.RemoveAt(int.Parse(howButton) - 1);
                uniqList.RemoveAt(int.Parse(howButton) - 1);
                notNullList.RemoveAt(int.Parse(howButton) - 1);
                autoIncList.RemoveAt(int.Parse(howButton) - 1);
                buttonList.RemoveAt(int.Parse(howButton) - 1);

                countParametrs--;
                this.Refresh();
            }
        }

        public override void Refresh()
        {
            int count = countParametrs;
            countParametrs = 0;


            foreach (TextBox tb in columnNameList)
            {
                tb.Name = "columnName" + (countParametrs + 1).ToString();
                tb.Location = new System.Drawing.Point(9, 70 + (40 * countParametrs));
                tb.Refresh();
                countParametrs++;
            }

            countParametrs = 0;

            foreach (TextBox tb in defaultList)
            {
                tb.Name = "default" + (countParametrs + 1).ToString();
                tb.Location = new System.Drawing.Point(415, 70 + (40 * countParametrs));
                tb.Refresh();
                countParametrs++;
            }

            countParametrs = 0;

            foreach (ComboBox tb in typeList)
            {
                tb.Name = "comboBox" + (countParametrs + 1).ToString();
                tb.Location = new System.Drawing.Point(277, 68 + (40 * countParametrs));
                tb.Refresh();
                countParametrs++;
            }

            countParametrs = 0;

            foreach (CheckBox tb in keyList)
            {
                tb.Name = "key" + (countParametrs + 1).ToString();
                tb.Location = new System.Drawing.Point(580, 75 + (40 * countParametrs));
                tb.Refresh();
                countParametrs++;
            }

            countParametrs = 0;

            foreach (CheckBox tb in uniqList)
            {
                tb.Name = "uniq" + (countParametrs + 1).ToString();
                tb.Location = new System.Drawing.Point(631, 75 + (40 * countParametrs));
                tb.Refresh();
                countParametrs++;
            }

            countParametrs = 0;

            foreach (CheckBox tb in notNullList)
            {
                tb.Name = "notNull" + (countParametrs + 1).ToString();
                tb.Location = new System.Drawing.Point(705, 75 + (40 * countParametrs));
                tb.Refresh();
                countParametrs++;
            }

            countParametrs = 0;

            foreach (CheckBox tb in autoIncList)
            {
                tb.Name = "autoInc" + (countParametrs + 1).ToString();
                tb.Location = new System.Drawing.Point(789, 75 + (40 * countParametrs));
                tb.Refresh();
                countParametrs++;
            }

            countParametrs = 0;

            foreach (Button tb in buttonList)
            {
                tb.Location = new System.Drawing.Point(873, 60 + (40 * countParametrs));
                tb.Name = "button" + (countParametrs + 1).ToString();
                tb.Text = "-" + (countParametrs + 1).ToString();
                tb.Refresh();
                countParametrs++;
            }

            if (countParametrs > 5)
            {
                this.button1.Location = new System.Drawing.Point(714, 378 + (40 * (countParametrs - 5)));
                this.button2.Location = new System.Drawing.Point(12, 378 + (40 * (countParametrs - 5)));

                this.button1.Refresh();
                this.button2.Refresh();
            }

            this.button3.Location = new System.Drawing.Point(9, 60 + (40 * countParametrs));
            this.button3.Refresh();
        
        }
    }
}
