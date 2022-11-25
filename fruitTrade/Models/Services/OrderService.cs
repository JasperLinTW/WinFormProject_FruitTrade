using fruitTrade.Models.ViewModels;
using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fruitTrade.Models.Services
{
	public class OrderService
	{
		public void SaveToOrder(ShoppingCartVM[] cartproducts, int Member_Id)
		{
			int total = GetTotal(cartproducts);
			string sql = @"insert into Orders(Member_Id, TotalPrice) values(@Member_Id, @TotalPrice)
select IDENT_CURRENT('Orders') as Current_OrderId";
			var parameters = new SqlParameterBuilder()
							.AddInt("Member_Id", Member_Id)
							.AddInt("TotalPrice", total)
							.Build();
			var current = new SqlDbHelper("default").Select(sql, parameters);
			int current_orderId = Convert.ToInt32(current.Rows[0]["Current_OrderId"]);

			SaveToOrderDetail(cartproducts, current_orderId);

		}
		private void SaveToOrderDetail(ShoppingCartVM[] cartproducts, int Order_Id)
		{
			foreach (var item in cartproducts)
			{

				string sql = @"insert into OrderDetail(Order_Id, Product_Id,Product_Name, Price, Quantity)
values(@Order_Id, @Product_Id,@Product_Name, @Price, @Quantity)";
				var parameters = new SqlParameterBuilder()
								.AddInt("Order_Id", Order_Id)
								.AddInt("Product_Id", item.Product_Id)
								.AddNvarchar("Product_Name",50,item.ProductName)
								.AddInt("Price", item.Price)
								.AddInt("Quantity", item.quantity)
								.Build();
				new SqlDbHelper("default").Insert(sql, parameters);
			}

		}
		public int GetTotal(ShoppingCartVM[] cartproducts)
		{
			int total = 0;
			foreach (var item in cartproducts)
			{
				total += item.Price * item.quantity;
			}
			return total;
		}
		internal void CleanCart(ShoppingCartVM[] cartproducts, int memberId)//todo.., int Member_Id)
		{
			foreach (var item in cartproducts)
			{
				new ProductsService().Delete(item.Product_Id, memberId);
			}
		}

		internal OrderVM[] GetOrders(int id)
		{
			string sql = @"select * from Orders where Member_Id =@id";
			var parameters = new SqlParameterBuilder()
							.AddInt("id", id)
							.Build();
			return new SqlDbHelper("default").Select(sql, parameters)
						.AsEnumerable()
						.Select(row => ToOderVM(row))
						.ToArray();
		}
        internal OrderVM[] GetAllOrders()
        {
            string sql = @"select * from Orders";

            return new SqlDbHelper("default").Select(sql, null)
                        .AsEnumerable()
                        .Select(row => ToOderVM(row))
                        .ToArray();
        }

        private OrderVM ToOderVM(DataRow row)
		{
			return new OrderVM()
			{
				Order_ID = row.Field<int>("Order_ID"),
				Member_Id = row.Field<int>("Member_Id"),
				Handler_Id= row.Field<int>("Handler_Id"),
				OrderDate = row.Field<DateTime>("OrderDate"),
				status = row.Field<string>("status"),
				TotalPrice = row.Field<int>("TotalPrice")
			};
		}

        public OrderDetailsVM[] GetOrderDetails(int OrderId)
        {
            string sql = @"select * From OrderDetail OD 
							join [Orders] O on OD.[Order_Id] = O.[Order_Id]
							WHERE O.[Order_Id] =@Id";
            var parameters = new SqlParameterBuilder()
							.AddInt("Id", OrderId)
                            .Build();
            return new SqlDbHelper("default").Select(sql, parameters)
                        .AsEnumerable()
                        .Select(row => ToOrderDetailsVM(row))
                        .ToArray();
		
        }
        internal OrderDetailsVM ToOrderDetailsVM(DataRow row)
        {
            var vm = new OrderDetailsVM()
            {
                Member_Id = row.Field<int>("Member_Id"),
                Order_Id = row.Field<int>("Order_Id"),
                OrderDate = row.Field<DateTime>("OrderDate"),
                Product_Id = row.Field<int>("Product_Id"),
                ProductName = row.Field<string>("Product_Name"),
                Price = row.Field<int>("Price"),
                quantity = row.Field<int>("quantity"),
                ItemCost = row.Field<int>("Price") * row.Field<int>("quantity"),
				Status = row.Field<string>("Status") == null ? "未處理": row.Field<string>("Status"),
				TotalPrice =row.Field<int>("TotalPrice")
				
            };
			return vm;
        }
        public void Update(int orderId, int employeeId, string status)
        {
            string sql = @"update Orders set Handler_id =@employeeId, Status =@Status  where Order_Id =@OrderId";

            var parameters = new SqlParameterBuilder()
                .AddInt("employeeId", employeeId)
				.AddNvarchar("Status",50, status)
                .AddInt("OrderId", orderId)
                .Build();
            new SqlDbHelper("default").Update(sql, parameters);
        }
    }
}
