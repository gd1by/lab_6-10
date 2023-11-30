using System;
using System.Collections.Generic;
using System.Linq;

// Перечисление для статусов заказа
public enum OrderStatus
{
    Pending,
    Preparing,
    Ready,
    Delivered
}

// Класс, представляющий заказ
public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public List<string> Items { get; set; }
    public OrderStatus Status { get; set; }
}

// Класс ресторана, управляющий заказами
public class Restaurant
{
    private List<Order> orders; // Список заказов

    public Restaurant()
    {
        orders = new List<Order>();
    }

    // Метод для добавления нового заказа
    public void AddOrder(Order order)
    {
        order.Status = OrderStatus.Pending; // Устанавливаем начальный статус "Pending"
        orders.Add(order);
    }

    // Метод для обновления статуса заказа по его ID
    public void UpdateOrderStatus(int orderId, OrderStatus newStatus)
    {
        Order order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.Status = newStatus;
        }
        else
        {
            Console.WriteLine($"Order with id {orderId} not found.");
        }
    }

    // Метод для отображения статуса заказа по его ID
    public void DisplayOrderStatus(int orderId)
    {
        Order order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            Console.WriteLine($"Order {orderId} status: {order.Status}");
        }
        else
        {
            Console.WriteLine($"Order with id {orderId} not found.");
        }
    }

    // Метод для фильтрации заказов с использованием заданной функции-фильтра
    public List<Order> FilterOrders(Func<Order, bool> filterFunc)
    {
        return orders.Where(filterFunc).ToList();
    }

    // Метод для сортировки заказов с использованием заданной функции сравнения
    public List<Order> SortOrders(Func<Order, object> sortFunc)
    {
        return orders.OrderBy(sortFunc).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляр ресторана
        Restaurant restaurant = new Restaurant();

        // Создаем два заказа
        Order order1 = new Order { Id = 1, CustomerName = "John Doe", Items = new List<string> { "Burger", "Fries" } };
        Order order2 = new Order { Id = 2, CustomerName = "Jane Doe", Items = new List<string> { "Pizza", "Cola" } };

        // Добавляем заказы в ресторан
        restaurant.AddOrder(order1);
        restaurant.AddOrder(order2);

        // Обновляем статусы заказов
        restaurant.UpdateOrderStatus(1, OrderStatus.Preparing);
        restaurant.UpdateOrderStatus(2, OrderStatus.Ready);

        // Отображаем статусы заказов
        restaurant.DisplayOrderStatus(1);
        restaurant.DisplayOrderStatus(2);

        // Фильтрация заказов с использованием статуса "Ready"
        List<Order> filteredOrders = restaurant.FilterOrders(o => o.Status == OrderStatus.Ready);
        Console.WriteLine("Filtered orders:");
        foreach (Order order in filteredOrders)
        {
            Console.WriteLine($"Order {order.Id} status: {order.Status}");
        }

        // Сортировка заказов по ID
        List<Order> sortedOrders = restaurant.SortOrders(o => o.Id);
        Console.WriteLine("Sorted orders:");
        foreach (Order order in sortedOrders)
        {
            Console.WriteLine($"Order {order.Id} status: {order.Status}");
        }
    }
}
