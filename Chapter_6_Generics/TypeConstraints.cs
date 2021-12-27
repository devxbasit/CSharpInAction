using System;

class TypeConstraints {
    public static void Main() {
        

    }
}

struct Point<T> 
    where T : struct,
              IComparable, IComparable<T>,
              IConvertible,
              IEquatable<T>,
              IFormattable 
{
    public T X { get; }
    public T Y { get; }

    public Point(T x, T y) {
        X = x;
        Y = y;
    }
}