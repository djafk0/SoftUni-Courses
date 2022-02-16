using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 36;
        public const int DefaultMaxLength = 20;

        public const int UsernameMinLength = 5;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;
        public const int PasswordHashedMaxLength = 64;
        public const string EmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int ProductNameMinLength = 4;
        public const decimal ProductPriceMinValue = 0.05M;
        public const decimal ProductPriceMaxValue = 1000M;
    }
}
