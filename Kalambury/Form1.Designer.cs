namespace Kalambury
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
            this.rysujBox = new System.Windows.Forms.PictureBox();
            this.odpowiedzTextBox = new System.Windows.Forms.TextBox();
            this.wyslijOdpowiedzButton = new System.Windows.Forms.Button();
            this.wiadomosciTextBox = new System.Windows.Forms.RichTextBox();
            this.hasloTextBox = new System.Windows.Forms.TextBox();
            this.nickTextBox = new System.Windows.Forms.TextBox();
            this.dolaczButton = new System.Windows.Forms.Button();
            this.uzytkownicyListBox = new System.Windows.Forms.ListBox();
            this.wyczyscButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rysujBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rysujBox
            // 
            this.rysujBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rysujBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.rysujBox.Enabled = false;
            this.rysujBox.Location = new System.Drawing.Point(156, 5);
            this.rysujBox.Name = "rysujBox";
            this.rysujBox.Size = new System.Drawing.Size(465, 300);
            this.rysujBox.TabIndex = 0;
            this.rysujBox.TabStop = false;
            this.rysujBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.rysujBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // odpowiedzTextBox
            // 
            this.odpowiedzTextBox.Enabled = false;
            this.odpowiedzTextBox.Location = new System.Drawing.Point(155, 426);
            this.odpowiedzTextBox.Name = "odpowiedzTextBox";
            this.odpowiedzTextBox.Size = new System.Drawing.Size(465, 20);
            this.odpowiedzTextBox.TabIndex = 1;
            this.odpowiedzTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.odpowiedzButton_KeyPress);
            // 
            // wyslijOdpowiedzButton
            // 
            this.wyslijOdpowiedzButton.Enabled = false;
            this.wyslijOdpowiedzButton.Location = new System.Drawing.Point(6, 426);
            this.wyslijOdpowiedzButton.Name = "wyslijOdpowiedzButton";
            this.wyslijOdpowiedzButton.Size = new System.Drawing.Size(143, 23);
            this.wyslijOdpowiedzButton.TabIndex = 2;
            this.wyslijOdpowiedzButton.Text = "Wyslij";
            this.wyslijOdpowiedzButton.UseVisualStyleBackColor = true;
            this.wyslijOdpowiedzButton.Click += new System.EventHandler(this.wyslijOdpowiedzButton_Click);
            // 
            // wiadomosciTextBox
            // 
            this.wiadomosciTextBox.Location = new System.Drawing.Point(155, 340);
            this.wiadomosciTextBox.Name = "wiadomosciTextBox";
            this.wiadomosciTextBox.ReadOnly = true;
            this.wiadomosciTextBox.Size = new System.Drawing.Size(465, 80);
            this.wiadomosciTextBox.TabIndex = 3;
            this.wiadomosciTextBox.Text = "";
            // 
            // hasloTextBox
            // 
            this.hasloTextBox.Location = new System.Drawing.Point(272, 314);
            this.hasloTextBox.Name = "hasloTextBox";
            this.hasloTextBox.ReadOnly = true;
            this.hasloTextBox.Size = new System.Drawing.Size(348, 20);
            this.hasloTextBox.TabIndex = 5;
            this.hasloTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nickTextBox
            // 
            this.nickTextBox.Location = new System.Drawing.Point(5, 5);
            this.nickTextBox.Name = "nickTextBox";
            this.nickTextBox.Size = new System.Drawing.Size(146, 20);
            this.nickTextBox.TabIndex = 6;
            // 
            // dolaczButton
            // 
            this.dolaczButton.Location = new System.Drawing.Point(6, 32);
            this.dolaczButton.Name = "dolaczButton";
            this.dolaczButton.Size = new System.Drawing.Size(145, 23);
            this.dolaczButton.TabIndex = 7;
            this.dolaczButton.Text = "Dolacz";
            this.dolaczButton.UseVisualStyleBackColor = true;
            this.dolaczButton.Click += new System.EventHandler(this.dolaczButton_Click);
            // 
            // uzytkownicyListBox
            // 
            this.uzytkownicyListBox.FormattingEnabled = true;
            this.uzytkownicyListBox.Location = new System.Drawing.Point(5, 61);
            this.uzytkownicyListBox.Name = "uzytkownicyListBox";
            this.uzytkownicyListBox.Size = new System.Drawing.Size(145, 355);
            this.uzytkownicyListBox.TabIndex = 8;
            // 
            // wyczyscButton
            // 
            this.wyczyscButton.Enabled = false;
            this.wyczyscButton.Location = new System.Drawing.Point(156, 311);
            this.wyczyscButton.Name = "wyczyscButton";
            this.wyczyscButton.Size = new System.Drawing.Size(110, 23);
            this.wyczyscButton.TabIndex = 10;
            this.wyczyscButton.Text = "Wyczysc";
            this.wyczyscButton.UseVisualStyleBackColor = true;
            this.wyczyscButton.Click += new System.EventHandler(this.wyczyscButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 461);
            this.Controls.Add(this.wyczyscButton);
            this.Controls.Add(this.uzytkownicyListBox);
            this.Controls.Add(this.dolaczButton);
            this.Controls.Add(this.nickTextBox);
            this.Controls.Add(this.hasloTextBox);
            this.Controls.Add(this.wiadomosciTextBox);
            this.Controls.Add(this.wyslijOdpowiedzButton);
            this.Controls.Add(this.odpowiedzTextBox);
            this.Controls.Add(this.rysujBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Kalambury";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.rysujBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox rysujBox;
        private System.Windows.Forms.TextBox odpowiedzTextBox;
        private System.Windows.Forms.Button wyslijOdpowiedzButton;
        private System.Windows.Forms.RichTextBox wiadomosciTextBox;
        private System.Windows.Forms.TextBox hasloTextBox;
        private System.Windows.Forms.TextBox nickTextBox;
        private System.Windows.Forms.Button dolaczButton;
        private System.Windows.Forms.ListBox uzytkownicyListBox;
        private System.Windows.Forms.Button wyczyscButton;
    }
}

