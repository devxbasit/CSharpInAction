using System;

class Finalizer_Basic {
    public static void Main() {
        Engine engine = new Engine();
    }
}

class Engine {
    ~Engine() {
        // 
        // engine clean up code here
    }
}