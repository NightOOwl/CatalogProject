namespace lesson2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }

        public Product(int id, string name, string? description, decimal price, string? category)
        {
            if (id > 0)
            {
                Id = id;
            }
            else
            {
                throw new ArgumentException($"Id have to be possitive. {nameof(id)} was: {id}");
            }

            if (price < 0)
            {
                throw new ArgumentException($"Price of product cannot be negative. {nameof(price)} was: {price}");
            }
            else
            {
                Price = price;
            }

            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            Name = name;

            Category = category;
            Description = description;
        }

        public override string ToString()
        {
            return $"Product name: {Name}\nProduct Description: {Description}\nProduct price: {Price}\nProduct category: {Category}";
        }
    }
}

