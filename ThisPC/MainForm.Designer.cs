namespace ThisPC
{
    partial class MainForm
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rbLocalMachine = new System.Windows.Forms.RadioButton();
      this.rbCurrentUser = new System.Windows.Forms.RadioButton();
      this.txtFolderName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtFolderIconPath = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtFolderTooltip = new System.Windows.Forms.TextBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.txtFolderPath = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnDeleteSidebar = new System.Windows.Forms.Button();
      this.btnAddSidebar = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.rbLocalMachine);
      this.groupBox1.Controls.Add(this.rbCurrentUser);
      this.groupBox1.Location = new System.Drawing.Point(17, 14);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
      this.groupBox1.Size = new System.Drawing.Size(346, 75);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Install for";
      // 
      // rbLocalMachine
      // 
      this.rbLocalMachine.AutoSize = true;
      this.rbLocalMachine.Enabled = false;
      this.rbLocalMachine.Location = new System.Drawing.Point(240, 40);
      this.rbLocalMachine.Margin = new System.Windows.Forms.Padding(2);
      this.rbLocalMachine.Name = "rbLocalMachine";
      this.rbLocalMachine.Size = new System.Drawing.Size(95, 17);
      this.rbLocalMachine.TabIndex = 1;
      this.rbLocalMachine.Text = "Local Machine";
      this.rbLocalMachine.UseVisualStyleBackColor = true;
      // 
      // rbCurrentUser
      // 
      this.rbCurrentUser.AutoSize = true;
      this.rbCurrentUser.Checked = true;
      this.rbCurrentUser.Location = new System.Drawing.Point(98, 40);
      this.rbCurrentUser.Margin = new System.Windows.Forms.Padding(2);
      this.rbCurrentUser.Name = "rbCurrentUser";
      this.rbCurrentUser.Size = new System.Drawing.Size(84, 17);
      this.rbCurrentUser.TabIndex = 0;
      this.rbCurrentUser.TabStop = true;
      this.rbCurrentUser.Text = "Current User";
      this.rbCurrentUser.UseVisualStyleBackColor = true;
      // 
      // txtFolderName
      // 
      this.txtFolderName.Location = new System.Drawing.Point(107, 112);
      this.txtFolderName.Margin = new System.Windows.Forms.Padding(2);
      this.txtFolderName.Name = "txtFolderName";
      this.txtFolderName.Size = new System.Drawing.Size(258, 20);
      this.txtFolderName.TabIndex = 1;
      this.txtFolderName.Text = "MyFolder";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(32, 114);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Folder Name:";
      // 
      // txtFolderIconPath
      // 
      this.txtFolderIconPath.Location = new System.Drawing.Point(107, 182);
      this.txtFolderIconPath.Margin = new System.Windows.Forms.Padding(2);
      this.txtFolderIconPath.Name = "txtFolderIconPath";
      this.txtFolderIconPath.Size = new System.Drawing.Size(257, 20);
      this.txtFolderIconPath.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 184);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Folder Icon Path:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(32, 219);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(70, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Folder tooltip:";
      // 
      // txtFolderTooltip
      // 
      this.txtFolderTooltip.Location = new System.Drawing.Point(107, 217);
      this.txtFolderTooltip.Margin = new System.Windows.Forms.Padding(2);
      this.txtFolderTooltip.Name = "txtFolderTooltip";
      this.txtFolderTooltip.Size = new System.Drawing.Size(257, 20);
      this.txtFolderTooltip.TabIndex = 6;
      this.txtFolderTooltip.Text = "My folder tooltip.";
      // 
      // btnAdd
      // 
      this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAdd.Location = new System.Drawing.Point(126, 278);
      this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(114, 29);
      this.btnAdd.TabIndex = 7;
      this.btnAdd.Text = "Add to This PC";
      this.btnAdd.UseVisualStyleBackColor = false;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDelete.Location = new System.Drawing.Point(248, 278);
      this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(114, 29);
      this.btnDelete.TabIndex = 8;
      this.btnDelete.Text = "Delete from This PC";
      this.btnDelete.UseVisualStyleBackColor = false;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // txtFolderPath
      // 
      this.txtFolderPath.Location = new System.Drawing.Point(107, 147);
      this.txtFolderPath.Margin = new System.Windows.Forms.Padding(2);
      this.txtFolderPath.Name = "txtFolderPath";
      this.txtFolderPath.Size = new System.Drawing.Size(258, 20);
      this.txtFolderPath.TabIndex = 11;
      this.txtFolderPath.Text = "d:\\";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(40, 149);
      this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(64, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Folder Path:";
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Location = new System.Drawing.Point(17, 381);
      this.panel1.Margin = new System.Windows.Forms.Padding(2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(346, 120);
      this.panel1.TabIndex = 12;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(40, 46);
      this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(290, 60);
      this.label5.TabIndex = 2;
      this.label5.Text = "* In new GUID message box press \"Ctrl+C\" to copy the GUID then you can use it in " +
    "removing the folder.\r\n* Give a Star in github if you like it ;)";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.label4.Location = new System.Drawing.Point(40, 17);
      this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(35, 17);
      this.label4.TabIndex = 1;
      this.label4.Text = "Info";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::ThisPC.Properties.Resources.icons8_info_24;
      this.pictureBox1.Location = new System.Drawing.Point(17, 15);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(24, 24);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // btnDeleteSidebar
      // 
      this.btnDeleteSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.btnDeleteSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDeleteSidebar.Location = new System.Drawing.Point(248, 323);
      this.btnDeleteSidebar.Margin = new System.Windows.Forms.Padding(2);
      this.btnDeleteSidebar.Name = "btnDeleteSidebar";
      this.btnDeleteSidebar.Size = new System.Drawing.Size(114, 29);
      this.btnDeleteSidebar.TabIndex = 14;
      this.btnDeleteSidebar.Text = "Delete from Sidebar";
      this.btnDeleteSidebar.UseVisualStyleBackColor = false;
      this.btnDeleteSidebar.Click += new System.EventHandler(this.btnDeleteSidebar_Click);
      // 
      // btnAddSidebar
      // 
      this.btnAddSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnAddSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAddSidebar.Location = new System.Drawing.Point(126, 323);
      this.btnAddSidebar.Margin = new System.Windows.Forms.Padding(2);
      this.btnAddSidebar.Name = "btnAddSidebar";
      this.btnAddSidebar.Size = new System.Drawing.Size(114, 29);
      this.btnAddSidebar.TabIndex = 13;
      this.btnAddSidebar.Text = "Add to Sidebar";
      this.btnAddSidebar.UseVisualStyleBackColor = false;
      this.btnAddSidebar.Click += new System.EventHandler(this.btnAddSidebar_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(382, 519);
      this.Controls.Add(this.btnDeleteSidebar);
      this.Controls.Add(this.btnAddSidebar);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.txtFolderPath);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.txtFolderTooltip);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtFolderIconPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtFolderName);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(2);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Add Custom Folders under \"This PC\"";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLocalMachine;
        private System.Windows.Forms.RadioButton rbCurrentUser;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolderIconPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFolderTooltip;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDeleteSidebar;
        private System.Windows.Forms.Button btnAddSidebar;
    }
}

