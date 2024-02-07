using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Immutable;

namespace lesson2.Models
{
    public class Catalog
    {
        public delegate void Alert(Product product);
        public event Alert ProductHasBeenAdded;

        private List<Product> _products; 
        public Catalog(bool baseTemplate = false)
        {
            if (baseTemplate)
            {
                _products = new(_initializationList);
            }
            else
            {
                _products = new List<Product>();
            }
        }

        private static List<Product> _initializationList = new List<Product>
            {
                new Product(1, "Galactic Stardust Tea", "A blend of rare herbs harvested from distant celestial gardens, creating a soothing tea with a hint of interstellar magic.", 12.99M, "Beverages"),
                new Product(2, "Zero-G Energy Bars", "Nutrient-rich bars engineered for space travelers, providing sustained energy and a taste of cosmic flavors.", 8.49M, "Snacks"),
                new Product(3, "Quantum Warp Drive Oil", "Revolutionary propulsion system oil extracted from the essence of hyperdimensional nebulae, ensuring a smoother and faster warp travel.", 99.99M, "Space Travel"),
                new Product(4, "Asteroid Ice Cream Delight", "Indulge in the crunchiness of real asteroid fragments blended into a creamy ice cream, offering a unique and cosmic dessert experience.", 15.99M, "Desserts"),
                new Product(5, "Nebula Glow-in-the-Dark Paint", "Illuminate your surroundings with the ethereal glow of distant nebulae. Perfect for cosmic-themed art projects.", 24.99M, "Art Supplies"),
                new Product(6, "Interstellar Holographic Projector", "Transform your living space with breathtaking holographic projections of galaxies, stars, and cosmic phenomena.", 199.99M, "Electronics"),
                new Product(7, "Meteorite-infused Skincare Kit", "Harness the power of meteorites to rejuvenate your skin. This kit includes cosmic dust masks and meteorite-infused creams.", 49.99M, "Beauty"),
                new Product(8, "Galactic Explorer's Telescope", "Embark on a cosmic journey with this advanced telescope, offering clear views of distant planets, nebulae, and galaxies.", 299.99M, "Outdoor Equipment"),
                new Product(9, "Celestial Harmony Soundtrack", "Immerse yourself in the harmonious melodies inspired by the symphony of the cosmos. A soundtrack for cosmic relaxation.", 19.99M, "Music"),
                new Product(10, "Space-Time Distortion Watch", "Experience time in a new dimension with this stylish watch that bends the fabric of space-time, combining functionality and elegance.", 129.99M, "Fashion")
        };

        public void AddProduct(Product product)
        {
            int newId = 1;
            if (_products.Any())
            {
                newId = _products.Max(p => p.Id) + 1;
            }
            product.Id = newId;
            _products.Add(product);


            ProductHasBeenAdded?.Invoke(product);

        }

        public IReadOnlyList<Product> GetProducts()
        {
            return _products.AsReadOnly();
        }

        public Product GetProductById(int id)
        {
            return _products.Single(p => p.Id == id);
        }

        public void TryUpdateProduct(int id, Product updatedProduct)
        {
            Product productToUpdate = _products.Single(p => p.Id == id);

            if (string.IsNullOrEmpty(productToUpdate.Name))
            {
                productToUpdate.Name = updatedProduct.Name;
            }
            
            productToUpdate.Description = updatedProduct.Description;

            productToUpdate.Price = updatedProduct.Price;

            productToUpdate.Category = updatedProduct.Category;
        }

        public bool DeleteProduct(int id)
        {
            Product productToDelete = _products.Single(p => p.Id == id);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
                return true;
            }
            else return false;
        }
    }
}

