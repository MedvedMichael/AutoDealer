namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class SearchRange
    {
        public int? From { get; set; }
        public int? To { get; set; }
    }
    public class SearchAnnouncementDto
    {
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? GenerationId { get; set; }
        public int? EngineId { get; set; }
        public int? GearboxId { get; set; }
        public int? EquipmentId { get; set; }
        public SearchRange? Year { get; set; }
        public SearchRange? Price { get; set; }

        public string? Color { get; set; }
        public string? City { get; set; }
        public SearchRange? OwnersCount { get; set; }
        public SearchRange? Mileage { get; set; }

    }
}