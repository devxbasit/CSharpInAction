using System.Collections;
using System;
using System.Collections.Generic;

class Stack_Example {
    public static void Main() {
        Stack<int> stack = new Stack<int>(new int[] {1, 2, 3});
        Console.WriteLine($"stack.Peek() = {stack.Peek()}");

        var i = stack.TryPop(out int x);
        var j = stack.TryPeek(out int y);
    }
}