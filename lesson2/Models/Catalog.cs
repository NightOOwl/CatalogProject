using Microsoft.AspNetCore.Components.Forms;

namespace lesson2.Models
{
    public class Catalog
    {
        public delegate void Alert(Product product);
        public event Alert justCrated;

        private List<Product> _products;

        public void Initilize() 
        {
            var products = new List<Product>();
            products.Add(new Product(1, "Galactic Stardust Tea", "A blend of rare herbs harvested from distant celestial gardens, creating a soothing tea with a hint of interstellar magic.", 12.99M, "Beverages"));
            products.Add(new Product(2,"Zero-G Energy Bars", "Nutrient-rich bars engineered for space travelers, providing sustained energy and a taste of cosmic flavors.", 8.49M, "Snacks"));
            products.Add(new Product(3,"Quantum Warp Drive Oil", "Revolutionary propulsion system oil extracted from the essence of hyperdimensional nebulae, ensuring a smoother and faster warp travel.", 99.99M, "Space Travel"));
            products.Add(new Product(4,"Asteroid Ice Cream Delight", "Indulge in the crunchiness of real asteroid fragments blended into a creamy ice cream, offering a unique and cosmic dessert experience.", 15.99M, "Desserts"));
            products.Add(new Product(5,"Nebula Glow-in-the-Dark Paint", "Illuminate your surroundings with the ethereal glow of distant nebulae. Perfect for cosmic-themed art projects.", 24.99M, "Art Supplies"));
            products.Add(new Product(6,"Interstellar Holographic Projector", "Transform your living space with breathtaking holographic projections of galaxies, stars, and cosmic phenomena.", 199.99M, "Electronics"));
            products.Add(new Product(7,"Meteorite-infused Skincare Kit", "Harness the power of meteorites to rejuvenate your skin. This kit includes cosmic dust masks and meteorite-infused creams.", 49.99M, "Beauty"));
            products.Add(new Product(8,"Galactic Explorer's Telescope", "Embark on a cosmic journey with this advanced telescope, offering clear views of distant planets, nebulae, and galaxies.", 299.99M, "Outdoor Equipment"));
            products.Add(new Product(9,"Celestial Harmony Soundtrack", "Immerse yourself in the harmonious melodies inspired by the symphony of the cosmos. A soundtrack for cosmic relaxation.", 19.99M, "Music"));
            products.Add(new Product(10,"Space-Time Distortion Watch", "Experience time in a new dimension with this stylish watch that bends the fabric of space-time, combining functionality and elegance.", 129.99M, "Fashion"));
            _products = products;
        }
        public void AddProduct(Product product)
        {
            int newId = 1;
            if (_products.LastOrDefault() is not null)
                newId = _products.LastOrDefault().Id + 1;
            product.Id = newId;
            _products.Add(product);

            if (justCrated is not null)
                justCrated(product);
            
        }

        public List<Product> GetProducts() 
        {
            return _products; 
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public bool UpdateProduct(int id, Product updatedProduct) 
        {
            Product productToUpdate = _products.FirstOrDefault(p => p.Id == id);
            if (productToUpdate != null)
            {
                if (!string.IsNullOrWhiteSpace(updatedProduct.Name))
                    productToUpdate.Name = updatedProduct.Name;

                if (!string.IsNullOrWhiteSpace(updatedProduct.Description))
                    productToUpdate.Description = updatedProduct.Description;

                if (updatedProduct.Price > 0)
                    productToUpdate.Price = updatedProduct.Price;

                if (!string.IsNullOrWhiteSpace(updatedProduct.Category))
                    productToUpdate.Category = updatedProduct.Category;
                return true;
            }
            return false;                   
        }
        public bool DeleteProduct(int id)
        {
            Product productToDelete = _products.FirstOrDefault(p => p.Id == id);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
                return true;
            }
            else  return false; 
        }
    }
}

