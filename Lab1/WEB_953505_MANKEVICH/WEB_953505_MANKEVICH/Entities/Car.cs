namespace WEB_953505_MANKEVICH.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string ModelName { get; set; }
        public string ManufacturerName { get; set; }
        public string Image { get; set; }
        public int CarGroupId { get; set; }
        public CarGroup Group { get; set; }
    }
}