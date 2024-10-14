using VeritcalSliceArch.Domain.Common;

namespace VeritcalSliceArch.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
