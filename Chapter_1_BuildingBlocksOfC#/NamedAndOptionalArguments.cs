using System;

class NamedAndOptionalArguments{
    public static void Main(){

        Point p1 = new Point(99);
        Point p2 = new Point(99, 99);
        
        // Named Parameters  
        Point p3 = new Point(z: 20, x: 100, y: 45);
        
    }

    struct Point{
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Point(int x, int y = 20, int z = 50){
            X = x;
            Y = y;
            Z = z;
        }
    }
}
