namespace CompanyApp
{
    partial class CompanyForm
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
            this.companiesComboBox = new System.Windows.Forms.ComboBox();
            this.divisionsComboBox = new System.Windows.Forms.ComboBox();
            this.projectsComboBox = new System.Windows.Forms.ComboBox();
            this.departmentsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.employeesDataGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addProjectButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addDivisionButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.leaderLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.addDepartmentButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // companiesComboBox
            // 
            this.companiesComboBox.FormattingEnabled = true;
            this.companiesComboBox.Location = new System.Drawing.Point(12, 29);
            this.companiesComboBox.Name = "companiesComboBox";
            this.companiesComboBox.Size = new System.Drawing.Size(160, 21);
            this.companiesComboBox.TabIndex = 0;
            this.companiesComboBox.SelectionChangeCommitted += new System.EventHandler(this.CompaniesComboBox_SelectionChangeCommitted);
            // 
            // divisionsComboBox
            // 
            this.divisionsComboBox.FormattingEnabled = true;
            this.divisionsComboBox.Location = new System.Drawing.Point(181, 29);
            this.divisionsComboBox.Name = "divisionsComboBox";
            this.divisionsComboBox.Size = new System.Drawing.Size(160, 21);
            this.divisionsComboBox.TabIndex = 1;
            this.divisionsComboBox.SelectionChangeCommitted += new System.EventHandler(this.DivisionsComboBox_SelectionChangeCommitted);
            // 
            // projectsComboBox
            // 
            this.projectsComboBox.FormattingEnabled = true;
            this.projectsComboBox.Location = new System.Drawing.Point(348, 29);
            this.projectsComboBox.Name = "projectsComboBox";
            this.projectsComboBox.Size = new System.Drawing.Size(160, 21);
            this.projectsComboBox.TabIndex = 2;
            this.projectsComboBox.SelectionChangeCommitted += new System.EventHandler(this.ProjectsComboBox_SelectionChangeCommitted);
            // 
            // departmentsComboBox
            // 
            this.departmentsComboBox.FormattingEnabled = true;
            this.departmentsComboBox.Location = new System.Drawing.Point(514, 29);
            this.departmentsComboBox.Name = "departmentsComboBox";
            this.departmentsComboBox.Size = new System.Drawing.Size(160, 21);
            this.departmentsComboBox.TabIndex = 3;
            this.departmentsComboBox.SelectionChangeCommitted += new System.EventHandler(this.DepartmentsComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Firma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Divízie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Projekty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Oddelenia";
            // 
            // employeesDataGridView
            // 
            this.employeesDataGridView.AllowUserToAddRows = false;
            this.employeesDataGridView.AllowUserToDeleteRows = false;
            this.employeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesDataGridView.Location = new System.Drawing.Point(12, 98);
            this.employeesDataGridView.Name = "employeesDataGridView";
            this.employeesDataGridView.ReadOnly = true;
            this.employeesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeesDataGridView.Size = new System.Drawing.Size(871, 320);
            this.employeesDataGridView.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Pridať";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(6, 49);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 10;
            this.editButton.Text = "Editovať";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(6, 79);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Vymazať";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Location = new System.Drawing.Point(889, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 120);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zamestnanci";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addProjectButton);
            this.groupBox2.Location = new System.Drawing.Point(889, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 59);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Projekty";
            // 
            // addProjectButton
            // 
            this.addProjectButton.Location = new System.Drawing.Point(6, 19);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(75, 23);
            this.addProjectButton.TabIndex = 0;
            this.addProjectButton.Text = "Pridať";
            this.addProjectButton.UseVisualStyleBackColor = true;
            this.addProjectButton.Click += new System.EventHandler(this.AddProjectButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addDivisionButton);
            this.groupBox3.Location = new System.Drawing.Point(889, 357);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(98, 61);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Divízie";
            // 
            // addDivisionButton
            // 
            this.addDivisionButton.Location = new System.Drawing.Point(6, 19);
            this.addDivisionButton.Name = "addDivisionButton";
            this.addDivisionButton.Size = new System.Drawing.Size(75, 23);
            this.addDivisionButton.TabIndex = 0;
            this.addDivisionButton.Text = "Pridať";
            this.addDivisionButton.UseVisualStyleBackColor = true;
            this.addDivisionButton.Click += new System.EventHandler(this.AddDivisionButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Vedúci:";
            // 
            // leaderLabel
            // 
            this.leaderLabel.AutoSize = true;
            this.leaderLabel.Location = new System.Drawing.Point(63, 67);
            this.leaderLabel.Name = "leaderLabel";
            this.leaderLabel.Size = new System.Drawing.Size(35, 13);
            this.leaderLabel.TabIndex = 16;
            this.leaderLabel.Text = "label6";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.addDepartmentButton);
            this.groupBox4.Location = new System.Drawing.Point(889, 224);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(98, 61);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Oddelenia";
            // 
            // addDepartmentButton
            // 
            this.addDepartmentButton.Location = new System.Drawing.Point(6, 19);
            this.addDepartmentButton.Name = "addDepartmentButton";
            this.addDepartmentButton.Size = new System.Drawing.Size(75, 23);
            this.addDepartmentButton.TabIndex = 0;
            this.addDepartmentButton.Text = "Pridať";
            this.addDepartmentButton.UseVisualStyleBackColor = true;
            this.addDepartmentButton.Click += new System.EventHandler(this.AddDepartmentButton_Click);
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.leaderLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.employeesDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.departmentsComboBox);
            this.Controls.Add(this.projectsComboBox);
            this.Controls.Add(this.divisionsComboBox);
            this.Controls.Add(this.companiesComboBox);
            this.Name = "CompanyForm";
            this.Text = "CompanyApp";
            this.Shown += new System.EventHandler(this.CompanyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox companiesComboBox;
        private System.Windows.Forms.ComboBox divisionsComboBox;
        private System.Windows.Forms.ComboBox projectsComboBox;
        private System.Windows.Forms.ComboBox departmentsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView employeesDataGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button addDivisionButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label leaderLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button addDepartmentButton;
    }
}

