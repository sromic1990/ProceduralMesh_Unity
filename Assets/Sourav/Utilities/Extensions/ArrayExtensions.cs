using System.Collections;
using System.Collections.Generic;

namespace Sourav.Utilities.Extensions
{
    public static class ArrayExtensions 
    {
        public static T[] Add<T>(this T[] array, T[] array1, T[] array2)
        {
            array = new T[array1.Length + array2.Length];
            
            int index = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                array[index] = array1[i];
                index++;
            }
            
            for (int i = 0; i < array2.Length; i++)
            {
                array[index] = array2[i];
                index++;
            }
            
            return array;
        }

        public static List<T> ToList<T>(this T[] array)
        {
            List<T> list = new List<T>();

            for (int i = 0; i < array.Length; i++)
            {
                list.Add(array[i]);
            }

            return list;
        }
    }
    
}
