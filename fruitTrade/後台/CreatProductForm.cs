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
using System.Xml;
using fruitTrade.Infra;

namespace fruitTrade.後台
{
	public partial class CreatProductForm : Form
	{
		public CreatProductForm()
		{
			InitializeComponent();
		}

		private void CreatProductForm_Load(object sender, EventArgs e)
		{

		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			bool isInt = uint.TryParse(InventoryTxtBx.Text, out uint inventory);
			bool isIntPrice = uint.TryParse(PriceTxtbx.Text, out uint price);
			if (isInt == false || inventory==0) { MessageBox.Show(("您輸入的數量非正整數")); return; } ;
			if (isIntPrice == false || price == 0){MessageBox.Show(("您輸入的價格非正整數"));return; }

			var newproduct = new ProductVM()
			{
				ProductName = ProductNameTxtBx.Text,
				Price = (int)price,
				inventory = (int)inventory
			};
			Dictionary<string, Control> map = new Dictionary<string, Control>(StringComparer.CurrentCultureIgnoreCase)
			{
				{"ProductName", ProductNameTxtBx},
				{"Price", PriceTxtbx},
				{"inventory", InventoryTxtBx}
			};

			bool isValid = ValidationHelper.Validate(newproduct, map, errorProvider1);
			if (!isValid) return;

			try
			{
				new ProductsService().Create(newproduct);
				this.DialogResult = DialogResult.OK;
			}
			catch(Exception ex)
			{
				MessageBox.Show("新增失敗，原因:" + ex.Message + "錯誤訊息");
			};
		}

		private void ProductNameTxtBx_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                this.SaveBtn_Click(sender, e);
            }
        }
	}
}
