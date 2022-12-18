using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;
using UseCases.ProductsUseCase;

namespace UseCases.CashierConsoleUseCase
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;

        public SellProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(int productId, int qtyToSell)
        {
            var product = productRepository.GetProductById(productId);
            if (product == null) return;

            product.Quantity -= qtyToSell;
            productRepository.UpdateProduct(product);
        }
    }
}
