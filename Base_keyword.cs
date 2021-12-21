using System;

class  Base_Keyword {
    public static void Main() {
        Derived d = new Derived(10);
        Console.WriteLine($"d.Id = {d.Id}");
        d.GetInfo();
    }
}

class Base {
    public int Id { get; set; }
    public Base() {}
    public Base(int id)
    {
        Id = id;
    }
    
    public virtual void GetInfo() => Console.WriteLine("Base Info");
}

class Derived : Base {
    public Derived() : base(){ }
    public Derived(int id) : base(id) { }
    public override void GetInfo()
    {
        base.GetInfo(); 
        Console.WriteLine("Derived Info");
    }
}