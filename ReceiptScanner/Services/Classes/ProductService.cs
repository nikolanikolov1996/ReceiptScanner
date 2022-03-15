using Newtonsoft.Json;
using ReceiptScanner.Models;
using ReceiptScanner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner.Services.Classes
{
    public class ProductService : IProductService
    {
        static WebClient webClient = new WebClient();
        public const string urlString = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

        public List<Product> GetAllProducts()
        {
            string jsonString = webClient.DownloadString(urlString);

            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonString);

            return productList;
        }

        public void DisplayAllProducts(List<Product> products)
        {
            products.ForEach(p => DisplayProductInfo(p));
        }

        public void DisplayProductInfo(Product product)
        {
            Console.WriteLine($"...{product.Name}");
            Console.WriteLine($"   Price: ${product.Price}");
            Console.WriteLine($"   {TruncateString(product.Description)}...");

            if (product.Weight == 0)
            {
                Console.WriteLine("   Weight: N/A");
            }
            else
            {
                Console.WriteLine($"   Weight: {product.Weight}g");
            }
        }

        public string TruncateString(string description)
        {
            if (description.Length > 10)
            {
                return description.Substring(0, 10);
            }
            else
            {
                return description;
            }
        }

        public void StartApp()
        {
            List<Product> products = GetAllProducts();
            List<Product> domesticProducts = products.Where(p => p.Domestic).OrderBy(p => p.Name).ToList();
            List<Product> importedProducts = products.Where(p => !p.Domestic).OrderBy(p => p.Name).ToList();

            Console.WriteLine(".Domestic");
            DisplayAllProducts(domesticProducts);

            Console.WriteLine(".Imported");
            DisplayAllProducts(importedProducts);

            Console.WriteLine($"Domestic cost: ${domesticProducts.Sum(x => x.Price)}");
            Console.WriteLine($"Imported cost: ${importedProducts.Sum(x => x.Price)}");
            Console.WriteLine($"Domestic count: {domesticProducts.Count}");
            Console.WriteLine($"Imported count: {importedProducts.Count}");
        }
    }
}
