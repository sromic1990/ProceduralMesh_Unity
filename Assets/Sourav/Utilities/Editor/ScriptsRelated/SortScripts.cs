using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Sourav.Utilities.EditorUtils
{
    public class SortScripts : Editor 
    {
        static string[] files;
        static List<string> foldersList;

        //static string path = Application.dataPath;
        public static Dictionary<string, List<string>> scriptsDict;

        [MenuItem("ProjectUtility/Utilities/Sort Scripts as per folders")]
        public static void SortScriptsAsPerFolder()
        {
            scriptsDict = new Dictionary<string, List<string>>();

            files = FindFiles.FindAllFiles("cs");

            for (int i = 0; i < files.Length; i++)
            {
                foldersList = new List<string>();
                string[] folders = files[i].Split('/');
                for (int j = 0; j < folders.Length - 1; j++)
                {
                    foldersList.Add(folders[j]);
                }

                scriptsDict.Add(folders[folders.Length - 1], foldersList);
            }
        }
    }
}
