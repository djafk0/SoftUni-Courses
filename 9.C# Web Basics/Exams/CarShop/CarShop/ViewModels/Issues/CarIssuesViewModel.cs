using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class CarIssuesViewModel
    {
        public string Id { get; init; }

        public bool UserIsMechanic { get; init; }

        public string Model { get; init; }

        public int Year { get; init; }

        public IEnumerable<IssueListingViewModel> Issues { get; init; }
    }
}
