using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fruitTrade.Models.ViewModels
{
	public class OrderVM
	{
		public int Order_ID { get; set; }
		public int Member_Id { get; set; }
		public int Handler_Id { get; set; }
		public DateTime OrderDate { get; set; }

		public string status { get; set; }
		public int TotalPrice { get; set; }

	}


	public class OrderDetailVM
	{
		public int Order_Id { get; set; }
		public int Product_Id { get; set; }
		public string ProductName { get; set; }
		public int Price { get; set; }
		public int quantity { get; set; }
		public int ItemCost { get; set; }
	}
    public class OrderDetailsVM
    {
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int quantity { get; set; }
        public int ItemCost { get; set; }
        public int TotalPrice { get; set; }
		public int Member_Id { get; set; }
		public string Address { get; set; }
		public string Status { get; set; }
    }

}



