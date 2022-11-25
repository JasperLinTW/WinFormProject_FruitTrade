using fruitTrade.Infra;
using fruitTrade.Models;
using fruitTrade.Models.Services;
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

namespace fruitTrade
{
    public partial class AddProductForm : Form
    {
        private int productId;
        private int memberId;

		public AddProductForm(int productId, int memberId)
        {
            InitializeComponent();
            this.productId = productId;
            this.memberId = memberId;

		}
        private void AddProductForm_Load(object sender, EventArgs e)
        {
            BindData(productId);
        }
        private ShoppingCartVM cartmodel;
        private void BindData(int productId)
        {
            var data = new ProductsService().GetProduct(productId);
           
            ProductVM model =new ProductsService().ToProductVM(data.Rows[0]);
            nameLable.Text = model.ProductName;
            priceLable.Text = "單價: " + model.Price.ToString() + "元" ;
            
           
            cartmodel = new ShoppingCartVM()
            {
                Member_Id = memberId,
                Product_Id = model.Product_Id,
                ProductName = model.ProductName,
                Price = model.Price
            };
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
			bool isUint = int.TryParse(quantityTxtBox.Text, out int quantity);
			if (isUint == false)
			{
				MessageBox.Show("您輸入的內容非整數");
				return;
			}
			if (quantity <= 0)
			{
				MessageBox.Show("您輸入的數字非正數");
				return;
			}

            cartmodel.quantity = quantity;
			if(new ProductsService().CreateCartItem(cartmodel))
            {
				this.DialogResult = DialogResult.OK;
			}
			
		}

        private void quantityTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.addBtn_Click(sender, e);
            }
        }
    }
}
