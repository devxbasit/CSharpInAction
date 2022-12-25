using System;

class ExceptionalHandling_Intermediate{
    public static void Main(){

        // Exception Propagates Up
        try{
            DoX();
        } catch (Exception e) {
            Console.WriteLine($"Exception in Main() {e.Message}");
        }finally {
            Console.WriteLine("Main() -> Clean up code here");
        }
        
        try{
            DoY();
        } catch (Exception e) {
            Console.WriteLine($"Exception in Main() {e.Message}");
        }finally {
            Console.WriteLine("Main() -> Clean up code here");
        }
    }

    public static void DoX(){
        try{
            int x = int.Parse("ten");
        } catch(Exception e) {
            throw new Exception(e.Message);
        }
        finally {
            Console.WriteLine("DoX() Clean Up Code Here");
            Console.WriteLine("DoX() Clean Up Done!");
        }
    }
    public static void DoY(){
        try{
            int x = int.Parse("ten");
        } catch(Exception e) {
            var log = e.Message;
        }
        finally {
            Console.WriteLine("DoY() Clean Up Code Here");
            
            // throws exception
            var i = int.Parse("ten");
            Console.WriteLine("DoY() Clean Up Done!");
        }
    }
}