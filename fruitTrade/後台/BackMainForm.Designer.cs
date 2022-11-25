namespace fruitTrade.後台
{
	partial class BackMainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackMainForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.logoutBtn = new System.Windows.Forms.Button();
			this.orderManagementBtn = new System.Windows.Forms.Button();
			this.ProductManagemetButton = new System.Windows.Forms.Button();
			this.memberManagementBtn = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.logoutBtn);
			this.panel2.Controls.Add(this.orderManagementBtn);
			this.panel2.Controls.Add(this.ProductManagemetButton);
			this.panel2.Controls.Add(this.memberManagementBtn);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 100);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(199, 848);
			this.panel2.TabIndex = 15;
			// 
			// logoutBtn
			// 
			this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(61)))));
			this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.logoutBtn.FlatAppearance.BorderSize = 0;
			this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.logoutBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.logoutBtn.ForeColor = System.Drawing.Color.White;
			this.logoutBtn.Image = ((System.Drawing.Image)(resources.GetObject("logoutBtn.Image")));
			this.logoutBtn.Location = new System.Drawing.Point(0, 780);
			this.logoutBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.logoutBtn.Name = "logoutBtn";
			this.logoutBtn.Size = new System.Drawing.Size(197, 66);
			this.logoutBtn.TabIndex = 3;
			this.logoutBtn.Text = "　員工登出";
			this.logoutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.logoutBtn.UseVisualStyleBackColor = false;
			this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
			// 
			// orderManagementBtn
			// 
			this.orderManagementBtn.BackColor = System.Drawing.Color.White;
			this.orderManagementBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.orderManagementBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.orderManagementBtn.FlatAppearance.BorderSize = 2;
			this.orderManagementBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.orderManagementBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.orderManagementBtn.Image = ((System.Drawing.Image)(resources.GetObject("orderManagementBtn.Image")));
			this.orderManagementBtn.Location = new System.Drawing.Point(0, 132);
			this.orderManagementBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.orderManagementBtn.Name = "orderManagementBtn";
			this.orderManagementBtn.Size = new System.Drawing.Size(197, 66);
			this.orderManagementBtn.TabIndex = 2;
			this.orderManagementBtn.Text = "　訂單管理";
			this.orderManagementBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.orderManagementBtn.UseVisualStyleBackColor = false;
			this.orderManagementBtn.Click += new System.EventHandler(this.orderManagementBtn_Click);
			// 
			// ProductManagemetButton
			// 
			this.ProductManagemetButton.BackColor = System.Drawing.Color.White;
			this.ProductManagemetButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.ProductManagemetButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.ProductManagemetButton.FlatAppearance.BorderSize = 2;
			this.ProductManagemetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ProductManagemetButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ProductManagemetButton.Image = ((System.Drawing.Image)(resources.GetObject("ProductManagemetButton.Image")));
			this.ProductManagemetButton.Location = new System.Drawing.Point(0, 66);
			this.ProductManagemetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ProductManagemetButton.Name = "ProductManagemetButton";
			this.ProductManagemetButton.Size = new System.Drawing.Size(197, 66);
			this.ProductManagemetButton.TabIndex = 1;
			this.ProductManagemetButton.Text = "　商品管理";
			this.ProductManagemetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ProductManagemetButton.UseVisualStyleBackColor = false;
			this.ProductManagemetButton.Click += new System.EventHandler(this.ProductManagemetButton_Click);
			// 
			// memberManagementBtn
			// 
			this.memberManagementBtn.BackColor = System.Drawing.Color.White;
			this.memberManagementBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.memberManagementBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.memberManagementBtn.FlatAppearance.BorderSize = 2;
			this.memberManagementBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.memberManagementBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.memberManagementBtn.Image = ((System.Drawing.Image)(resources.GetObject("memberManagementBtn.Image")));
			this.memberManagementBtn.Location = new System.Drawing.Point(0, 0);
			this.memberManagementBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.memberManagementBtn.Name = "memberManagementBtn";
			this.memberManagementBtn.Size = new System.Drawing.Size(197, 66);
			this.memberManagementBtn.TabIndex = 0;
			this.memberManagementBtn.Text = "　會員管理";
			this.memberManagementBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.memberManagementBtn.UseVisualStyleBackColor = false;
			this.memberManagementBtn.Click += new System.EventHandler(this.memberManagementBtn_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1549, 100);
			this.panel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.label3.Font = new System.Drawing.Font("微軟正黑體", 28F, System.Drawing.FontStyle.Bold);
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(488, 21);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(542, 60);
			this.label3.TabIndex = 0;
			this.label3.Text = "阿城水果攤後台管理系統";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(421, 26);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(68, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// BackMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1549, 948);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "BackMainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "阿城水果攤後台管理系統";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackMainForm_FormClosing);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button memberManagementBtn;
		private System.Windows.Forms.Button logoutBtn;
		private System.Windows.Forms.Button orderManagementBtn;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ProductManagemetButton;
    }
}