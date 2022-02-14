namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel user);

        ICollection<string> ValidateTrip(AddTripFormModel trip);
    }
}
