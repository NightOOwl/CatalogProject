namespace lesson2.Models
{
    public class Product
    {
        /// <summary>
        /// Please do not use defoult constructor
        /// </summary>
        public Product()
        {
            Id = 0;
            Name = "Cosmic Cherry Whirls";

            Description = "Cosmic Cherry Whirls: A celestial fusion of ripe cherries twirled into an intergalactic dance," +
                          " encased in a cosmic glaze that unveils the sweet mysteries of distant star clusters. " +
                          "Indulge in a cosmic journey of flavor beyond earthly bounds.";

            Price = 15.7171M;

            Category = "Extraterrestrial";
        }

        public Product(int id,string name, string description, decimal price, string category)
        {
           Id=id;
            
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($" Name of product cannot be empty"); 
            }
            else
            {
                Name = name;
            }

            if (price < 0)
            {
                throw new ArgumentException($"Price of product cannot be negative");
            }

            else
            { 
                Price = price;
            }

               
            Category=category;
            Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public string Category { get; set; }

        public override string ToString()
        {
            return $"Product name: {Name}\nProduct Description: {Description}\nProduct price: {Price}\nProduct category: {Category}";
        }
    }
}

