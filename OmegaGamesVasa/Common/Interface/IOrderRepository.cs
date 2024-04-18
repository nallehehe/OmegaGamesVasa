﻿namespace Common.Interface;

public interface IOrderRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrders();

    Task<bool> AddOrderAsync(T product);
}