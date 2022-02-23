using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System.Collections.Generic;

namespace FootballManager.Services
{
    public interface IValidationService
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidatePlayer(PlayerFormModel model);
    }
}
