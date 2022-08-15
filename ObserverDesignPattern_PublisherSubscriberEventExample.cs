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
    public void Notify() => _backInStockEvent?.Invoke(this, new BookBackInStockEventArgs(this.BookName, $"{this.BookName} back in stock, order now!"));

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
    public void Update(object sender, BookBackInStockEventArgs e)
    {
        // Take some action
        Console.WriteLine($"Student: {this.Name} ordered \"{e.BookName}\"");
    }
}


class Employee
{
    public void Update(object sender, BookBackInStockEventArgs e)
    {
        // Take some action
        Console.WriteLine($"Employee: Added in cart \"{e.BookName}\"");
    }
}


// event
public delegate void BookBackInStock(object sender, BookBackInStockEventArgs e);

// event args
public class BookBackInStockEventArgs : EventArgs
{
    public string BookName { get; set; }
    public string Message { get; set; }
    public BookBackInStockEventArgs(string bookName, string message) => (this.BookName, this.Message) = (bookName, message);
}