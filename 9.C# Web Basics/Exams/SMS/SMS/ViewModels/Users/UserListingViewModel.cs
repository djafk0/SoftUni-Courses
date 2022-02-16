using System.Collections.Generic;

namespace SMS.ViewModels.Users
{
    public class UserListingViewModel
    {
        public string Username { get; set; }

        public IEnumerable<ProductListingViewModel> Products { get; set; }
    }
}
