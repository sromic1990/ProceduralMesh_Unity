using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sourav.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static int FindIndexOf<T>(this List<T> list, T t)
        {
            int index = -1;

            for (int i = 0; i < list.Count; i++)
            {
                if(t.Equals(list[i]))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public static void RemoveFirst<T>(this List<T> list, T t)
        {
            int index = list.FindIndexOf(t);

            if(index != -1)
            {
                list.RemoveAt(index);
            }
        }

        public static T RemovePrevious<T>(this List<T> list, T t)
        {
            int index = list.FindIndexOf(t) - 1;
            T t_toRturn = default(T);

            if (index > 0)
            {
                t_toRturn = list[index];
                list.RemoveAt(index);
            }

            return t_toRturn;
        }

        public static T RemoveNext<T>(this List<T> list, T t)
        {
            int index = list.FindIndexOf(t) + 1;
            T t_toRturn = default(T);

            if (index < list.Count)
            {
                t_toRturn = list[index];
                list.RemoveAt(index);
            }

            return t_toRturn;
        }

        public static string ToString<T>(this List<T> list)
        {
            string str = "";

            for(int i  =  0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    str += list[i].ToString();
                }
                else
                {
                    str += list[i].ToString() + ", ";
                }
            }
            return str;
        }

        public static T[] ToArray<T>(this List<T> list)
        {
            T[] array = new T[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i];
            }

            return array;
        }

        public static void AddList<T>(this List<T> list, List<T> addList)
        {
            if(list.Count > 0)
            {
                for (int i = 0; i < addList.Count; i++)
                {
                    list.Add(addList[i]);
                }
            }
        }

        public static void RemoveList<T>(this List<T> list, List<T> removeList)
        {
            if(list.Count > 0)
            {
                for (int i = 0; i < removeList.Count; i++)
                {
                    list.RemoveFirst(removeList[i]);
                }
            }
        }
    }
    
}