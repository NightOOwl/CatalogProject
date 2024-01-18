using lesson2.Models;

namespace lesson2
{
    public static class Subscriber
    {
        private static List<string> _updates = new List<string>(); 
        public static void  CatalogUpdatesCheck(Product product)
        {
            _updates.Add ($"{product.ToString()} {DateTime.Now}");
        }
        
    }
}
