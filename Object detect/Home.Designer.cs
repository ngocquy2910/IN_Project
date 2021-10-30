
namespace Object_detect
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel_Directional = new System.Windows.Forms.Panel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.ngaythangnam = new System.Windows.Forms.Label();
            this.thoigian = new System.Windows.Forms.Label();
            this.sangchieutoi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Directional
            // 
            this.panel_Directional.AutoScroll = true;
            this.panel_Directional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(56)))), ((int)(((byte)(143)))));
            this.panel_Directional.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Directional.Location = new System.Drawing.Point(0, 0);
            this.panel_Directional.Name = "panel_Directional";
            this.panel_Directional.Size = new System.Drawing.Size(222, 749);
            this.panel_Directional.TabIndex = 6;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.White;
            this.panel_main.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_main.BackgroundImage")));
            this.panel_main.Controls.Add(this.ngaythangnam);
            this.panel_main.Controls.Add(this.thoigian);
            this.panel_main.Controls.Add(this.sangchieutoi);
            this.panel_main.Controls.Add(this.label2);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(222, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(962, 749);
            this.panel_main.TabIndex = 7;
            this.panel_main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_main_Paint);
            // 
            // ngaythangnam
            // 
            this.ngaythangnam.AutoSize = true;
            this.ngaythangnam.BackColor = System.Drawing.Color.Gainsboro;
            this.ngaythangnam.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaythangnam.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ngaythangnam.Location = new System.Drawing.Point(9, 99);
            this.ngaythangnam.Name = "ngaythangnam";
            this.ngaythangnam.Size = new System.Drawing.Size(64, 43);
            this.ngaythangnam.TabIndex = 90;
            this.ngaythangnam.Text = "ad";
            // 
            // thoigian
            // 
            this.thoigian.AutoSize = true;
            this.thoigian.BackColor = System.Drawing.Color.LightGray;
            this.thoigian.Font = new System.Drawing.Font("Bahnschrift", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.thoigian.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.thoigian.Location = new System.Drawing.Point(6, 9);
            this.thoigian.Name = "thoigian";
            this.thoigian.Size = new System.Drawing.Size(102, 77);
            this.thoigian.TabIndex = 89;
            this.thoigian.Text = "ad";
            // 
            // sangchieutoi
            // 
            this.sangchieutoi.AutoSize = true;
            this.sangchieutoi.BackColor = System.Drawing.Color.Gainsboro;
            this.sangchieutoi.Font = new System.Drawing.Font("Bahnschrift", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.sangchieutoi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sangchieutoi.Location = new System.Drawing.Point(46, 343);
            this.sangchieutoi.Name = "sangchieutoi";
            this.sangchieutoi.Size = new System.Drawing.Size(77, 58);
            this.sangchieutoi.TabIndex = 88;
            this.sangchieutoi.Text = "ad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(49, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 37);
            this.label2.TabIndex = 87;
            this.label2.Text = "Welcome!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 749);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_Directional);
            this.Name = "Home";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Directional;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ngaythangnam;
        private System.Windows.Forms.Label thoigian;
        private System.Windows.Forms.Label sangchieutoi;
    }
}