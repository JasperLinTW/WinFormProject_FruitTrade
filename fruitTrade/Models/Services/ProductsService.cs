using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using fruitTrade.Models.ViewModels;
using fruitTrade.Infra;

namespace fruitTrade.Models.Services
{
    public class ProductsService
    {
        public List<ProductIndexVM> GetAll(string keyword)
        {
            string sql = @"select * from Products ";

            SqlParameter[] parameters = new SqlParameter[] { };

            if (string.IsNullOrEmpty(keyword)== false)
            {
                keyword = $"%{keyword}%";
                sql += $"where ProductName like @keyword ";
                parameters = new SqlParameterBuilder()
                                .AddNvarchar("keyword", 50, keyword )
                                .Build();
            }


            //sql += "ORDER BY Products_Id;";


            var dbhelper = new SqlDbHelper("default");
            return dbhelper.Select(sql, parameters)
                    .AsEnumerable()
                    .Select(row => ParseToProductIndexVM(row))
                    .ToList();
        }
        public List<ShoppingCartVM> GetAllCart(int id)
        {
            string sql = @"select S.Product_Id AS Product_Id, ProductName, Price, Quantity
                            from ShoppingCart S
                            join Products P ON P.Product_Id = S.Product_Id 
                            where Member_Id = @id 
                            Order by Product_Id";

            var parameters = new SqlParameterBuilder()
                             .AddInt("id", id)
                             .Build();

            var dbhelper = new SqlDbHelper("default");
            return dbhelper.Select(sql, parameters)
                    .AsEnumerable()
                    .Select(row => ToShoppingCartVM(row))
                    .ToList();
        }

        public ShoppingCartVM ToShoppingCartVM(DataRow row)
        {
            return new ShoppingCartVM
            {         
                Product_Id = row.Field<int>("Product_Id"),
                ProductName = row.Field<string>("ProductName"),
                Price = row.Field<int>("Price"),
                quantity = row.Field<int>("Quantity"),
                ItemCost = row.Field<int>("Price") * row.Field<int>("Quantity")
                
			};
        }

        private ProductIndexVM ParseToProductIndexVM(DataRow row)
        {
            return new ProductIndexVM
            {
                
                Product_Id = row.Field<int>("Product_Id"),
                ProductName = row.Field<string>("ProductName"),
                Price = row.Field<int>("Price"),
                inventory = row.Field<int>("inventory"),
          
            };
        }
        public ProductVM ToProductVM(DataRow row)
        {
            return new ProductVM()
            {
                Product_Id = row.Field<int>("Product_Id"),
                ProductName = row.Field<string>("ProductName"),
                Price = row.Field<int>("Price"),
                inventory = row.Field<int>("inventory")
            };
        }

        public bool CreateCartItem(ShoppingCartVM cartmodel)
        {
            bool isExists = AccountExists(cartmodel.Product_Id, cartmodel.Member_Id);
			bool isInStock = ValidationHelper.IsInStock(cartmodel.Product_Id, cartmodel.quantity);
			
            if (isExists)
            {
                MessageBox.Show("您的商品已在購物車，確定要再次新增嗎?","提示");

                int exitQuantity = getCartQuantity(cartmodel.Product_Id, cartmodel.Member_Id);
                cartmodel.quantity += exitQuantity;


                isInStock = ValidationHelper.IsInStock(cartmodel.Product_Id, cartmodel.quantity);
                if (isInStock == false)
                {
                    MessageBox.Show("庫存不足請重新輸入","加入購物車失敗");
                    return false;
                }
                else
                {
                    UpdateCart(cartmodel);
                    return true;
                }
            }
			
			if (isInStock == false)
			{
				MessageBox.Show("庫存不足請重新輸入","加入購物車失敗");
				return false;
			}

			string sql = @"insert into ShoppingCart(Product_Id, Member_Id, Quantity)
values(@Product_Id, @Member_Id, @Quantity)";

            var parameters = new SqlParameterBuilder()
                .AddInt("Product_Id", cartmodel.Product_Id)
                .AddInt("Member_Id", cartmodel.Member_Id)
                .AddInt("Quantity", cartmodel.quantity)
                .Build();
            
            
            new SqlDbHelper("default").Insert(sql, parameters);
            return true;
        }

        public bool AccountExists(int id, int Member_Id)
        {
            string sql = @"SELECT COUNT(*) AS count FROM ShoppingCart WHERE Product_Id = @Id and Member_Id = @Member_Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .AddInt("Member_Id", Member_Id)
                .Build();
            var data = new SqlDbHelper("default").Select(sql, parameters);
            return data.Rows[0].Field<int>("count") > 0;
        }
        public int getCartQuantity(int id , int Member_Id)
        {
            string sql = @"SELECT * FROM ShoppingCart WHERE Product_Id = @Id and Member_Id = @Member_Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
				.AddInt("Member_Id", Member_Id)
				.Build();
            var data = new SqlDbHelper("default").Select(sql, parameters);
            return data.Rows[0].Field<int>("quantity");
        }
         
        
        public void UpdateCart(ShoppingCartVM cartmodel)
        {
            string sql = @"update ShoppingCart set Quantity = @Quantity 
                            WHERE Product_Id = @Product_Id and Member_Id =@Member_Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Quantity", cartmodel.quantity)
                .AddInt("Product_Id", cartmodel.Product_Id)
                .AddInt("Member_Id", cartmodel.Member_Id)
                .Build();
            new SqlDbHelper("default").Update(sql, parameters);
        }

        public static ShoppingCartVM ToShoppingCart(DataRow row)
        {
            return new ShoppingCartVM()
            {
                Member_Id = row.Field<int>("Member_Id"),
                Product_Id = row.Field<int>("Product_Id"),
                ProductName = row.Field<string>("ProductName"),
                Price = row.Field<int>("Price"),
                quantity = row.Field<int>("quantity")
            };
        }


        public void Delete(int id, int member_Id)
        {

            string sql = @"DELETE FROM ShoppingCart WHERE Product_Id = @Product_Id and Member_Id = @Member_Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Product_Id", id)
				.AddInt("member_Id", member_Id)
				.Build();
            new SqlDbHelper("default").Delete(sql, parameters);
        }

        internal void UpdateInventory(ShoppingCartVM[] cartproducts)
        {
            string sql = @"update Products set inventory = @inventory 
                            WHERE Product_Id = @Product_Id";
            foreach (var item in cartproducts)
            {
                int inventory = GetInventory(item.Product_Id);
                var parameters = new SqlParameterBuilder()
                .AddInt("inventory", inventory - item.quantity)
                .AddInt("Product_Id", item.Product_Id)
                .Build();
                new SqlDbHelper("default").Update(sql, parameters);
            }
            
        }
        private int GetInventory(int id)
        {
            string sql = @"SELECT * FROM Products WHERE Product_Id = @Id";

            var parameters = new SqlParameterBuilder()
                .AddInt("Id", id)
                .Build();
            var data = new SqlDbHelper("default").Select(sql, parameters);
            return data.Rows[0].Field<int>("Inventory");
        }

        internal DataTable GetProduct(int id)
        {
            string sql = @"select * from Products where Product_Id = @Id";
            var parameters = new SqlParameterBuilder()
                            .AddInt("id", id)
                            .Build();
            DataTable data = new SqlDbHelper("default").Select(sql, parameters);
            return data;
        }

        public void Create(ProductVM newProduct)
        {
			bool isExists = ProductExists(newProduct.ProductName);
			if (isExists)
			{
				MessageBox.Show("此商品已存在","新增失敗");
				return;
			}
			string sql = @"insert into Products(ProductName, Price, Inventory)
values(@ProductName, @Price, @Inventory)";

			var parameters = new SqlParameterBuilder()
				.AddNvarchar("ProductName", 50, newProduct.ProductName)
				.AddInt("Price", newProduct.Price)
				.AddInt("Inventory", newProduct.inventory)
				.Build();


			new SqlDbHelper("default").Insert(sql, parameters);
		}
		private bool ProductExists(string productName)
		{

			string sql = @"SELECT COUNT(*) AS count FROM Products WHERE ProductName = @ProductName";

			var parameters = new SqlParameterBuilder()
				.AddNvarchar("ProductName", 50,productName)
				.Build();
			var data = new SqlDbHelper("default").Select(sql, parameters);
			return data.Rows[0].Field<int>("count") > 0;
		}
		private bool EditProductExists(string productName, int productId)
		{

			string sql = @"SELECT COUNT(*) AS count FROM Products WHERE ProductName = @ProductName and Product_Id != @Product_Id";

			var parameters = new SqlParameterBuilder()
				.AddNvarchar("ProductName", 50, productName)
                .AddInt("Product_Id", productId)
				.Build();
			var data = new SqlDbHelper("default").Select(sql, parameters);
			return data.Rows[0].Field<int>("count") > 0;
		}

		internal bool Update(ProductVM editProduct)
        {
            bool isExit = EditProductExists(editProduct.ProductName, editProduct.Product_Id);
            if (isExit)
            {
                MessageBox.Show("此商品已存在");
                return false;
            }

            string sql = @"update Products set ProductName = @ProductName, Price = @Price, Inventory=  @inventory 
                            WHERE Product_Id = @Product_Id";
			var parameters = new SqlParameterBuilder()
                .AddNvarchar("ProductName",50,editProduct.ProductName)
                .AddInt("Price", editProduct.Price)
				.AddInt("Inventory", editProduct.inventory)
				.AddInt("Product_Id", editProduct.Product_Id)
				.Build();
				new SqlDbHelper("default").Update(sql, parameters);
            return true;
		}

    }
}
