using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamDataBase
{
    public partial class DeleteForm : Form
    {
        private List<Label> labelsList = new List<Label>();
        private List<TextBox> textBoxIN = new List<TextBox>(20);
        private List<TextBox> textBoxNOTIN = new List<TextBox>(20);
        private List<TextBox> textBoxLIKE = new List<TextBox>(20);
        private List<TextBox> textBoxBETWEEN = new List<TextBox>(20);       
        private List<ComboBox> comboChooseList = new List<ComboBox>();
        private List<ComboBox> comboLogicalList = new List<ComboBox>();
        private List<Column> columnList;
        private int countParametrs = 0;
        private int countBlocks = 0;
        private String tableName;

        public DeleteForm()
        {
            InitializeComponent();
            for (int i = 0; i < Storage.TableNamesList.Count(); i++)
                this.comboBox1.Items.Add(Storage.TableNamesList[i]);
        }

        internal List<Column> InitColumnsAdapter()
        {
            columnList = Storage.InitColumns(tableName);

            return columnList;
        }

        

        private void DeleteForm_Load(object sender, EventArgs e)
        {

        }

        public override void Refresh()
        {
            labelsList.Clear();            
            
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            for (int i = 0; i < countParametrs; i++)
            {
                //info
                this.Controls.Remove(this.Controls["label" + i.ToString()]);              
                this.Controls.Remove(this.Controls["labelKey" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelAuto" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelNotNull" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelType" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelUniq" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelDefault" + i.ToString()]);
                this.Controls.Remove(this.Controls["labelDvalue" + i.ToString()]);
                //constructor
               
            }
            ConstructorRefresh(1);
        }

        private void ConstructorRowDelete(int level, int row)
        {
            if (level == 1)
            {
                comboChooseList.RemoveAt(row);
                this.Controls.Remove(this.Controls["СolumnChoose" + row.ToString()]);
            }
            if (level <= 2)
            {
                comboLogicalList.RemoveAt(row);
                this.Controls.Remove(this.Controls["СolumnLogical" + row.ToString()]);
            }

            if (level <= 3)
            {
                textBoxBETWEEN.RemoveAt(row);
                textBoxIN.RemoveAt(row);
                textBoxLIKE.RemoveAt(row);
                textBoxNOTIN.RemoveAt(row);

                this.Controls.Remove(this.Controls["textBoxNOTIN" + row.ToString()]);
                this.Controls.Remove(this.Controls["textBoxLIKE" + row.ToString()]);
                this.Controls.Remove(this.Controls["textBoxIN" + row.ToString()]);
                this.Controls.Remove(this.Controls["textBoxBETWEEN" + row.ToString()]);
            }
        }

        private void ConstructorRefresh(int level)
        {
            if (level == 1)
            {
                comboChooseList.Clear();
                for (int i = 0; i < countParametrs; i++)
                {
                    this.Controls.Remove(this.Controls["СolumnChoose" + i.ToString()]);

                }
            }
            if (level <= 2)
            {
                comboLogicalList.Clear();
                for (int i = 0; i < countParametrs; i++)
                {
                    this.Controls.Remove(this.Controls["СolumnLogical" + i.ToString()]);
                }
            }

            if (level <= 3)
            {
                textBoxBETWEEN.Clear();
                textBoxIN.Clear();
                textBoxLIKE.Clear();
                textBoxNOTIN.Clear();

                for (int i = 0; i < countParametrs; i++)
                {
                    this.Controls.Remove(this.Controls["textBoxNOTIN" + i.ToString()]);
                    this.Controls.Remove(this.Controls["textBoxLIKE" + i.ToString()]);
                    this.Controls.Remove(this.Controls["textBoxIN" + i.ToString()]);
                    this.Controls.Remove(this.Controls["textBoxBETWEEN" + i.ToString()]);
                }
            }
        }

        private void DeleteAdapter(object sender, EventArgs e)
        {

        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
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
                

                if (columnList[count].AutoInc)
                {
                    Label newLabel2 = new Label();


                    newLabel2.AutoSize = true;
                    newLabel2.Location = new System.Drawing.Point(12 + (100 * count), 90);
                    newLabel2.Name = "labelAuto" + count.ToString();
                    newLabel2.Size = new System.Drawing.Size(130, 17);
                    newLabel2.TabIndex = 4;
                    newLabel2.Text = "АвтоСчетчик";

                    this.Controls.Add(newLabel2);

                    labelsList.Add(newLabel2);                  
                }

                if (columnList[count].Key)
                {
                    Label newLabel1 = new Label();


                    newLabel1.AutoSize = true;
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 70);
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
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 110);
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
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 130);
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
                    newLabel1.Location = new System.Drawing.Point(12 + (100 * count), 150);
                    newLabel1.Name = "labelDefault" + count.ToString();
                    newLabel1.Size = new System.Drawing.Size(130, 17);
                    newLabel1.TabIndex = 4;
                    newLabel1.Text = "По умолчанию";

                    newLabel2.AutoSize = true;
                    newLabel2.Location = new System.Drawing.Point(12 + (100 * count), 165);
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

            StartConstructor();
        }

        private void StartConstructor()
        {
            AddLine();
        }

        private void AddLine()
        {
            countBlocks++;

            ComboBox newComboBox;

            newComboBox = new ComboBox();
            newComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            newComboBox.FormattingEnabled = true;
            newComboBox.Location = new System.Drawing.Point(12, 210 + (40 * countBlocks));
            newComboBox.Name = "СolumnChoose" + countBlocks.ToString();
            newComboBox.Size = new System.Drawing.Size(100, 24);
            newComboBox.TabIndex = 0;
            newComboBox.SelectedIndexChanged += new System.EventHandler(this.ColumnChoose_SelectedIndexChanged);
            newComboBox.Items.AddRange(Storage.TableColumsNamesDict[tableName]);

            this.Controls.Add(newComboBox);
            comboChooseList.Add(newComboBox);

            this.button3.Location = new System.Drawing.Point(12, 240 + (40 * countBlocks));
            this.button3.Refresh();      
        }

        private void ColumnChoose_SelectedIndexChanged(object sender, EventArgs e)
        {          
            int hash = sender.GetHashCode();
            bool gate = false;
            int nomberInList = 0;
            int y;


            ConstructorRefresh(2);

            for (int i = 0; i < comboChooseList.Count(); i++)
            {
                if (comboChooseList[i].GetHashCode() == hash)
                {                   
                    y = comboChooseList[i].Location.Y;
                    nomberInList = i;
                    gate = true;
                    break;
                }
            }

            if(gate)
            {
                ComboBox newComboBox;

                newComboBox = new ComboBox();
                newComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                newComboBox.FormattingEnabled = true;
                newComboBox.Location = new System.Drawing.Point(122, 210 + (40 * countBlocks));
                newComboBox.Name = "СolumnLogical" + countBlocks.ToString();
                newComboBox.Size = new System.Drawing.Size(100, 24);
                newComboBox.TabIndex = 0;
                newComboBox.SelectedIndexChanged += new System.EventHandler(this.Logical_SelectedIndexChanged);
                newComboBox.Items.AddRange(new object[] {
                    "IN",
                    "NOT IN",
                    "BETWEEN"                                       
                });

                if (Storage.TableColumsTypeInfoDict[tableName][comboChooseList[nomberInList].SelectedIndex].Equals("varchar"))
                {
                    newComboBox.Items.Add("LIKE");
                }

                if (!Storage.TableNotNullColumnsDict[tableName][comboChooseList[nomberInList].SelectedIndex])
                {
                    newComboBox.Items.AddRange(new object[] {
                    "IS NULL",
                    "NOT NULL",
                    });
                }

                this.Controls.Add(newComboBox);
                comboLogicalList.Add(newComboBox);
            }


            

        }

        private void Logical_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hash = sender.GetHashCode();
            bool gate = false;
            int nomberInList = 0;
            int y;


            for (int i = 0; i < comboLogicalList.Count(); i++)
            {
                if (comboLogicalList[i].GetHashCode() == hash)
                {
                    Console.WriteLine(hash.ToString());
                    Console.WriteLine(comboLogicalList[i].GetHashCode().ToString());
                    y = comboLogicalList[i].Location.Y;
                    nomberInList = i;
                    gate = true;
                    break;
                }
            }

            if (gate)
            {
                TextBox newTextBox;

                switch (comboLogicalList[nomberInList].SelectedItem)
                {
                    case "IN":
                        {
                            newTextBox = new TextBox();
                            newTextBox.Location = new System.Drawing.Point(232, 210 + (40 * countBlocks));
                            newTextBox.Name = "textBoxIN" + countBlocks.ToString();
                            newTextBox.Size = new System.Drawing.Size(100, 22);
                            newTextBox.TabIndex = 2;

                            this.Controls.Add(newTextBox);
                            textBoxIN[countBlocks] = newTextBox;
                            break;
                        }
                    case "NOT IN":
                        {
                            newTextBox = new TextBox();
                            newTextBox.Location = new System.Drawing.Point(232, 210 + (40 * countBlocks));
                            newTextBox.Name = "textBoxNOTIN" + countBlocks.ToString();
                            newTextBox.Size = new System.Drawing.Size(100, 22);
                            newTextBox.TabIndex = 2;

                            this.Controls.Add(newTextBox);
                            textBoxNOTIN[countBlocks] = newTextBox;
                            break;
                        }
                    case "BETWEEN":
                        {
                            break;
                        }
                    case "LIKE":
                        {
                            break;
                        }
                }



            }
        }
    }
}
