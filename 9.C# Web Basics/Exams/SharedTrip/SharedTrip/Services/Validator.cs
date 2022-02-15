using SharedTrip.Models.Trips;
using SharedTrip.Models.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.Username) || model.Username.Length < UsernameMinLength || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (string.IsNullOrEmpty(model.Email) || !Regex.IsMatch(model.Email, EmailRegularExpression))
            {
                errors.Add($"Email '{model.Email}' is not a valid e-mail address.");
            }

            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < PasswordMinLength || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.ConfirmPassword != model.Password)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }
     
        public ICollection<string> ValidateTrip(TripFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                errors.Add("Start point...");
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errors.Add("End point...");
            }

            if (string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                errors.Add("Departure time...");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > DescriptionMaxlength)
            {
                errors.Add("Description...");
            }

            if (model.Seats < SeatsMinValue || model.Seats > SeatsMaxValue)
            {
                errors.Add("Seats...");
            }

            return errors;
        }
    }
}
