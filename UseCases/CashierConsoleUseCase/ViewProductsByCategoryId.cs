﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.CashierConsoleUseCaseInterface;

namespace UseCases.CashierConsoleUseCase
{
    public class ViewProductsByCategoryId : IViewProductsByCategoryId
    {
        private readonly IProductRepository productRepository;

        public ViewProductsByCategoryId(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> Execute(int categoryId)
        {
            return productRepository.GetAllByCategoryId(categoryId);
        }
    }
}
