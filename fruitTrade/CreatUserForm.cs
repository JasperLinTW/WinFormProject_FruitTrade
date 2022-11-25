using fruitTrade.Infra;
using fruitTrade.Models.Services;
using fruitTrade.Models.ViewModels;
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
	public partial class CreatUserForm : Form
	{
		public CreatUserForm()
		{
			InitializeComponent();
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			MemberVM Member = new MemberVM()
			{
				Account = AccountTxtBox.Text,
				Name = nameTxtBox.Text,
				Password = passwordTextBox.Text,
				Email = EmailTextBox.Text,
				Phone_Number = PhoneTextBox.Text,
				Address = adressTextBox.Text
			};

			Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
			{
				{"Name", nameTxtBox},
				{"Account", AccountTxtBox},
				{"Password", passwordTextBox},
				{"Email", EmailTextBox},
				{"Phone_Number", PhoneTextBox},
				{"Address", adressTextBox},
			};

			bool isValid = ValidationHelper.Validate(Member, map, errorProvider1);
			if (!isValid) return;

			try
			{
				bool canCreate =new UserService().Create(Member);

				if (canCreate)
				{
					this.DialogResult = DialogResult.OK;
					MessageBox.Show("註冊成功", "註冊成功");
					this.Close();
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("新增失敗，原因: " + ex.Message, "錯誤訊息");
			}
		}

		private void CreatUserForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Owner.Show();
		}

		private void adressTextBox_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                this.createButton_Click(sender, e);
            }
        }
	}
}
