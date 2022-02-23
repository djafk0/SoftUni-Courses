using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static FootballManager.Data.Constants;

namespace FootballManager.Services
{
    public class ValidationService : IValidationService
    {
        public ICollection<string> ValidateUser(RegisterFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < DefaultMinLength || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || 
                !Regex.IsMatch(model.Email, EmailRegularExpression) ||
                model.Email.Length < EmailMinLength ||
                model.Email.Length > EmailMaxLength)
            {
                errors.Add($"Email '{model.Email}' is not a valid e-mail address.");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < DefaultMinLength || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.ConfirmPassword != model.Password)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidatePlayer(PlayerFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.FullName) || model.FullName.Length < DefaultMinLength || model.FullName.Length > FullNameMaxLength)
            {
                errors.Add($"Fullname '{model.FullName}' is not valid. It must be between {DefaultMinLength} and {FullNameMaxLength} characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.ImageUrl))
            {
                errors.Add($"Image url '{model.ImageUrl}' is required.");
            }

            if (string.IsNullOrWhiteSpace(model.Position) || model.Position.Length < DefaultMinLength || model.Position.Length > DefaultMaxLength)
            {
                errors.Add($"Position '{model.Position}' is not valid. It must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Speed) || model.Speed.Length < ByteMin || model.Speed.Length > ByteMax)
            {
                errors.Add($"Speed '{model.Speed}' is not valid. It must be between {ByteMin} and {ByteMax}.");
            }

            if (string.IsNullOrWhiteSpace(model.Endurance) || model.Endurance.Length < ByteMin || model.Endurance.Length > ByteMax)
            {
                errors.Add($"Endurance '{model.Endurance}' is not valid. It must be between {ByteMin} and {ByteMax}.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description '{model.Description}' is not valid. It must be less than {DescriptionMaxLength} characters long.");
            }

            return errors;
        }
    }
}
