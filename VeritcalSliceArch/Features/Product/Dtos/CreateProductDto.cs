namespace VeritcalSliceArch.Features.Product.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
