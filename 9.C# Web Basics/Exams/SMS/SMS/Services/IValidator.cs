using SMS.ViewModels;
using SMS.ViewModels.Carts;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormViewModel model);

        ICollection<string> ValidateProduct(ProductViewModel model);
    }
}
