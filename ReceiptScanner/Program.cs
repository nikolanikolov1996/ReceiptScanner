using ReceiptScanner.Services.Classes;
using ReceiptScanner.Services.Interfaces;
using System;

namespace ReceiptScanner
{
    class Program
    {
        private static IProductService productService = new ProductService();
        static void Main(string[] args)
        {
            productService.StartApp();
        }
    }
}
