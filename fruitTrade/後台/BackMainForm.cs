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

namespace fruitTrade.後台
{
	public partial class BackMainForm : Form
	{
		private EmployeeIndexVM employee;
		public BackMainForm(EmployeeIndexVM _employee)
		{
			InitializeComponent();
			this.IsMdiContainer = true;
			this.employee = _employee;
		}

		

		private void BackMainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Owner.Show();
		}

		private void memberManagementBtn_Click(object sender, EventArgs e)
		{
			bool isFind = false;
			foreach (Form form in this.MdiChildren)
			{
				if (form.Name == "BMembersForm")
				{
					isFind = true;
					form.MdiParent = this;
					form.Focus();
				}
			}
			if (isFind == false)
			{
				var frm = new BMembersForm();
				frm.MdiParent = this;
				frm.Show();
			}

        }

		private void ProductManagemetButton_Click(object sender, EventArgs e)
		{
			bool isFind = false;
			foreach (Form form in this.MdiChildren)
			{
				if(form.Name == "BProductsForm")
				{
					isFind = true;
					form.MdiParent = this;
					form.Focus();
				}
			}
			if (isFind == false)
			{
				var frm = new BProductsForm();
				frm.MdiParent = this;
				frm.Show();
			}

        }

		private void orderManagementBtn_Click(object sender, EventArgs e)
		{
			bool isFind = false;
			foreach (Form form in this.MdiChildren)
			{
				if (form.Name == "BOrdersForm")
				{
					isFind = true;
					form.MdiParent = this;
					form.Focus();
				}
			}
			if (isFind == false)
			{
				var frm = new BOrdersForm(employee);
				frm.MdiParent = this;
				frm.Show();
			}
			
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
	}
}
