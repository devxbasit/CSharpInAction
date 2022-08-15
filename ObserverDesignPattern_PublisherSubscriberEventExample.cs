using System;

class ObserverDesignPattern_PublisherSubscriberEventExample
{
    public static void Main()
    {
        // see first - ObserverDesignPattern.cs example 

        var store = new BookStore("Do Epic Shit");

        var s1 = new Student("s1");
        var s2 = new Student("s2");
        var s3 = new Student("s3");
        var e = new Employee();

        store.AddSubscriber(s1.Update);
        store.AddSubscriber(s2.Update);
        store.AddSubscriber(s3.Update);
        store.AddSubscriber(e.Update);
        store.AddSubscriber((x, y) => Console.WriteLine("Hello Lambda"));
        store.AddSubscriber(delegate (string x, string y) { Console.WriteLine("Hello Anonymous Function"); });

        store.RemoveSubscriber(s2.Update);
        store.AddQuantity(10);
    }
}

class BookStore
{
    public BookStore(string bookName) => this.BookName = bookName;
    public string BookName { get; set; }
    public int Quantity { get; set; } = 0; // out of stock

    private event BookBackInStock _backInStockEvent;

    public void AddSubscriber(BookBackInStock fn) => _backInStockEvent += fn;

    public void RemoveSubscriber(BookBackInStock fn) => _backInStockEvent -= fn;
    public void Notify() => _backInStockEvent?.Invoke(this.BookName, $"{this.BookName} back in stock, order now!");

    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;

        if (this.Quantity == quantity) this.Notify();
    }
}


class Student
{
    public string Name { get; set; }
    public Student(string name) => this.Name = name;
    public void Update(string bookName, string msg)
    {
        // Take some action
        Console.WriteLine($"Student: {this.Name} ordered \"{bookName}\"");
    }
}


class Employee
{
    public void Update(string bookName, string msg)
    {
        // Take some action
        Console.WriteLine($"Employee: Added in cart \"{bookName}\"");
    }
}

public delegate void BookBackInStock(string bookName, string msg);