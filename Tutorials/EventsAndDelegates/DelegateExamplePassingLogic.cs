using System;
using System.Collections.Generic;

class DelegateExamplePassingLogic
{

    public static void Main()
    {

        // nutshell -> passing logic as argument

        List<Employee> employees = new List<Employee>(){
            new Employee("A", 10000, 0),
            new Employee("B", 20000, 1),
            new Employee("C", 90000, 5)
        };

        //Anonymous function
        IsEmployeeEligible promotionBasedOnExperience = delegate (Employee employee)
        {
            return employee.Experience > 3;
        };

        // lambda expression
        IsEmployeeEligible promotionBasedOnSalary = (Employee employee) => employee.Salary >= 20000;


        // Employee.PromoteEmployees(employees, promotionBasedOnExperience);
        Employee.PromoteEmployees(employees, promotionBasedOnSalary);


    }
}

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public byte Experience { get; set; }


    public Employee(string name, decimal salary, byte experience) => (this.Name, this.Salary, this.Experience) = (name, salary, experience);


    public static void PromoteEmployees(List<Employee> employees, IsEmployeeEligible isEmployeeEligible)
    {

        foreach (var employee in employees)
        {

            // no hard coded logic for isEmployeeEligible function
            if (isEmployeeEligible(employee))
            {
                Console.WriteLine($"Promoting Employee {employee.Name}");
                employee.Salary += 5000;
            }
        }
    }
}

public delegate bool IsEmployeeEligible(Employee employee);