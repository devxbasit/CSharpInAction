using System;
using System.Collections.Generic;

// https://refactoring.guru/design-patterns/observer/csharp/example

class ObserverDesignPattern
{
    public static void Main()
    {
        var subject = new Subject();
        var employee = new Employee();
        var student = new Student();

        subject.Attach(employee);
        subject.Attach(student);

        subject.SomeBusinessLogic(6);
        subject.Detach(student);
        subject.SomeBusinessLogic(6);


    }
}

public class Subject : ISubject
{
    public int State { get; set; } = -1;

    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public void SomeBusinessLogic(int state)
    {
        Console.WriteLine("Subject: I'm doing something...");
        this.State = state;

        Console.WriteLine($"Subject: My state has just changed to : {this.State}");
        this.Notify();
    }
}

class Employee : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State > 3) Console.WriteLine("Employee: Reacted to the event.");
    }
}

class Student : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State > 5) Console.WriteLine("Student: Reacted to the event.");
    }

}

public class Observer : IObserver
{
    public void Update(ISubject subject)
    {

    }
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public interface IObserver
{
    void Update(ISubject subject);
}