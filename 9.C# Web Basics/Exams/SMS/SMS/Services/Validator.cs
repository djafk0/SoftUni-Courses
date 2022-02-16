using SMS.ViewModels;
using SMS.ViewModels.Carts;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using static SMS.Data.DataConstants;

namespace SMS.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterFormViewModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.Username) || model.Username.Length < UsernameMinLength || model.Username.Length > DefaultMaxLength)
            {
                errors.Add("Username...");
            }

            if (string.IsNullOrEmpty(model.Email) || !Regex.IsMatch(model.Email, EmailRegularExpression))
            {
                errors.Add("Email...");
            }

            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add("Password...");
            }

            if (model.ConfirmPassword != model.Password)
            {
                errors.Add("Password and confirm password...");
            }

            return errors;
        }

        public ICollection<string> ValidateProduct(ProductViewModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < ProductNameMinLength || model.Name.Length > DefaultMaxLength)
            {
                errors.Add("Name...");
            }

            if (string.IsNullOrEmpty(model.Price.ToString()) || model.Price < ProductPriceMinValue || model.Price > ProductPriceMaxValue)
            {
                errors.Add("Price...");
            }

            return errors;
        }
    }
}
