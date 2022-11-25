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
    public partial class CheckoutForm : Form
    {
		private ShoppingCartVM[] cartproducts = null;
		private int id;
		public CheckoutForm(int id)
        {
            InitializeComponent();
			this.id = id;
			DisplayMemberInfo();
			DisplayCart();
		}
		private void CheckoutForm_Load(object sender, EventArgs e)
		{
			BindData(cartproducts);
			checklistGridView.Rows[0].Selected = false;
			
		}
		
		private void DisplayMemberInfo()
        {
            var member = new UserService().GetMember(id)[0];
			string template = 
                @"親愛的顧客您好，以下是您的訂單詳情，
若資料正確請點擊確認完成下訂，並在24小時內完成匯款(700-12345678912345)。
我們會盡快為您處理，您可在「我的訂單」中查詢進度。
收件人:{0}
連絡電話:{1}
收件地址:{2}
E-mail: {3}
訂單內容:";
			memberInfoLable.Text = string.Format(template, member.Name,
                                                 member.Phone_Number,
                                                 member.Email,
                                                 member.Address);
		}
		private void DisplayCart()
		{
			cartproducts = new ProductsService().GetAllCart(id).ToArray();
			BindData(cartproducts);
		}
		private void BindData(ShoppingCartVM[] cartproducts)
		{
			checklistGridView.DataSource = cartproducts;
			totalLable.Text = "總金額: ";
			totalLable.Text += new OrderService().GetTotal(cartproducts).ToString("#,#") + "元";
		}

		private void orderBtn_Click(object sender, EventArgs e)
		{
			new OrderService().SaveToOrder(cartproducts, id);
			new ProductsService().UpdateInventory(cartproducts);
            new OrderService().CleanCart(cartproducts, id);
			this.DialogResult = DialogResult.OK;
		}

		private void checklistGridView_SelectionChanged(object sender, EventArgs e)
		{
			checklistGridView.ClearSelection();
		}
	}
}
