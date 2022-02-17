using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class DataConstants
    {
        public const int DefaultMaxLength = 20;
        public const int IdMaxLength = 36;

        public const int UsernameMinLength = 4;
        public const int PasswordMinLength = 5;
        public const int PasswordHashedMaxLength = 64;
        public const string EmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string UserTypeClient = "Client";
        public const string UserTypeMechanic = "Mechanic";

        public const int ModelMinLength = 5;
        public const int PlateNumberMaxLength = 8;
        public const string CarPlateNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2100;

        public const int DescriptionMinLength = 5;
    }
}
