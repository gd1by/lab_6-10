using System;
using System.Collections.Generic;

public enum OrderStatus
{
    Pending,
    Preparing,
    Ready,
    Delivered
}

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<string> Items { get; set; }
    public OrderStatus Status { get; set; }
}

public class Restaurant
{
    private Dictionary<int, Order> orders;

    public Restaurant()
    {
        orders = new Dictionary<int, Order>();
    }

    public void AddOrder(Order order)
    {
        order.Status = OrderStatus.Pending;
        orders.Add(order.Id, order);
    }

    public void UpdateOrderStatus(int orderId, OrderStatus newStatus)
    {
        if (orders.ContainsKey(orderId))
        {
            orders[orderId].Status = newStatus;
        }
        else
        {
            Console.WriteLine($"Order with id {orderId} not found.");
        }
    }

    public void DisplayOrderStatus(int orderId)
    {
        if (orders.ContainsKey(orderId))
        {
            Order order = orders[orderId];
            Console.WriteLine($"Order {orderId} status: {order.Status}");
        }
        else
        {
            Console.WriteLine($"Order with id {orderId} not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Restaurant restaurant = new Restaurant();

        Order order1 = new Order { Id = 1, CustomerName = "John Doe", Items = new List<string> { "Burger", "Fries" } };
        Order order2 = new Order { Id = 2, CustomerName = "Jane Doe", Items = new List<string> { "Pizza", "Cola" } };

        restaurant.AddOrder(order1);
        restaurant.AddOrder(order2);

        restaurant.UpdateOrderStatus(1, OrderStatus.Preparing);
        restaurant.UpdateOrderStatus(2, OrderStatus.Ready);

        restaurant.DisplayOrderStatus(1);
        restaurant.DisplayOrderStatus(2);
    }
}