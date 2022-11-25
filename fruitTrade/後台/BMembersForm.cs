using fruitTrade.Models.Services;
using fruitTrade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fruitTrade.Models.ViewModels;
using fruitTrade.後台;

namespace fruitTrade
{
    public partial class BMembersForm : Form
    {
        private MemberIndexVM[] members = new MemberIndexVM[] {};
        public BMembersForm()
        {
            InitializeComponent();
            DisplayMembers();
        }
        private void DisplayMembers()
        {

            members = new UserService().GetAllMember().ToArray();

            BindData(members);


        }

        private void BindData(MemberIndexVM[] members)
        {
            MembersGridView.DataSource = members;
        }

        private void MembersGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;

            MemberIndexVM row = this.members[rowIndex];

            var frm = new EditMemberForm(row);
            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayMembers();
            }

        }

        private void BMembersForm_Load(object sender, EventArgs e)
        {
			if (MembersGridView.Rows.Count > 0)
			{
				MembersGridView.Rows[0].Selected = false;
			}
		}
    }
}
