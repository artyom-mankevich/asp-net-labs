using System.Collections.Generic;

namespace WEB_953505_MANKEVICH.Entities
{
    public class CarGroup
    {
        public int CarGroupId { get; set; }
        public string GroupName { get; set; }
        public List<Car> Cars { get; set; }
    }
}