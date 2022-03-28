namespace ExamDataBase
{
    partial class CreateTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.columnName1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.default1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.key1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uniq1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.notNull1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.autoInc1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(787, 378);
            this.button1.Name = "buttonQuery";
            this.button1.Size = new System.Drawing.Size(120, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendQueryAdapter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 378);
            this.button2.Name = "buttonExit";
            this.button2.Size = new System.Drawing.Size(120, 60);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CloseForm);
            // 
            // columnName1
            // 
            this.columnName1.Location = new System.Drawing.Point(9, 70);
            this.columnName1.Name = "columnName1";
            this.columnName1.Size = new System.Drawing.Size(248, 22);
            this.columnName1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "int",
            "varchar(100)",
            "float",
            "date"});
            this.comboBox1.Location = new System.Drawing.Point(277, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название столбца";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Тип данных";
            // 
            // tableNameBox
            // 
            this.tableNameBox.Location = new System.Drawing.Point(148, 15);
            this.tableNameBox.Name = "tableNameBox";
            this.tableNameBox.Size = new System.Drawing.Size(250, 22);
            this.tableNameBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Название таблицы";
            // 
            // default1
            // 
            this.default1.Location = new System.Drawing.Point(415, 70);
            this.default1.Name = "default1";
            this.default1.Size = new System.Drawing.Size(139, 22);
            this.default1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "По умолчанию";
            // 
            // key1
            // 
            this.key1.AutoSize = true;
            this.key1.Location = new System.Drawing.Point(580, 75);
            this.key1.Name = "key1";
            this.key1.Size = new System.Drawing.Size(18, 17);
            this.key1.TabIndex = 10;
            this.key1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ключ";
            // 
            // uniq1
            // 
            this.uniq1.AutoSize = true;
            this.uniq1.Location = new System.Drawing.Point(631, 75);
            this.uniq1.Name = "uniq1";
            this.uniq1.Size = new System.Drawing.Size(18, 17);
            this.uniq1.TabIndex = 12;
            this.uniq1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(607, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Уникальный";
            // 
            // notNull1
            // 
            this.notNull1.AutoSize = true;
            this.notNull1.Location = new System.Drawing.Point(705, 75);
            this.notNull1.Name = "notNull1";
            this.notNull1.Size = new System.Drawing.Size(18, 17);
            this.notNull1.TabIndex = 14;
            this.notNull1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(684, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "NOT NULL";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(9, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 35);
            this.button3.TabIndex = 16;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.AddColumn);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(751, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Авто Инкремент";
            // 
            // autoInc1
            // 
            this.autoInc1.AutoSize = true;
            this.autoInc1.Location = new System.Drawing.Point(789, 75);
            this.autoInc1.Name = "autoInc1";
            this.autoInc1.Size = new System.Drawing.Size(18, 17);
            this.autoInc1.TabIndex = 18;
            this.autoInc1.UseVisualStyleBackColor = true;
            // 
            // CreateTableForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(919, 450);
            this.Controls.Add(this.autoInc1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.notNull1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uniq1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.key1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.default1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.columnName1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "CreateTableForm";
            this.Text = "CreateTable";
            this.Load += new System.EventHandler(this.CreateTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox columnName1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tableNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox default1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox key1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox uniq1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox notNull1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox autoInc1;
    }
}