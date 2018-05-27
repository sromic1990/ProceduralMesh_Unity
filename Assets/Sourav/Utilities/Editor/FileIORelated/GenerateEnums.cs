using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Sourav.Utilities.EditorUtils
{
    public class GenerateEnums : Editor 
    {

        public static void GenerateCode(string enumName, List<string> folders)
        {
            //Debug.Log("Inside GeneratedEnums");
            string path = Application.dataPath + "/Generated";
            Directory.CreateDirectory(path);

            string pathEnum = path + "/Enums.cs";
            using (StreamWriter sw = File.CreateText(pathEnum))
            {
                sw.WriteLine("public enum "+enumName);
                sw.WriteLine("{");
                sw.WriteLine("\tGenerated,");
                for (int i = 0; i < folders.Count; i++)
                {
                    if(i != folders.Count - 1)
                    {
                        sw.WriteLine("\t" + folders[i] + ",");
                    }
                    else
                    {
                        sw.WriteLine("\t" + folders[i]);
                    }
                }
                sw.WriteLine("}");
            }

            string pathSelectedList = path + "/ExcludedFolders.cs";
            using (StreamWriter sw = File.CreateText(pathSelectedList))
            {
                sw.WriteLine("using System.Collections;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using UnityEngine;");
                sw.WriteLine("public class ExcludedFolders : MonoBehaviour");
                sw.WriteLine("{");
                sw.WriteLine("\tpublic List<Folders> excludedFolders;");
                sw.WriteLine("}");
            }
        }
    }
    
}
