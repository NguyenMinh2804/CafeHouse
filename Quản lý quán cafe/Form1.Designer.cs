namespace Quản_lý_quán_cafe
{
    partial class flogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btthoat = new System.Windows.Forms.Button();
            this.btdangnhap = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbmatkhau = new System.Windows.Forms.TextBox();
            this.lmatkhau = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbtendangnhap = new System.Windows.Forms.TextBox();
            this.ltendangnhap = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btthoat);
            this.panel1.Controls.Add(this.btdangnhap);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 295);
            this.panel1.TabIndex = 0;
            // 
            // btthoat
            // 
            this.btthoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btthoat.Location = new System.Drawing.Point(510, 157);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(116, 23);
            this.btthoat.TabIndex = 3;
            this.btthoat.Text = "Thoát";
            this.btthoat.UseVisualStyleBackColor = true;
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
            // 
            // btdangnhap
            // 
            this.btdangnhap.Location = new System.Drawing.Point(380, 157);
            this.btdangnhap.Name = "btdangnhap";
            this.btdangnhap.Size = new System.Drawing.Size(116, 23);
            this.btdangnhap.TabIndex = 2;
            this.btdangnhap.Text = "Đăng nhập";
            this.btdangnhap.UseVisualStyleBackColor = true;
            this.btdangnhap.Click += new System.EventHandler(this.btdangnhap_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbmatkhau);
            this.panel3.Controls.Add(this.lmatkhau);
            this.panel3.Location = new System.Drawing.Point(3, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(692, 74);
            this.panel3.TabIndex = 1;
            // 
            // tbmatkhau
            // 
            this.tbmatkhau.Location = new System.Drawing.Point(157, 29);
            this.tbmatkhau.Name = "tbmatkhau";
            this.tbmatkhau.Size = new System.Drawing.Size(452, 20);
            this.tbmatkhau.TabIndex = 1;
            this.tbmatkhau.UseSystemPasswordChar = true;
            // 
            // lmatkhau
            // 
            this.lmatkhau.AutoSize = true;
            this.lmatkhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmatkhau.Location = new System.Drawing.Point(21, 30);
            this.lmatkhau.Name = "lmatkhau";
            this.lmatkhau.Size = new System.Drawing.Size(84, 19);
            this.lmatkhau.TabIndex = 0;
            this.lmatkhau.Text = "Mật khẩu:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbtendangnhap);
            this.panel2.Controls.Add(this.ltendangnhap);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 71);
            this.panel2.TabIndex = 0;
            // 
            // tbtendangnhap
            // 
            this.tbtendangnhap.Location = new System.Drawing.Point(157, 29);
            this.tbtendangnhap.Name = "tbtendangnhap";
            this.tbtendangnhap.Size = new System.Drawing.Size(452, 20);
            this.tbtendangnhap.TabIndex = 1;
            // 
            // ltendangnhap
            // 
            this.ltendangnhap.AutoSize = true;
            this.ltendangnhap.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltendangnhap.Location = new System.Drawing.Point(21, 30);
            this.ltendangnhap.Name = "ltendangnhap";
            this.ltendangnhap.Size = new System.Drawing.Size(130, 19);
            this.ltendangnhap.TabIndex = 0;
            this.ltendangnhap.Text = "Tên đăng nhập:";
            // 
            // flogin
            // 
            this.AcceptButton = this.btdangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btthoat;
            this.ClientSize = new System.Drawing.Size(691, 295);
            this.Controls.Add(this.panel1);
            this.Name = "flogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.flogin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbmatkhau;
        private System.Windows.Forms.Label lmatkhau;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbtendangnhap;
        private System.Windows.Forms.Label ltendangnhap;
        private System.Windows.Forms.Button btthoat;
        private System.Windows.Forms.Button btdangnhap;
    }
}

