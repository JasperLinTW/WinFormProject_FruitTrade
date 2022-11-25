using fruitTrade.Infra;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fruitTrade
{
	public partial class LoginForm : Form
	{
		//分前後台，預設是會員登入，False時改成員工登入
		private bool isMember = true;
		public LoginForm()
		{
			InitializeComponent();
		}
		private void loginButton_Click(object sender, EventArgs e)
		{
			// 繫結
			LoginVM model = new LoginVM
			{
				Account = accountTextBox.Text,
				Password = passwordTextBox.Text
			};

			// 驗證欄位
			Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
			{
				{"Account", accountTextBox},
				{"Password", passwordTextBox},
			};

			bool isValid = ValidationHelper.Validate(model, map, errorProvider1);
			if (!isValid) return;

			// 驗證帳密

			bool result = new UserService().Authenticate(model, isMember);
			if (result == false)
			{
				MessageBox.Show("帳號或密碼錯誤");
				return;
			}

			// 進入主頁面，前後台分開
			accountTextBox.Text = String.Empty;
			passwordTextBox.Text = String.Empty;
			if (isMember)
			{
				var member = new UserService().GetMember(model.Account)[0];
				var frm = new ProductsForm(member);
				frm.Owner = this;

				frm.Show();
				this.Hide();
			}
			else
			{
				var employee = new UserService().GetEmployee(model.Account)[0];
				var frm = new BackMainForm(employee);
				frm.Owner = this;

				frm.Show();
				this.Hide();
			}

		}

		private void AlterButton_Click(object sender, EventArgs e)
		{
            errorProvider1.Clear();
            isMember = !isMember;
			titleLabel.Text = isMember? "阿城水果攤 會員登入":"員工登入";
			AlterButton.Text = isMember? "切換至員工專區": "切換至會員專區";
			registerButton.Visible = isMember ? true : false;
			loginButton.Width = isMember ? 100 : 205;
			loginButton.Location = isMember ? new Point(166, 163) : new Point(62, 163);
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			errorProvider1.Clear();
			var frm = new CreatUserForm();
			frm.Owner = this;

			frm.Show();
			this.Hide();
		}

		private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {        
                this.loginButton_Click(sender, e);
            }
        }
	}
}
