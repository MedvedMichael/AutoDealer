namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class SearchRange
    {
        public int? From { get; set; }
        public int? To { get; set; }
    }
    public class SearchAnnouncementDto
    {
        public int? Brand { get; set; }
        public List<int>? Models { get; set; }
        public List<int>? Generations { get; set; }
        public List<int>? Engines { get; set; }
        public List<int>? Gearboxes { get; set; }
        public List<int>? Equipments { get; set; }
        public SearchRange? Year { get; set; }
        public SearchRange? Price { get; set; }

        public string? Color { get; set; }
        public string? City { get; set; }
        public SearchRange? OwnersCount { get; set; }
        public SearchRange? Mileage { get; set; }

    }
}