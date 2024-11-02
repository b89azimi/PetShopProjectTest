using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopProject.Api.Data
{
    public class Product
    {
        public Product()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public DateTime datetime { get; set; }
        public ProductType productType { get; set; }

    }
}
