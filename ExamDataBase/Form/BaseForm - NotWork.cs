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
    /*
     * При создании потомка ОБЯЗАТЕЛЬНО в конструкторе заполнять контекст. context = this
     */
    public partial class BaseForm : Form
    {
        internal List<Label> labelsList = new List<Label>();
        internal List<TextBox> textBoxList = new List<TextBox>();
        internal List<Column> columnList;
        internal int countParametrs = 0;
        internal String tableName;
        internal BaseForm context;

        public BaseForm()
        {
            InitializeComponent();
            for (int i = 0; i < Storage.TableNamesList.Count(); i++)
                comboBox1.Items.Add(Storage.TableNamesList[i]);
            
        }

        internal List<Column> InitColumnsAdapter()
        {
            columnList = Storage.InitColumns(tableName);

            return columnList;
        }

        public void comboBox1_SelectedIndexChanged()
        {
            int count = 0;
            tableName = context.comboBox1.Text;


            if (countParametrs != 0)
                Refresh();

            InitTables.tablesInfoToDataGrid(context.comboBox1.Text, context.dataGridView1);

            InitColumnsAdapter();


            foreach (DataGridViewColumn columnName in context.dataGridView1.Columns)
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

                            context.Controls.Add(newLabel1);

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

                            context.Controls.Add(newLabel1);

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

                            context.Controls.Add(newLabel1);

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

                            context.Controls.Add(newLabel1);

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


                    context.Controls.Add(newTextBox);

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

                    context.Controls.Add(newLabel2);

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


                    context.Controls.Add(newLabel1);

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

                    context.Controls.Add(newLabel1);

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

                    context.Controls.Add(newLabel1);

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


                    context.Controls.Add(newLabel1);
                    context.Controls.Add(newLabel2);

                    labelsList.Add(newLabel1);
                    labelsList.Add(newLabel2);
                }

                context.Controls.Add(newLabel);


                labelsList.Add(newLabel);

                count++;
            }
            countParametrs = count;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        private void BaseForm_Load_1(object sender, EventArgs e)
        {

        }

        public override void Refresh()
        {

            labelsList.Clear();
            textBoxList.Clear();
            context.dataGridView1.Columns.Clear();
            context.dataGridView1.Rows.Clear();

            for (int i = 0; i < countParametrs; i++)
            {
                context.Controls.Remove(context.Controls["label" + i.ToString()]);
                context.Controls.Remove(context.Controls["textBox" + i.ToString()]);
                context.Controls.Remove(context.Controls["labelKey" + i.ToString()]);
                context.Controls.Remove(context.Controls["labelAuto" + i.ToString()]);
                context.Controls.Remove(context.Controls["labelNotNull" + i.ToString()]);
                context.Controls.Remove(context.Controls["labelType" + i.ToString()]);
                context.Controls.Remove(context.Controls["labelUniq" + i.ToString()]);
                context.Controls.Remove(context.Controls["labelDefault" + i.ToString()]);
                context.Controls.Remove(context.Controls["labelDvalue" + i.ToString()]);
            }

        }
    }
}
