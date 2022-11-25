namespace fruitTrade
{
    partial class AddProductForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
			this.nameLable = new System.Windows.Forms.Label();
			this.priceLable = new System.Windows.Forms.Label();
			this.quantityTxtBox = new System.Windows.Forms.TextBox();
			this.addBtn = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// nameLable
			// 
			this.nameLable.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameLable.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.nameLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.nameLable.Location = new System.Drawing.Point(0, 0);
			this.nameLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.nameLable.Name = "nameLable";
			this.nameLable.Size = new System.Drawing.Size(344, 48);
			this.nameLable.TabIndex = 0;
			this.nameLable.Text = "Name";
			this.nameLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// priceLable
			// 
			this.priceLable.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.priceLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.priceLable.Location = new System.Drawing.Point(60, 60);
			this.priceLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.priceLable.Name = "priceLable";
			this.priceLable.Size = new System.Drawing.Size(115, 31);
			this.priceLable.TabIndex = 1;
			this.priceLable.Text = "Price";
			this.priceLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// quantityTxtBox
			// 
			this.quantityTxtBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.quantityTxtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.quantityTxtBox.Location = new System.Drawing.Point(120, 113);
			this.quantityTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.quantityTxtBox.Name = "quantityTxtBox";
			this.quantityTxtBox.Size = new System.Drawing.Size(166, 34);
			this.quantityTxtBox.TabIndex = 3;
			this.quantityTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quantityTxtBox_KeyDown);
			// 
			// addBtn
			// 
			this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.addBtn.FlatAppearance.BorderSize = 0;
			this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.addBtn.ForeColor = System.Drawing.Color.White;
			this.addBtn.Location = new System.Drawing.Point(61, 186);
			this.addBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(225, 34);
			this.addBtn.TabIndex = 4;
			this.addBtn.Text = "加入購物車";
			this.addBtn.UseVisualStyleBackColor = false;
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(102)))));
			this.label4.Location = new System.Drawing.Point(60, 118);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 25);
			this.label4.TabIndex = 2;
			this.label4.Text = "數量";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// AddProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(344, 248);
			this.Controls.Add(this.addBtn);
			this.Controls.Add(this.quantityTxtBox);
			this.Controls.Add(this.priceLable);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nameLable);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "AddProductForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "新增商品";
			this.Load += new System.EventHandler(this.AddProductForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLable;
        private System.Windows.Forms.Label priceLable;
        private System.Windows.Forms.TextBox quantityTxtBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}