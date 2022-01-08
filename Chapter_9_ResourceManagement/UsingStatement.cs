using System;

class UsingStatement {
    public static void Main() {
         
        Car car = null;
        try {
            car = new Car();

            // use the car 
        } finally {
            car?.Dispose();
        }


        // using statement 

        using (Car car1 = new Car()) {
            //use the car
        }


        using (Car car1 = new Car(),
                    car2 = new Car()) {
            // use the car

        }


        using (Car car1 = new Car()) 
        using (Car car3 = new Car()) {
            // use the car

        } 


        // c# 8

        using Car car5 = new Car();
        // use the car 

    }
}

class Car : IDisposable {
   
    public void Dispose() {

    }
}