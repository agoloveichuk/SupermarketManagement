﻿using CoreBusiness;

namespace UseCases.UseCaseInterfaces.TransactionUseCaseInterface
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}