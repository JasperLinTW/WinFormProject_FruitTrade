using fruitTrade.Infra;
using fruitTrade.Models;
using fruitTrade.Models.Services;
using fruitTrade.Models.ViewModels;
using fruitTrade.後台;
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
	public partial class ProductsForm : Form
	{
        private ProductIndexVM[] products = null;
        private ShoppingCartVM[] cartproducts = null;
        
        private MemberIndexVM member;
        public ProductsForm(MemberIndexVM member)
		{
			InitializeComponent();
            this.member = member;
			DisplayProducts();
            DisplayCart();
            
            greetLabel.Text = $"Hi, {member.Name}";
            
        }

        private void DisplayCart()
        {
            cartproducts = new ProductsService().GetAllCart(member.Member_Id).ToArray();
            BindData2(cartproducts);
        }

        private void DisplayProducts()
        {
            string keyword = searchTxt.Text;
            products = new ProductsService().GetAll(keyword).ToArray();
            
            BindData(products);
 
        }

        private void BindData2(ShoppingCartVM[] cartproducts)
        {
            int totalprice = new OrderService().GetTotal(cartproducts);
            shoppingCartGridView.DataSource = cartproducts;
            totalLable.Text = totalprice == 0 ? "總金額: " : $"總金額: {totalprice.ToString("#,#")}元";
        


        }

        private void BindData(ProductIndexVM[] products)
        {
            ProductDataGridView.DataSource = products;                       
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        private void ProductDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;

            ProductIndexVM row = this.products[rowIndex];
            int ptoductid = row.Product_Id;

            var frm = new AddProductForm(ptoductid, member.Member_Id);

            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayCart();
            }
        }

        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            bool isCartEmpty = cartproducts.Count() == 0;
            if (isCartEmpty)
            {
                MessageBox.Show("您的購物車沒有產品","商品缺貨");
                return;
            }
            
            List<int> notInStock = new List<int>() { };
            foreach (var item in cartproducts)
            {
                if(ValidationHelper.IsInStock(item.Product_Id, item.quantity)==false)
                {
                    notInStock.Add(item.Product_Id);
                };
            }

            bool isInStock = notInStock.Count() == 0;

            if (isInStock == false)
            {
                MessageBox.Show("您的購物車商品缺貨中，請重新選擇", "商品缺貨");
                foreach (int id in notInStock)
                {
                    new ProductsService().Delete(id, member.Member_Id);
                }
                DisplayCart();
                DisplayProducts();
                return ;
            }

            
            var frm = new CheckoutForm(member.Member_Id);

            DialogResult result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				DisplayCart();
                DisplayProducts();
			}
		}

        private void shoppingCartGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;

            ShoppingCartVM row = this.cartproducts[rowIndex];
            int productId = row.Product_Id;

            var frm = new EditShoppingCart(productId, member.Member_Id);

            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayCart();
            }
        }

        private void myOrder_Click(object sender, EventArgs e)
        {
            var frm = new OrdersForm(member.Member_Id);
			DialogResult result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				DisplayCart();
			}
		}

        private void ProductsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			this.Owner.Show();
		}

        private void logoutBtn_Click(object sender, EventArgs e)
        {
			DialogResult result = MessageBox.Show("您確定要登出嗎?",
				"登出",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				this.Close();
			}
		}

        private void memInfoBtn_Click(object sender, EventArgs e)
        {
			var frm = new EditMemberForm(member);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
                member= new UserService().GetMember(member.Member_Id)[0];
				greetLabel.Text = $"Hi, {member.Name}";
			}
		}

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            ProductDataGridView.Rows[0].Selected = false;
            if(shoppingCartGridView.Rows.Count > 0)
            {
				shoppingCartGridView.Rows[0].Selected = false;
			}
            

		}

        private void searchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchBtn_Click(sender, e);
            }
        }
    }
}
