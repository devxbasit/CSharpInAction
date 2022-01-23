using System;

class Attribute_Basic
{
    public static void Main()
    {

    }
}

[Description("Main component of car")]
class Engine
{

    public string Name { get; private set; }

    [Description("KW", Required = true)]
    public double Power { get; private set; }

    [Description("The Constructor")]
    public Engine([Description("The name")] string name,
                  [Description("The Power")] double power)
    {
        Name = name;
        Power = power;
    }

}


[AttributeUsage(AttributeTargets.Class |
AttributeTargets.Struct |
AttributeTargets.Method |
AttributeTargets.Property |
AttributeTargets.Field |
AttributeTargets.Parameter |
AttributeTargets.Method |
AttributeTargets.Constructor,
AllowMultiple = true,
Inherited = true)]
class DescriptionAttribute : Attribute
{

    public string Text { get; private set; }
    public bool Required { get; set; }
    public DescriptionAttribute(string description)
    {
        Text = description;
    }
}