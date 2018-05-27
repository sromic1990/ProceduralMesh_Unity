using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Sourav.Utilities.EditorUtils
{
    public class ExtractFileNameFromPath : Editor 
    {
        public static string ExtractName(string path)
        {
            string fileName = "";

            string[] names = path.Split('/');
            fileName = names[names.Length - 1];

            return fileName;
        }
    }
    
}
