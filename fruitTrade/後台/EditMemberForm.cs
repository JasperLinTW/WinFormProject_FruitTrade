using fruitTrade.Infra;
using fruitTrade.Models.Services;
using fruitTrade.Models.ViewModels;
using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace fruitTrade.後台
{
    public partial class EditMemberForm : Form
    {
        private MemberIndexVM member;
        public EditMemberForm(MemberIndexVM member)
        {
            InitializeComponent();
            this.member = member;
            BindData();
        }

        private void BindData()
        {
            memberIdLabel.Text = string.Empty; //member.Member_Id.ToString();
            AccountLable.Text = member.Account;
            nameTxtBox.Text = member.Name;
            passwordTextBox.Text = member.Password;
            EmailTextBox.Text = member.Email;
            PhoneTextBox.Text = member.Phone_Number;
            adressTextBox.Text = member.Address;

        }
      

        private void updateButton_Click(object sender, EventArgs e)
        {
            MemberVM eMember = new MemberVM()
            {
                Member_Id = member.Member_Id,
                Account = member.Account,
                Name = nameTxtBox.Text,
                Password = passwordTextBox.Text,
                Email = EmailTextBox.Text,
                Phone_Number = PhoneTextBox.Text,
                Address = adressTextBox.Text
            };

			Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
			{
				{"Name", nameTxtBox},
				{"Account", AccountLable},
				{"Password", passwordTextBox},
				{"Email", EmailTextBox},
				{"Phone_Number", PhoneTextBox},
				{"Address", adressTextBox},
			};

			bool isValid = ValidationHelper.Validate(eMember, map, errorProvider1);
			if (!isValid) return;

			try
            {
                new UserService().Update(eMember);
                
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗，原因: " + ex.Message, "錯誤訊息");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.updateButton_Click(sender, e);
            }
        }
    }
}
