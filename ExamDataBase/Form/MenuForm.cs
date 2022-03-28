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
    public partial class MenuForm : Form
    {        
        private List<Label> labelList = new List<Label>();
        private List<DataGridView> dataGridViewList = new List<DataGridView>();        


        public MenuForm()
        {
            Console.WriteLine("Start");
            InitializeComponent();
            Storage.MenuForm = this;
            /*
             * Загрузка данных
             */
            InitTables.loadTables();           
            ShowTables();
            InitTables.loadTablesColumnInfo(); 
        }
        
        public void ShowTables()
        {
            for(int i = 0; i < Storage.TableNamesList.Count(); i++) { 
                Label newLabel = new Label();
                DataGridView newDataGridView = new DataGridView();               

                /*
                 * Label labelBuild
                 */
                newLabel.AutoSize = true;
                newLabel.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point(12 + (220 * i), 260);
                newLabel.Name = "label" + i.ToString();                
                newLabel.TabIndex = 1;
                newLabel.Size = new System.Drawing.Size(120, 60);
                newLabel.Text = Storage.TableNamesList[i];

                /*
                 * DataGridView dataGridViewBuild
                 */
                newDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDataGridView.Location = new System.Drawing.Point(12 + (220 * i), 280);
                newDataGridView.Name = "dataGridView" + i.ToString();
                newDataGridView.RowHeadersWidth = 51;
                newDataGridView.RowTemplate.Height = 24;
                newDataGridView.Size = new System.Drawing.Size(217, 346);
                newDataGridView.TabIndex = 4;

                // добавляем на панель
                this.Controls.Add(newLabel);
                this.Controls.Add(newDataGridView);
                
                // запоминаем ссылки
                labelList.Add(newLabel);
                dataGridViewList.Add(newDataGridView);


                InitTables.newTablesInfoToDataGrid(Storage.TableNamesList[i], newDataGridView, i);
            }
        }
       
        public void RefreshAdapter(object sender, EventArgs e)
        {
            Refresh();
        }

        public override void Refresh() { 
            int count = Storage.TableNamesList.Count();


            for (int i = 0; i < count; i++)
            {
                this.Controls.Remove(this.Controls["label" + i.ToString()]);
                this.Controls.Remove(this.Controls["dataGridView" + i.ToString()]);
            }
            labelList.Clear();
            dataGridViewList.Clear();

            Storage.Clear();
            InitTables.loadTables();
            ShowTables();
            InitTables.loadTablesColumnInfo();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void CreateTable(object sender, EventArgs e)
        {
            CreateTableForm create = new CreateTableForm();
            Storage.CreateTableForm = create;
            Storage.CreateTableForm.Show();
        }

        private void InsertQuery(object sender, EventArgs e)
        {
            InsertForm insertQuery = new InsertForm();
            Storage.InsertQueryForm = insertQuery;
            Storage.InsertQueryForm.Show();
        }

        private void UpdateQuery(object sender, EventArgs e)
        {
            UpdateForm update = new UpdateForm();
            Storage.Updateform = update;
            Storage.Updateform.Show();
        }

        private void MyQuery(object sender, EventArgs e)
        {
            MyQueryForm myQuery = new MyQueryForm();
            Storage.MyQueryForm = myQuery;
            Storage.MyQueryForm.Show();
        }

        private void DeleteQuery(object sender, EventArgs e)
        {
            DeleteForm deleteForm = new DeleteForm();
            Storage.DeleteForm = deleteForm;
            Storage.DeleteForm.Show();
        }
    }
}
