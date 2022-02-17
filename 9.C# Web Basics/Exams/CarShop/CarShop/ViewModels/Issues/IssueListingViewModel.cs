using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class IssueListingViewModel
    {
        public string Id { get; init; }

        public string Description { get; init; }

        public bool IsFixed { get; init; }

        public string IsFixedInformation { get; init; }
    }
}
