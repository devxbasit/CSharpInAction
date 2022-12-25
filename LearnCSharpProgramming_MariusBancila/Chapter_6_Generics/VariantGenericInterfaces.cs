using System.Collections.Generic;
using System;

class VariantGenericInterfaces
{
    public static void Main()
    {
        // All Cars are vehicles, but not all vehicles are cars
        
        IEnumerable<Object> list = new List<string>();

        // throws error
        // List<Object> list1 = new List<string>();
        Base b1 = new Base();
        Base b2 = new D1();
        D3 d3 = new D5();

        // throws error
        // D5 d5 = new D3();

        // can assign more derived class to less derived class (Vehicle v = new Car() )
        ICovariantTypeParam<object> cv1 = new CovariantTypeParam<string>();
        // throws error
        //ICovariantTypeParam<string> cv2 = new CovariantTypeParam<Object>();

        // throws error
        //IContravariantTypeParam<Object> cnv1 = new ContravariantTypeParam<string>();
        // can assign less derived class to more derived class (see Func and Action)
        IContravariantTypeParam<string> cnv2 = new ContravariantTypeParam<Object>();
    }
}

interface ICovariantTypeParam<out T> { }
interface IContravariantTypeParam<in T> { }
class CovariantTypeParam<T> : ICovariantTypeParam<T> { }
class ContravariantTypeParam<T> : IContravariantTypeParam<T> { }



class Base { }
class D1 : Base { }
class D2 : D1 { /*less derived class*/ }
class D3 : D2 { }
class D4 : D3 { }
class D5 : D4 { /* more derived class*/ }
