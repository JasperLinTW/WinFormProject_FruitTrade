using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fruitTrade.Models
{
    public class ProductIndexVM
    {
        /// <summary>
        /// 供ProductsForm使用
        /// </summary>
        public int Product_Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string picture { get; set; }
        public int inventory { get; set; }

    }
    public class ProductVM
    {
        /// <summary>
        /// 供create、Edit使用
        /// </summary>
        public int Product_Id { get; set; }
		[Required(ErrorMessage = "商品名必填")]
		public string ProductName { get; set; }
		[Required(ErrorMessage = "價格必填")]
		public int Price { get; set; }
        public string picture { get; set; }
		[Required(ErrorMessage = "數量必填")]
		public int inventory { get; set; }

    }
    public class ShoppingCartVM
    {
        /// <summary>
        /// 供create、Edit使用
        /// </summary>
        public int Product_Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        [Required(ErrorMessage = "數量必填")]
        public int quantity { get; set; }
        public int ItemCost { get; set; }
        public int Member_Id { get; set; }

    }
}
