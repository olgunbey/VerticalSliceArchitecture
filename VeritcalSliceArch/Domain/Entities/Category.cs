using VeritcalSliceArch.Domain.Common;

namespace VeritcalSliceArch.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
