using System;

class Program
{
    public static void Main()
    {

        //The nullable reference types are very useful to decrease the amount of
        //NullReferenceException exceptions at runtime

        Console.WriteLine(new Student("Basit").NameLength);
        Console.WriteLine(new Student().NameLength);


        // Enabling only the annotations but not the compiler warnings:
        // Csproj: < Nullable > annotations </ Nullable >
        // Code: #nullable enable annotations


        // Enabling only the warnings but not the annotations in the editor
        // Csproj: < Nullable > warnings </ Nullable >
        // Code: #nullable enable warnings

    }
}


#nullable enable

class Student
{
    // We may need the reference to assume the null value.In this other case, the analyzer
    // will verify that there is adequate null-checking code (an if statement or similar) to
    // avoid any possible path that could dereference a null.

    private string? _name; // assume null value


    public Student()
    {

    }

    public Student(string name)
    {
        _name = name;

    }

    public int NameLength
    {
        get
        {
            return _name.Length; // warning "_name may be null here"

            // fix
            // return _name?.Length ?? 0;
        }
    }


    public int NameLength2
    {
        //forgiving operator in action - should be used only in extremely rare cases

        //the forgiving operator, represented by an
        //exclamation mark, which is used to inform the code analysis to forgive a statement for that
        //specific case. Using the forgiving operator is rare because it means the analysis has failed
        //to recognize a case where the developer themselves knows the reference cannot be null.

        get => _name!.Length;


        //Remember that the question mark is used while declaring the reference, while the
        //exclamation mark is used when dereferencing it.

    }
}

#nullable restore
