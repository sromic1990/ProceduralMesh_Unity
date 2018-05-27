using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sourav.Utilities.Extensions;

namespace Sourav.Utilities.Scripts
{
    public class ConvertDateTimeToString
    {
        public static string StringFromDateTime()
        {
            string dateTimeNow = "_";
            string currentDateTime = DateTime.Now.ToString();
            string[] entities = currentDateTime.Split(' ');
            string date = entities[0];
            string time = entities[1];
            
            string[] dateElements = date.Split('/');
            string[] timeElements = time.Split(':');
            
            string[] final = new string[dateElements.Length + timeElements.Length];
            final = final.Add(dateElements, timeElements);
            for (int i = 0; i < final.Length; i++)
            {
                dateTimeNow += final[i];
            }
            
            return dateTimeNow;
        }
    }
    
}