namespace CompanyApp
{
    partial class AddProjectForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.divisionsComboBox = new System.Windows.Forms.ComboBox();
            this.leaderComboBox = new System.Windows.Forms.ComboBox();
            this.saveProjectButton = new System.Windows.Forms.Button();
            this.cancelProjectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Názov";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Divízia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vedúci";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(60, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(156, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // divisionsComboBox
            // 
            this.divisionsComboBox.FormattingEnabled = true;
            this.divisionsComboBox.Location = new System.Drawing.Point(60, 54);
            this.divisionsComboBox.Name = "divisionsComboBox";
            this.divisionsComboBox.Size = new System.Drawing.Size(156, 21);
            this.divisionsComboBox.TabIndex = 4;
            // 
            // leaderComboBox
            // 
            this.leaderComboBox.FormattingEnabled = true;
            this.leaderComboBox.Location = new System.Drawing.Point(60, 81);
            this.leaderComboBox.Name = "leaderComboBox";
            this.leaderComboBox.Size = new System.Drawing.Size(156, 21);
            this.leaderComboBox.TabIndex = 5;
            // 
            // saveProjectButton
            // 
            this.saveProjectButton.Location = new System.Drawing.Point(141, 123);
            this.saveProjectButton.Name = "saveProjectButton";
            this.saveProjectButton.Size = new System.Drawing.Size(75, 23);
            this.saveProjectButton.TabIndex = 6;
            this.saveProjectButton.Text = "Pridať";
            this.saveProjectButton.UseVisualStyleBackColor = true;
            this.saveProjectButton.Click += new System.EventHandler(this.SaveProjectButton_Click);
            // 
            // cancelProjectButton
            // 
            this.cancelProjectButton.Location = new System.Drawing.Point(60, 123);
            this.cancelProjectButton.Name = "cancelProjectButton";
            this.cancelProjectButton.Size = new System.Drawing.Size(75, 23);
            this.cancelProjectButton.TabIndex = 7;
            this.cancelProjectButton.Text = "Zrušiť";
            this.cancelProjectButton.UseVisualStyleBackColor = true;
            this.cancelProjectButton.Click += new System.EventHandler(this.CancelProjectButton_Click);
            // 
            // AddProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 158);
            this.Controls.Add(this.cancelProjectButton);
            this.Controls.Add(this.saveProjectButton);
            this.Controls.Add(this.leaderComboBox);
            this.Controls.Add(this.divisionsComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddProjectForm";
            this.Text = "AddProjectForm";
            this.Load += new System.EventHandler(this.AddProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox divisionsComboBox;
        private System.Windows.Forms.ComboBox leaderComboBox;
        private System.Windows.Forms.Button saveProjectButton;
        private System.Windows.Forms.Button cancelProjectButton;
    }
}