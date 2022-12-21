using T2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace T2
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            DynamicArray<int> obj1 = new DynamicArray<int>();
            DynamicArray<int> obj2 = new DynamicArray<int>();

            obj1.CapacityChanged += CapacityChanged;

            int[] array1 = { 1, 2, 3, 4, 5, 6 };
            int[] array2 = {6, 5, 4, 3, 2, 1 };

            obj1.AddRange(array1);
            obj1.AddRange(array2);
            obj1.Add(10);
            obj1.RemoveAll(2);
            Console.WriteLine(obj1.Equals(obj2));
            obj1.Insert(10, 2);

            Console.WriteLine(obj1 == obj2);
            Console.WriteLine(obj1 != obj2);

            Console.WriteLine(obj1.GetHashCode());

            foreach (var item in obj1)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }

        public static void CapacityChanged(object sender, DynamicArrayEventArgs e)
        {
            Console.WriteLine($"{e.GetType()} : {e.OldCapacity} -> {e.NewCapacity}");
        }
    }
}
