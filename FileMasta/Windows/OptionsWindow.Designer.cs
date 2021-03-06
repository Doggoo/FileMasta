﻿namespace FileMasta.Windows
{
    partial class OptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsWindow));
            this.textBoxConnectionPassword = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxConnectionUsername = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxConnectionPort = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConnectionAddress = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.labelConnectionAddress = new System.Windows.Forms.Label();
            this.labelTitleSettings = new System.Windows.Forms.Label();
            this.labelConnectionDefault = new System.Windows.Forms.Label();
            this.checkBoxConnectionDefault = new System.Windows.Forms.CheckBox();
            this.labelTitleGeneral = new System.Windows.Forms.Label();
            this.labelGeneralClearDataOnClose = new System.Windows.Forms.Label();
            this.checkBoxGeneralClearDataOnClose = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxConnectionPassword
            // 
            this.textBoxConnectionPassword.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectionPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionPassword.ForeColor = System.Drawing.Color.Black;
            this.textBoxConnectionPassword.Location = new System.Drawing.Point(250, 223);
            this.textBoxConnectionPassword.Name = "textBoxConnectionPassword";
            this.textBoxConnectionPassword.Size = new System.Drawing.Size(226, 25);
            this.textBoxConnectionPassword.TabIndex = 38;
            this.textBoxConnectionPassword.WaterMark = "Password";
            this.textBoxConnectionPassword.WaterMarkActiveForeColor = System.Drawing.Color.White;
            this.textBoxConnectionPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionPassword.WaterMarkForeColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(13, 228);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 37;
            this.label4.Text = "Password:";
            // 
            // textBoxConnectionUsername
            // 
            this.textBoxConnectionUsername.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectionUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionUsername.ForeColor = System.Drawing.Color.Black;
            this.textBoxConnectionUsername.Location = new System.Drawing.Point(250, 194);
            this.textBoxConnectionUsername.Name = "textBoxConnectionUsername";
            this.textBoxConnectionUsername.Size = new System.Drawing.Size(226, 25);
            this.textBoxConnectionUsername.TabIndex = 35;
            this.textBoxConnectionUsername.WaterMark = "Username";
            this.textBoxConnectionUsername.WaterMarkActiveForeColor = System.Drawing.Color.White;
            this.textBoxConnectionUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionUsername.WaterMarkForeColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 199);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Address:";
            // 
            // textBoxConnectionPort
            // 
            this.textBoxConnectionPort.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectionPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionPort.ForeColor = System.Drawing.Color.Black;
            this.textBoxConnectionPort.Location = new System.Drawing.Point(250, 165);
            this.textBoxConnectionPort.Name = "textBoxConnectionPort";
            this.textBoxConnectionPort.Size = new System.Drawing.Size(226, 25);
            this.textBoxConnectionPort.TabIndex = 32;
            this.textBoxConnectionPort.WaterMark = "Port";
            this.textBoxConnectionPort.WaterMarkActiveForeColor = System.Drawing.Color.White;
            this.textBoxConnectionPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionPort.WaterMarkForeColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Port:";
            // 
            // textBoxConnectionAddress
            // 
            this.textBoxConnectionAddress.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnectionAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionAddress.ForeColor = System.Drawing.Color.Black;
            this.textBoxConnectionAddress.Location = new System.Drawing.Point(250, 136);
            this.textBoxConnectionAddress.Name = "textBoxConnectionAddress";
            this.textBoxConnectionAddress.Size = new System.Drawing.Size(226, 25);
            this.textBoxConnectionAddress.TabIndex = 29;
            this.textBoxConnectionAddress.WaterMark = "Address";
            this.textBoxConnectionAddress.WaterMarkActiveForeColor = System.Drawing.Color.White;
            this.textBoxConnectionAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxConnectionAddress.WaterMarkForeColor = System.Drawing.SystemColors.WindowFrame;
            // 
            // labelConnectionAddress
            // 
            this.labelConnectionAddress.AutoSize = true;
            this.labelConnectionAddress.BackColor = System.Drawing.Color.Transparent;
            this.labelConnectionAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelConnectionAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelConnectionAddress.Location = new System.Drawing.Point(13, 141);
            this.labelConnectionAddress.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.labelConnectionAddress.Name = "labelConnectionAddress";
            this.labelConnectionAddress.Size = new System.Drawing.Size(52, 15);
            this.labelConnectionAddress.TabIndex = 28;
            this.labelConnectionAddress.Text = "Address:";
            // 
            // labelTitleSettings
            // 
            this.labelTitleSettings.AutoSize = true;
            this.labelTitleSettings.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitleSettings.Location = new System.Drawing.Point(12, 79);
            this.labelTitleSettings.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.labelTitleSettings.Name = "labelTitleSettings";
            this.labelTitleSettings.Size = new System.Drawing.Size(94, 21);
            this.labelTitleSettings.TabIndex = 25;
            this.labelTitleSettings.Text = "Connection";
            // 
            // labelConnectionDefault
            // 
            this.labelConnectionDefault.AutoSize = true;
            this.labelConnectionDefault.BackColor = System.Drawing.Color.Transparent;
            this.labelConnectionDefault.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelConnectionDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelConnectionDefault.Location = new System.Drawing.Point(12, 114);
            this.labelConnectionDefault.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.labelConnectionDefault.Name = "labelConnectionDefault";
            this.labelConnectionDefault.Size = new System.Drawing.Size(52, 15);
            this.labelConnectionDefault.TabIndex = 26;
            this.labelConnectionDefault.Text = "Custom:";
            // 
            // checkBoxConnectionDefault
            // 
            this.checkBoxConnectionDefault.AutoSize = true;
            this.checkBoxConnectionDefault.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxConnectionDefault.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.checkBoxConnectionDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxConnectionDefault.Location = new System.Drawing.Point(251, 114);
            this.checkBoxConnectionDefault.Name = "checkBoxConnectionDefault";
            this.checkBoxConnectionDefault.Size = new System.Drawing.Size(15, 14);
            this.checkBoxConnectionDefault.TabIndex = 27;
            this.checkBoxConnectionDefault.UseVisualStyleBackColor = false;
            this.checkBoxConnectionDefault.CheckedChanged += new System.EventHandler(this.checkBoxConnectionDefault_CheckedChanged);
            // 
            // labelTitleGeneral
            // 
            this.labelTitleGeneral.AutoSize = true;
            this.labelTitleGeneral.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleGeneral.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitleGeneral.Location = new System.Drawing.Point(12, 13);
            this.labelTitleGeneral.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.labelTitleGeneral.Name = "labelTitleGeneral";
            this.labelTitleGeneral.Size = new System.Drawing.Size(66, 21);
            this.labelTitleGeneral.TabIndex = 20;
            this.labelTitleGeneral.Text = "General";
            // 
            // labelGeneralClearDataOnClose
            // 
            this.labelGeneralClearDataOnClose.AutoSize = true;
            this.labelGeneralClearDataOnClose.BackColor = System.Drawing.Color.Transparent;
            this.labelGeneralClearDataOnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelGeneralClearDataOnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelGeneralClearDataOnClose.Location = new System.Drawing.Point(13, 48);
            this.labelGeneralClearDataOnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.labelGeneralClearDataOnClose.Name = "labelGeneralClearDataOnClose";
            this.labelGeneralClearDataOnClose.Size = new System.Drawing.Size(110, 15);
            this.labelGeneralClearDataOnClose.TabIndex = 21;
            this.labelGeneralClearDataOnClose.Text = "Clear data on close:";
            // 
            // checkBoxGeneralClearDataOnClose
            // 
            this.checkBoxGeneralClearDataOnClose.AutoSize = true;
            this.checkBoxGeneralClearDataOnClose.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxGeneralClearDataOnClose.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.checkBoxGeneralClearDataOnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxGeneralClearDataOnClose.Location = new System.Drawing.Point(251, 48);
            this.checkBoxGeneralClearDataOnClose.Name = "checkBoxGeneralClearDataOnClose";
            this.checkBoxGeneralClearDataOnClose.Size = new System.Drawing.Size(15, 14);
            this.checkBoxGeneralClearDataOnClose.TabIndex = 22;
            this.checkBoxGeneralClearDataOnClose.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(84, 281);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(48, 23);
            this.buttonSave.TabIndex = 40;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestore.Location = new System.Drawing.Point(16, 281);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(62, 23);
            this.buttonRestore.TabIndex = 41;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 319);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxConnectionPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxConnectionUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxConnectionPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxConnectionAddress);
            this.Controls.Add(this.labelConnectionAddress);
            this.Controls.Add(this.labelTitleSettings);
            this.Controls.Add(this.labelConnectionDefault);
            this.Controls.Add(this.checkBoxConnectionDefault);
            this.Controls.Add(this.labelTitleGeneral);
            this.Controls.Add(this.labelGeneralClearDataOnClose);
            this.Controls.Add(this.checkBoxGeneralClearDataOnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ChreneLib.Controls.TextBoxes.CTextBox textBoxConnectionPassword;
        private System.Windows.Forms.Label label4;
        public ChreneLib.Controls.TextBoxes.CTextBox textBoxConnectionUsername;
        private System.Windows.Forms.Label label3;
        public ChreneLib.Controls.TextBoxes.CTextBox textBoxConnectionPort;
        private System.Windows.Forms.Label label2;
        public ChreneLib.Controls.TextBoxes.CTextBox textBoxConnectionAddress;
        private System.Windows.Forms.Label labelConnectionAddress;
        private System.Windows.Forms.Label labelTitleSettings;
        private System.Windows.Forms.Label labelConnectionDefault;
        private System.Windows.Forms.CheckBox checkBoxConnectionDefault;
        private System.Windows.Forms.Label labelTitleGeneral;
        private System.Windows.Forms.Label labelGeneralClearDataOnClose;
        private System.Windows.Forms.CheckBox checkBoxGeneralClearDataOnClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonRestore;
    }
}