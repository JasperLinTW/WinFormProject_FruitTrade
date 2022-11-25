using fruitTrade.Models.Services;
using fruitTrade.Models;
using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using fruitTrade.Infra;

namespace fruitTrade
{
    public partial class EditShoppingCart : Form
    {
        private int productId;
        private int memberId;

		public EditShoppingCart(int product_Id, int memberId)
        {
            InitializeComponent();
            this.productId = product_Id;
            this.memberId = memberId;
        }
        private void EditShoppingCart_Load(object sender, EventArgs e)
        {
            BindData(productId);
        }
        private ShoppingCartVM cartmodel;
        private void BindData(int productId)
        {
            string sql = @"select S.Member_Id, S.Product_Id AS Product_Id, ProductName, Price, Quantity
                            from ShoppingCart S
                            join Products P ON P.Product_Id = S.Product_Id 
                            where Member_Id = @Member_Id
                            and S.Product_Id = @Product_Id";
            var parameters = new SqlParameterBuilder()
                            .AddInt("Member_Id", memberId)
                            .AddInt("Product_Id", productId)
                            .Build();
            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("抱歉找不到要編輯的目標");
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
            cartmodel = ProductsService.ToShoppingCart(data.Rows[0]);
 
            nameLable.Text = cartmodel.ProductName;
            quantityTxtbox.Text = cartmodel.quantity.ToString();
            
        }      

        private void updateBtn_Click(object sender, EventArgs e)
        {
            bool isUint = int.TryParse(quantityTxtbox.Text, out int quantity);
			if (isUint == false)
			{
				MessageBox.Show("您輸入的內容非整數");
				return;
			}
			if (quantity < 0)
			{
				MessageBox.Show("您輸入的數字非正數");
				return;
			}
            if(quantity == 0)
            {
                var result =MessageBox.Show("您確定要刪除嗎?","刪除警示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    new ProductsService().Delete(productId, cartmodel.Member_Id);
					this.DialogResult = DialogResult.OK;
				}
			}
			
            bool isInStock = ValidationHelper.IsInStock(cartmodel.Product_Id,quantity);
            if (isInStock == false)
            {
				MessageBox.Show("庫存不足請重新輸入");
				return;
			}
			cartmodel.quantity = quantity;
			new ProductsService().UpdateCart(cartmodel);
			this.DialogResult = DialogResult.OK;
		}

        private void deleteButton_Click(object sender, EventArgs e)
        {
			var result = MessageBox.Show("您確定要刪除嗎?", "刪除警示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				new ProductsService().Delete(productId, cartmodel.Member_Id);
				this.DialogResult = DialogResult.OK;
			}
		}

        private void quantityTxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.updateBtn_Click(sender, e);
            }
        }
    }
}
