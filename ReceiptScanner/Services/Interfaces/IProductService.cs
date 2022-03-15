using ReceiptScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        void DisplayAllProducts(List<Product> products);
        void DisplayProductInfo(Product product);
        string TruncateString(string description);
        void StartApp();

    }
}
