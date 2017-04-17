namespace CryptoPro
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exportPublickKeyButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.certificateInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.deleteFileButton = new System.Windows.Forms.Button();
            this.decryptFileButton = new System.Windows.Forms.Button();
            this.encryptFileButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Загрузите сертификат";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exportPublickKeyButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(28, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 171);
            this.panel1.TabIndex = 1;
            // 
            // exportPublickKeyButton
            // 
            this.exportPublickKeyButton.Enabled = false;
            this.exportPublickKeyButton.Location = new System.Drawing.Point(17, 89);
            this.exportPublickKeyButton.Name = "exportPublickKeyButton";
            this.exportPublickKeyButton.Size = new System.Drawing.Size(224, 56);
            this.exportPublickKeyButton.TabIndex = 4;
            this.exportPublickKeyButton.Text = "Экспортировать открытый клкюч";
            this.exportPublickKeyButton.UseVisualStyleBackColor = true;
            this.exportPublickKeyButton.Click += new System.EventHandler(this.ExportPublickKey);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DownloadCertificate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Сертификаты";
            // 
            // certificateInfo
            // 
            this.certificateInfo.Location = new System.Drawing.Point(305, 81);
            this.certificateInfo.Multiline = true;
            this.certificateInfo.Name = "certificateInfo";
            this.certificateInfo.Size = new System.Drawing.Size(592, 552);
            this.certificateInfo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "ЭЦП";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkButton);
            this.panel2.Controls.Add(this.signButton);
            this.panel2.Location = new System.Drawing.Point(28, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 148);
            this.panel2.TabIndex = 4;
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(17, 89);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(224, 34);
            this.checkButton.TabIndex = 4;
            this.checkButton.Text = "Проверить";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.CheckSiganture);
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(17, 31);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(224, 31);
            this.signButton.TabIndex = 3;
            this.signButton.Text = "Подписать";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Enabled = false;
            this.signButton.Click += new System.EventHandler(this.Sign);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Шифрование";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.deleteFileButton);
            this.panel3.Controls.Add(this.decryptFileButton);
            this.panel3.Controls.Add(this.encryptFileButton);
            this.panel3.Location = new System.Drawing.Point(28, 430);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 203);
            this.panel3.TabIndex = 6;
            // 
            // deleteFileButton
            // 
            this.deleteFileButton.Location = new System.Drawing.Point(17, 146);
            this.deleteFileButton.Name = "deleteFileButton";
            this.deleteFileButton.Size = new System.Drawing.Size(224, 31);
            this.deleteFileButton.TabIndex = 5;
            this.deleteFileButton.Text = "Удалить файл";
            this.deleteFileButton.UseVisualStyleBackColor = true;
            this.deleteFileButton.Click += new System.EventHandler(this.DeleteFile);
            // 
            // decryptFileButton
            // 
            this.decryptFileButton.Enabled = false;
            this.decryptFileButton.Location = new System.Drawing.Point(17, 89);
            this.decryptFileButton.Name = "decryptFileButton";
            this.decryptFileButton.Size = new System.Drawing.Size(224, 31);
            this.decryptFileButton.TabIndex = 4;
            this.decryptFileButton.Text = "Расшифровать файл";
            this.decryptFileButton.UseVisualStyleBackColor = true;
            this.decryptFileButton.Click += new System.EventHandler(this.DecryptFile);
            // 
            // encryptFileButton
            // 
            this.encryptFileButton.Location = new System.Drawing.Point(17, 31);
            this.encryptFileButton.Name = "encryptFileButton";
            this.encryptFileButton.Size = new System.Drawing.Size(224, 31);
            this.encryptFileButton.TabIndex = 3;
            this.encryptFileButton.Text = "Зашифровать файл";
            this.encryptFileButton.UseVisualStyleBackColor = true;
            this.encryptFileButton.Enabled = false;
            this.encryptFileButton.Click += new System.EventHandler(this.EncryptFile);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 650);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.certificateInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exportPublickKeyButton;
        private System.Windows.Forms.TextBox certificateInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button decryptFileButton;
        private System.Windows.Forms.Button encryptFileButton;
        private System.Windows.Forms.Button deleteFileButton;
    }
}

