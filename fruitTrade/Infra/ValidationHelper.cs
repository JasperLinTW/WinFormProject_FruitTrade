using fruitTrade.Models;
using fruitTrade.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fruitTrade.Infra
{
    public class ValidationHelper
    {
        public static bool Validate<T>(T model, Dictionary<string, Control> map, ErrorProvider errorProvider)
        {
            ValidationContext context = new ValidationContext(model, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            errorProvider.Clear();
            bool validateAllProperties = true;
            bool isValid = Validator.TryValidateObject(model, context, errors, validateAllProperties);
            if (!isValid)
            {
                DisplayErrorsByErrorProvider(errors, map, errorProvider);
            }
            return isValid;
        }

        public static void DisplayErrorsByErrorProvider(List<ValidationResult> errors, Dictionary<string, Control> map, ErrorProvider errorProvider)
        {

            errorProvider.Clear();
            foreach (ValidationResult error in errors)
            {
                string propName = error.MemberNames.FirstOrDefault();
                if (map.TryGetValue(propName, out Control ctrl))
                {
                    errorProvider.SetError(ctrl, error.ErrorMessage);

                }
            }
        }
        public static bool IsInStock(int productId, int quantity)
        {
            var product = new ProductsService().GetProduct(productId);
            int inventory = product.Rows[0].Field<int>("Inventory");
            return ( inventory >= quantity );
        }
        
    }
}
