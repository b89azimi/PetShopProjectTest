namespace PetShopProject.UI.Models
{
    public partial record HomeProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public DateTime datetime { get; set; }
        public int productType { get; set; }
    }
}
