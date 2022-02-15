using SharedTrip.Models.Trips;
using SharedTrip.Models.Users;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidateTrip(TripFormModel model);
    }
}
