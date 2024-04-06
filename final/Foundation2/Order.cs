using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _productList;
    private Customer _customer;

    public Order(List<Product> productList, Customer customer)
    {
        _productList = productList;
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        if (_productList == null)
            _productList = new List<Product>();

        _productList.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _productList)
        {
            total += product.GetTotalCost();
        }
        return total + (_customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _productList)
        {
            label += $"Name: {product.Name}, Product ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetAddressDetails()}";
    }

    public Customer GetCustomer()
    {
        return _customer;
    }
}