namespace Aromatiy.AdminManeger
{
    partial class Menu
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.FIOLable = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ExitLbl = new System.Windows.Forms.Label();
            this.OrderBtn = new System.Windows.Forms.Button();
            this.TovarBtn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 47);
            this.panel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.FIOLable);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(538, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 47);
            this.panel5.TabIndex = 1;
            // 
            // FIOLable
            // 
            this.FIOLable.AutoSize = true;
            this.FIOLable.Location = new System.Drawing.Point(28, 22);
            this.FIOLable.Margin = new System.Windows.Forms.Padding(5, 10, 3, 0);
            this.FIOLable.Name = "FIOLable";
            this.FIOLable.Size = new System.Drawing.Size(35, 13);
            this.FIOLable.TabIndex = 0;
            this.FIOLable.Text = "label1";
            this.FIOLable.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Controls.Add(this.ExitLbl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(718, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(82, 47);
            this.panel4.TabIndex = 0;
            // 
            // ExitLbl
            // 
            this.ExitLbl.AutoSize = true;
            this.ExitLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitLbl.Location = new System.Drawing.Point(11, 15);
            this.ExitLbl.Name = "ExitLbl";
            this.ExitLbl.Size = new System.Drawing.Size(59, 23);
            this.ExitLbl.TabIndex = 0;
            this.ExitLbl.Text = "Выход";
            // 
            // OrderBtn
            // 
            this.OrderBtn.Location = new System.Drawing.Point(191, 149);
            this.OrderBtn.Name = "OrderBtn";
            this.OrderBtn.Size = new System.Drawing.Size(302, 54);
            this.OrderBtn.TabIndex = 3;
            this.OrderBtn.Text = "Заказы";
            this.OrderBtn.UseVisualStyleBackColor = true;
            this.OrderBtn.Click += new System.EventHandler(this.OrderBtn_Click);
            // 
            // TovarBtn
            // 
            this.TovarBtn.Location = new System.Drawing.Point(191, 235);
            this.TovarBtn.Name = "TovarBtn";
            this.TovarBtn.Size = new System.Drawing.Size(302, 54);
            this.TovarBtn.TabIndex = 4;
            this.TovarBtn.Text = "Сформировать заказ";
            this.TovarBtn.UseVisualStyleBackColor = true;
            this.TovarBtn.Click += new System.EventHandler(this.TovarBtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TovarBtn);
            this.Controls.Add(this.OrderBtn);
            this.Controls.Add(this.panel2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label FIOLable;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ExitLbl;
        private System.Windows.Forms.Button OrderBtn;
        private System.Windows.Forms.Button TovarBtn;
    }
}