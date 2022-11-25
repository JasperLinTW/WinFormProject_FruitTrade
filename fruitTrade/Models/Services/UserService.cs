using fruitTrade.Models.ViewModels;
using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fruitTrade.Models.Services
{
	public class UserService
	{
		public MemberIndexVM[] GetMember(int id)
		{
			string sql = @"select * from Members where Member_Id =@id";

			var parameters = new SqlParameterBuilder()
							 .AddInt("id", id)
							 .Build();

			var dbhelper = new SqlDbHelper("default");
			return dbhelper.Select(sql, parameters)
					.AsEnumerable()
					.Select(row => ToMemberIndexVM(row))
					.ToArray();
		}
		public MemberIndexVM[] GetMember(string account)
		{
			string sql = @"select * from Members where Account =@Account";

			var parameters = new SqlParameterBuilder()
							 .AddNvarchar("Account",50,  account)
							 .Build();

			var dbhelper = new SqlDbHelper("default");
			return dbhelper.Select(sql, parameters)
					.AsEnumerable()
					.Select(row => ToMemberIndexVM(row))
					.ToArray();
		}
		public MemberIndexVM[] GetAllMember()
        {
            string sql = @"select * from Members";

            var dbhelper = new SqlDbHelper("default");
            return dbhelper.Select(sql, null)
                    .AsEnumerable()
                    .Select(row => ToMemberIndexVM(row))
                    .ToArray();
        }
		public EmployeeIndexVM[] GetEmployee(int id)
		{
			string sql = @"select * from Employees where Employee_Id =@id";

			var parameters = new SqlParameterBuilder()
							 .AddInt("id", id)
							 .Build();

			var dbhelper = new SqlDbHelper("default");
			return dbhelper.Select(sql, parameters)
					.AsEnumerable()
					.Select(row => ToEmployeeIndexVM(row))
					.ToArray();
		}
		public EmployeeIndexVM[] GetEmployee(string account)
		{
			string sql = @"select * from Employees where Account =@account";

			var parameters = new SqlParameterBuilder()
							 .AddNvarchar("Account", 50, account)
							 .Build();

			var dbhelper = new SqlDbHelper("default");
			var data = dbhelper.Select(sql, parameters)
					.AsEnumerable()
					.Select(row => ToEmployeeIndexVM(row))
					.ToArray();
			if (data.Length == 0)
			{
				return null;
			}

			// 將找到的一筆記錄由DataTable 轉換到 UserVM
			return data;
		}

		private EmployeeIndexVM ToEmployeeIndexVM(DataRow row)
        {
			return new EmployeeIndexVM()
			{
				Employee_Id = row.Field<int>("Employee_Id"),
				EmployeeName = row.Field<string>("EmployeeName"),
				Email = row.Field<string>("Email"),
				Account = row.Field<string>("Account"),
				Password = row.Field<string>("Password"),
				Phone_Number = row.Field<string>("Phone"),
			};
		}

        private MemberIndexVM ToMemberIndexVM(DataRow row)
		{
			return new MemberIndexVM()
			{
				Member_Id = row.Field<int>("Member_Id"),
				Name = row.Field<string>("Name"),
				Email = row.Field<string>("Email"),
				Account = row.Field<string>("Account"),
				Password = row.Field<string>("Password"),
				Phone_Number =row.Field<string>("Phone_Number"),
				Address = row.Field<string>("Address")
			};
		}
        public void Update(MemberVM member)
        {
            string sql = @"update Members 
set Name = @Name,
Password = @Password, 
Email = @Email, 
Phone_Number = @Phone_Number, 
Address= @Address
where Member_Id = @Id;";

            var parameters = new SqlParameterBuilder()
                .AddNvarchar("Name",50, member.Name)
                .AddNvarchar("Password", 50,member.Password)
                .AddNvarchar("Email",50 , member.Email)
                .AddNvarchar("Phone_Number",50, member.Phone_Number)
                .AddNvarchar("Address", 50, member.Address)
                .AddInt("Id", member.Member_Id)
                .Build();
            new SqlDbHelper("default").Update(sql, parameters);
        }

        public static ShoppingCartVM ToShoppingCart(DataRow row)
        {
            return new ShoppingCartVM()
            {
                Product_Id = row.Field<int>("Product_Id"),
                ProductName = row.Field<string>("ProductName"),
                Price = row.Field<int>("Price"),
                quantity = row.Field<int>("quantity")
            };
        }

		public bool Authenticate(LoginVM model, bool isMember)
		{
			if (isMember)
			{
				var mem = Get(model.Account);
				if (mem == null) return false; // 找不到符合的帳號

				return (mem.Password == model.Password);
			}
			else
			{
				var emp = GetEmployee(model.Account);
				if (emp == null) return false; // 找不到符合的帳號

				return (emp[0].Password == model.Password);
			}
			
		}
		public MemberIndexVM Get(string account)
		{
			string sql = $"SELECT * FROM Members WHERE Account=@Account";
			var parameters = new SqlParameterBuilder()
				.AddNvarchar("Account", 50, account)
				.Build();

			DataTable data = new SqlDbHelper("default").Select(sql, parameters);

			if (data.Rows.Count == 0)
			{
				return null;
			}

			// 將找到的一筆記錄由DataTable 轉換到 UserVM
			return ToMemberIndexVM(data.Rows[0]);
		}

		internal bool Create(MemberVM member)
		{
			bool isExists = MemberExists(member.Account);
			if (isExists)
			{
				MessageBox.Show("此帳號已存在");
				return false;
			}
			string sql = @"insert into Members([Name], Email, Account, [Password], Phone_Number, Address)
values(@Name, @Email, @Account, @Password, @Phone_Number, @Address)";

			var parameters = new SqlParameterBuilder()
				.AddNvarchar("Name", 50, member.Name)
				.AddNvarchar("Password", 50, member.Password)
				.AddNvarchar("Email", 50, member.Email)
				.AddNvarchar("Phone_Number", 50, member.Phone_Number)
				.AddNvarchar("Address", 50, member.Address)
				.AddNvarchar("Account", 50,member.Account)
				.Build();


			new SqlDbHelper("default").Insert(sql, parameters);
			return true;
		}
		private bool MemberExists(string account)
		{

			string sql = @"SELECT COUNT(*) AS count FROM Members WHERE [Account] = @account";

			var parameters = new SqlParameterBuilder()
				.AddNvarchar("account", 50, account)
				.Build();
			var data = new SqlDbHelper("default").Select(sql, parameters);
			return data.Rows[0].Field<int>("count") > 0;
		}
	}
}
