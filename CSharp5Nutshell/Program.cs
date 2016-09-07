using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5Nutshell
{
    public class BaseClass
    {
        public virtual void Print() { Console.WriteLine("Base call"); }
    }
    public class DerivedClass : BaseClass
    {
        public new void Print() { Console.WriteLine("Derived class call"); }
    }
    public class B<T>
    {
        public static void X()
        {
            Type t1 = typeof(T);
            Console.WriteLine(t1.FullName);
        }

        public static T GetDefaulVal(T arr)
        {
            T val = default(T);
            return val;
        }
    }

    public interface TempInterFace { }
    public interface TempInterface2<T> where T : BaseClass
    {
        void X();
    }

    public class BaseContraint<T> : DerivedClass where T : BaseClass { }
    public class InterfaceContraint<T> where T : TempInterFace { }
    public class ParameterLessContraint<T> where T : new() { }
    public class NakedTypeContraint<T, U> where U : T { }
    

    public class NewClass : DerivedClass, TempInterFace
    {
        public NewClass()
        {

        }
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;    
        }
    }

    public class Stack<T>
    {
        
    }
    class Program : RichTextBox
    {   
        static void Main(string[] args)
        {
            BaseContraint<BaseClass> tmp = new BaseContraint<BaseClass>();
            InterfaceContraint<NewClass> tmp1 = new InterfaceContraint<NewClass>();
            NakedTypeContraint<BaseClass, BaseContraint<DerivedClass>> tmp2 = new NakedTypeContraint<BaseClass, BaseContraint<DerivedClass>>();
            //Console.WriteLine(NewClass.Max(10,100));

            Console.ReadLine();   
        }   
    }
}
