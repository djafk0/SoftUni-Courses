namespace CarShop.ViewModels.Cars
{
    public class CarListingViewModel
    {
        public string Id { get; set; }

        public string PlateNumber { get; set; }

        public string Model { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }

        public string PictureUrl { get; set; }

        public int Year { get; set; }
    }
}
