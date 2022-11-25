namespace fruitTrade.後台
{
	partial class BEditProductForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BEditProductForm));
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.InventoryTxtBx = new System.Windows.Forms.TextBox();
			this.PriceTxtbx = new System.Windows.Forms.TextBox();
			this.ProductNameTxtBx = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.SaveBtn = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label3.Location = new System.Drawing.Point(43, 219);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 25);
			this.label3.TabIndex = 5;
			this.label3.Text = "庫存量";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label2.Location = new System.Drawing.Point(43, 164);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "單價";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(43, 101);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "商品名稱";
			// 
			// InventoryTxtBx
			// 
			this.InventoryTxtBx.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.InventoryTxtBx.Location = new System.Drawing.Point(139, 215);
			this.InventoryTxtBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.InventoryTxtBx.Name = "InventoryTxtBx";
			this.InventoryTxtBx.Size = new System.Drawing.Size(209, 34);
			this.InventoryTxtBx.TabIndex = 6;
			this.InventoryTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductNameTxtBx_KeyDown);
			// 
			// PriceTxtbx
			// 
			this.PriceTxtbx.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.PriceTxtbx.Location = new System.Drawing.Point(139, 161);
			this.PriceTxtbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PriceTxtbx.Name = "PriceTxtbx";
			this.PriceTxtbx.Size = new System.Drawing.Size(209, 34);
			this.PriceTxtbx.TabIndex = 4;
			this.PriceTxtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductNameTxtBx_KeyDown);
			// 
			// ProductNameTxtBx
			// 
			this.ProductNameTxtBx.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ProductNameTxtBx.Location = new System.Drawing.Point(141, 101);
			this.ProductNameTxtBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ProductNameTxtBx.Name = "ProductNameTxtBx";
			this.ProductNameTxtBx.Size = new System.Drawing.Size(207, 34);
			this.ProductNameTxtBx.TabIndex = 2;
			this.ProductNameTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductNameTxtBx_KeyDown);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.panel2.Controls.Add(this.label5);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(419, 68);
			this.panel2.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(153, 16);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(127, 36);
			this.label5.TabIndex = 0;
			this.label5.Text = "編輯商品";
			// 
			// SaveBtn
			// 
			this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.SaveBtn.FlatAppearance.BorderSize = 0;
			this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.SaveBtn.ForeColor = System.Drawing.Color.White;
			this.SaveBtn.Location = new System.Drawing.Point(171, 281);
			this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.SaveBtn.Name = "SaveBtn";
			this.SaveBtn.Size = new System.Drawing.Size(100, 31);
			this.SaveBtn.TabIndex = 7;
			this.SaveBtn.Text = "更新";
			this.SaveBtn.UseVisualStyleBackColor = false;
			this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
			// 
			// BEditProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(419, 358);
			this.Controls.Add(this.SaveBtn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.InventoryTxtBx);
			this.Controls.Add(this.PriceTxtbx);
			this.Controls.Add(this.ProductNameTxtBx);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "BEditProductForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "編輯商品";
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox InventoryTxtBx;
		private System.Windows.Forms.TextBox PriceTxtbx;
		private System.Windows.Forms.TextBox ProductNameTxtBx;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveBtn;
    }
}