namespace CarShop.ViewModels.Issues
{
    using System.Collections.Generic;

    public class CarIssuesViewModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public bool IsUserMechanic { get; set; }

        public IEnumerable<IssueViewModel> Issues { get; set; }
    }
}
