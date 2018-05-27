using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace Sourav.Utilities.EditorUtils
{
    public class FindFiles : Editor 
    {
        public static string[] FindAllFiles(string fileExt)
        {
            string[] files = Directory.GetFiles(Application.dataPath, "*."+fileExt, SearchOption.AllDirectories);

            return files;
        }

        [MenuItem("ProjectUtility/Utilities/Add Debug to all files")]
        public static void AddLineToFiles()
        {
            if (EditorUtility.DisplayDialog("Add Debug To Files", "This will change all your script files to include debug information. Are you sure you want to perform the operation?", "Yes", "No"))
            {
                FileMatching readLines = new FileMatching();
                string[] files = FindAllFiles("cs");
                //readLines.WriteLineToFile("//This is a test", files[0]);
                for (int i = 0; i < files.Length; i++)
                {

                    if(!CheckIfScriptIsExcluded.IsScriptExcluded(ExtractFileNameFromPath.ExtractName(files[i])))
                    {
                        readLines.WriteLineToFile("//This is a test", files[i]);
                    }
                }
            }
        }

        [MenuItem("ProjectUtility/Utilities/Remove Debug from all files")]
        public static void RemoveLineFromFiles()
        {
            if (EditorUtility.DisplayDialog("Remove Debug From Files", "This will change all your script files to remove custom debug information and extra spaces. Are you sure you want to perform the operation?", "Yes", "No"))
            {
                FileMatching readLines = new FileMatching();
                string[] files = FindAllFiles("cs");
                //readLines.RemoveLinesFromFile("//This is a test", files[0]);
                for (int i = 0; i < files.Length; i++)
                {
                    readLines.RemoveLinesAndSpacesFromFile("//This is a test", files[i]);
                }
             }
        }
    }
}
