
namespace LifelineNewBuild
{
    partial class ActForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActForm));
            this.clTanggal = new System.Windows.Forms.DateTimePicker();
            this.tbNama = new System.Windows.Forms.TextBox();
            this.btnAct = new System.Windows.Forms.Button();
            this.tbDesk = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clTanggal
            // 
            this.clTanggal.Location = new System.Drawing.Point(43, 163);
            this.clTanggal.Name = "clTanggal";
            this.clTanggal.Size = new System.Drawing.Size(200, 20);
            this.clTanggal.TabIndex = 15;
            // 
            // tbNama
            // 
            this.tbNama.Location = new System.Drawing.Point(43, 92);
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(100, 20);
            this.tbNama.TabIndex = 14;
            // 
            // btnAct
            // 
            this.btnAct.BackColor = System.Drawing.Color.Transparent;
            this.btnAct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAct.BackgroundImage")));
            this.btnAct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAct.ForeColor = System.Drawing.Color.White;
            this.btnAct.Location = new System.Drawing.Point(43, 402);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(145, 37);
            this.btnAct.TabIndex = 8;
            this.btnAct.UseVisualStyleBackColor = false;
            this.btnAct.Click += new System.EventHandler(this.btnAct_Click);
            // 
            // tbDesk
            // 
            this.tbDesk.Location = new System.Drawing.Point(43, 249);
            this.tbDesk.Name = "tbDesk";
            this.tbDesk.Size = new System.Drawing.Size(100, 20);
            this.tbDesk.TabIndex = 13;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDel.BackgroundImage")));
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(300, 402);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(37, 37);
            this.btnDel.TabIndex = 11;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdt
            // 
            this.btnEdt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdt.BackgroundImage")));
            this.btnEdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdt.ForeColor = System.Drawing.Color.White;
            this.btnEdt.Location = new System.Drawing.Point(194, 402);
            this.btnEdt.Name = "btnEdt";
            this.btnEdt.Size = new System.Drawing.Size(100, 37);
            this.btnEdt.TabIndex = 12;
            this.btnEdt.UseVisualStyleBackColor = true;
            this.btnEdt.Click += new System.EventHandler(this.btnEdt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nama Aktivitas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tanggal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Desc";
            // 
            // ActForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdt);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.tbDesk);
            this.Controls.Add(this.btnAct);
            this.Controls.Add(this.tbNama);
            this.Controls.Add(this.clTanggal);
            this.DoubleBuffered = true;
            this.Name = "ActForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifeline";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker clTanggal;
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.Button btnAct;
        private System.Windows.Forms.TextBox tbDesk;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}