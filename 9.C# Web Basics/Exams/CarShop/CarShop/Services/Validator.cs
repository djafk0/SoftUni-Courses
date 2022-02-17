using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using CarShop.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static CarShop.Data.DataConstants;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterFormViewModel user)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(user.Username) || user.Username.Length < UsernameMinLength || user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (string.IsNullOrEmpty(user.Email) || !Regex.IsMatch(user.Email, EmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }
            
            if (string.IsNullOrEmpty(user.Password) || user.Password.Length < PasswordMinLength || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {DefaultMaxLength} characters long.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            if (user.UserType != UserTypeClient && user.UserType != UserTypeMechanic)
            {
                errors.Add($"The user can be either a '{UserTypeClient}' or a '{UserTypeMechanic}'.");
            }

            return errors;
        }

        public ICollection<string> ValidateCar(AddCarFormModel car)
        {
            var errors = new List<string>();

            if (car.Model == null || car.Model.Length < ModelMinLength || car.Model.Length > DefaultMaxLength)
            {
                errors.Add($"Model '{car.Model}' is not valid. It must be between {ModelMinLength} and {DefaultMaxLength} characters long.");
            }

            if (car.Year < CarYearMinValue || car.Year > CarYearMaxValue)
            {
                errors.Add($"Year '{car.Year}' is not valid. It must be between {CarYearMinValue} and {CarYearMaxValue}.");
            }

            if (car.Image == null || !Uri.IsWellFormedUriString(car.Image, UriKind.Absolute))
            {
                errors.Add($"Image '{car.Image}' is not valid. It must be a valid URL.");
            }

            if (car.PlateNumber == null || !Regex.IsMatch(car.PlateNumber, CarPlateNumberRegularExpression))
            {
                errors.Add($"Plate number '{car.PlateNumber}' is not valid. It should be in 'XX0000XX' format.");
            }

            return errors;
        }

        public ICollection<string> ValidateIssue(AddIssueFormModel issue)
        {
            var errors = new List<string>();

            if (issue.CarId == null)
            {
                errors.Add($"Car ID cannot be empty.");
            }

            if (issue.Description.Length < DescriptionMinLength)
            {
                errors.Add($"Description '{issue.Description}' is not valid. It must have more than {DescriptionMinLength} characters.");
            }

            return errors;
        }
    }
}
