using System;

    // https://medium.com/c-programming/c-7-features-ref-return-and-ref-local-1004af8cdc3f

class Ref_Returns{
    public static void Main(){
        Numbers numbers = new Numbers();

        int i = numbers.ReturnByValue(0);
        Console.WriteLine(numbers.ToString());

        // ref local and ref return in Action
        ref int j = ref numbers.ReturnByReference(0);
        Console.WriteLine(numbers.ToString());
        j = 9999;
        Console.WriteLine(numbers.ToString());


        // 
        int z = numbers.ReturnByReference(0);
        z = 0;
        Console.WriteLine(numbers.ToString());
    }


    class Numbers {
        private int[] _numbers;

        public Numbers(){
            _numbers = new int[] { 1, 2, 3, 4 };
        }

        public int ReturnByValue(int index) => _numbers[index];

        public ref int ReturnByReference(int index) => ref _numbers[index];

        public override string ToString() => string.Join(',', _numbers);
    }
}