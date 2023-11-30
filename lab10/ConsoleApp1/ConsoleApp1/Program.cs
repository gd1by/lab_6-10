using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        List<Order> orders = new List<Order>
        {
            new Order { Name = "Zachary" },
            new Order { Name = "Melissa" },
            new Order { Name = "Andrew" },
            new Order { Name = "Alex" },
            new Order { Name = "Chris" },
            new Order { Name = "Emily" },
            new Order { Name = "Nathan" },
            new Order { Name = "Hannah" },
            new Order { Name = "Drew" },
            new Order { Name = "Jessica" },
        };

        var sortedOrders = ParallelSort(orders, x => x.Name);

        foreach (var order in sortedOrders)
        {
            Console.WriteLine(order.Name);
        }
    }

    public static List<Order> ParallelSort(List<Order> items, Func<Order, object> sortFunc)
    {
        List<Order> sortedItems = new List<Order>(items.Count);
        int partitions = 4; // Change this to the desired number of partitions
        int partitionSize = items.Count / partitions;

        var partitionsList = new List<List<Order>>();

        for (int i = 0; i < items.Count; i += partitionSize)
        {
            partitionsList.Add(items.GetRange(i, Math.Min(partitionSize, items.Count - i)));
        }

        object lockObject = new object();

        Parallel.ForEach(partitionsList, partition =>
        {
            partition.Sort((x, y) =>
            {
                object sortValueX = sortFunc(x);
                object sortValueY = sortFunc(y);

                if (sortValueX is IComparable && sortValueY is IComparable)
                {
                    return ((IComparable)sortValueX).CompareTo(sortValueY);
                }
                else if (sortValueX is string && sortValueY is string)
                {
                    return string.Compare((string)sortValueX, (string)sortValueY, StringComparison.Ordinal);
                }
                else
                {
                    throw new ArgumentException("Cannot compare the specified values.");
                }
            });

            lock (lockObject)
            {
                sortedItems.AddRange(partition);
            }
        });

        return sortedItems;
    }
}

public class Order
{
    public string Name { get; set; }
}