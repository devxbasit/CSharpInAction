using System;

class GrabageCollection {
    public static void Main() {
                
        var engine = new Engine();
        Console.WriteLine($"Generation of engine: {GC.GetGeneration(engine)}");
        Console.WriteLine($"Estimated heap size: {GC.GetTotalMemory(false)}");        
        GC.Collect();
    }
}

class Engine {
}