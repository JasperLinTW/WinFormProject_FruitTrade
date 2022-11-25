using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fruitTrade.Models.ViewModels
{
    public class MemberIndexVM
    {
        public int Member_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string  Password { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }

    }
	public class MemberVM
	{

		public int Member_Id { get; set; }
		[Required(ErrorMessage = "姓名必填")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Email必填")]
		public string Email { get; set; }
		[Required(ErrorMessage = "帳號必填")]
		public string Account { get; set; }
		[Required(ErrorMessage = "密碼必填")]
		public string Password { get; set; }
		[Required(ErrorMessage = "電話必填")]
		public string Phone_Number { get; set; }
		[Required(ErrorMessage = "地址必填")]
		public string Address { get; set; }

	}

	public class EmployeeIndexVM
    {
		public int Employee_Id { get; set; }
		public string EmployeeName { get; set; }
		public string Email { get; set; }
		public string Account { get; set; }
		public string Password { get; set; }
		public string Phone_Number { get; set; }
		public string Address { get; set; }
	}
}
