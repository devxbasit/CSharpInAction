using System.Data;
using System.Security.Cryptography;
using System;

class Structures_Basic_Example1 {

    public static void Main(){

        // When implementing the IEquatable<T> interface, you should keep the following in mind:
        // • Equals(T) and Equals(object) must return consistent results.
        // • If the value is comparable, then it should implement IComparable<T> too.
        // • If the type implements IComparable<T>, then it should implement IEquatable<T> too.


        Point p1 = new Point(10, 20);
        Point p2 = new Point(10, 20);

        Console.WriteLine($"p1 == p2: {p1 == p2}");
        Console.WriteLine($"p1 != p2: {p1 != p2}");

        Console.WriteLine();
        Console.WriteLine($"p1.Equals(p2) = {p1.Equals(p2)}");


        Console.WriteLine();
        object obj = new Point(50, 50);
        Console.WriteLine($"p1.Equals(obj) = {p1.Equals(obj)}");

    }

    struct Point : IEquatable<Point> {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        // refer page 137
        // first solution is to implement the IEquatable<T> interface that contains a single Equals(T) method.
        public bool Equals(Point other){
            Console.WriteLine("IEquatable Equals(Point) called");
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj){
            Console.WriteLine("override Equals(obj) called");

            if (obj is Point other){

                return this.Equals(other);
            }
            return false;
        }
        
        public override int GetHashCode(){
            return X.GetHashCode() * 17 + Y.GetHashCode();
        }


        // second solution is to overload the == and != 
        
        public static bool operator ==(Point p1, Point p2){
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2){
            return p1.X != p2.X && p1.Y != p2.Y;
        }
    }
}