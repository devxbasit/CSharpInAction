using System;

class CallbackInAction_CountingTaskDemo
{
    public static void Main()
    {
        var student = new Student("Basit");
        var teacher = new Teacher("Ritik", 10, 20);

        teacher.AssignCountingTaskToStudent(student);

    }
}

public class Teacher
{
    public String Name { get; set; }
    public int CountFrom { get; set; }
    public int CountTo { get; set; }

    public Teacher(string name, int countFrom, int countTo) => (Name, CountFrom, CountTo) = (name, countFrom, countTo);

    public void AssignCountingTaskToStudent(Student student)
    {
        NotifyProgress callback = new NotifyProgress(MonitorCountingTaskProgress);
        student.GetCountingTaskFromTeacher(CountFrom, callback);
    }

    public string MonitorCountingTaskProgress(int countDone, Student student)
    {
        if (countDone < CountTo)
        {
            return "ContinueCounting";
        }
        else
        {
            Console.WriteLine($"Teacher: Well Done {student.Name}, rise and shine!");
            return "StopCounting";
        }
    }
}

public class Student
{
    public string Name { get; set; }

    public Student(string name) => Name = name;

    public void GetCountingTaskFromTeacher(int countFrom, NotifyProgress notifyCallback)
    {
        do
        {
            Console.WriteLine($"Student : Counting...{countFrom}");

        } while (notifyCallback(countFrom++, this) == "ContinueCounting");
    }
}

public delegate string NotifyProgress(int count, Student student);