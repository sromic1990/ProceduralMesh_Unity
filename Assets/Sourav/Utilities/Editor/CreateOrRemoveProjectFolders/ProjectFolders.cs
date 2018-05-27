using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Sourav.Utilities.EditorUtils
{
    public class ProjectFolders : Editor 
    {
        static string path = Application.dataPath + "/";

        [MenuItem("ProjectUtility/Utilities/Create Folders %#&c")]
        public static void CreateFolders()
        {
            if (EditorUtility.DisplayDialog("Create Project Folders?", "Are you sure you want to create the Project folders?", "Yes", "No"))
            {
                Directory.CreateDirectory(path + "Meshes");
                Directory.CreateDirectory(path + "Fonts");
                Directory.CreateDirectory(path + "Plugins");
                Directory.CreateDirectory(path + "Textures");
                Directory.CreateDirectory(path + "Materials");
                Directory.CreateDirectory(path + "Physics");
                Directory.CreateDirectory(path + "Resources");
                Directory.CreateDirectory(path + "Scenes");
                Directory.CreateDirectory(path + "Music");
                Directory.CreateDirectory(path + "Packages");
                Directory.CreateDirectory(path + "_Scripts");
                Directory.CreateDirectory(path + "Shaders");
                Directory.CreateDirectory(path + "Sounds");
                Directory.CreateDirectory(path + "Prefabs");
                Directory.CreateDirectory(path + "Editor");
                Directory.CreateDirectory(path + "Animation");

                AssetDatabase.Refresh();
            }
        }

        [MenuItem("ProjectUtility/Utilities/Delete Empty Folders %#&d")]
        public static void DeleteEmptyDirectories()
        {
            if (EditorUtility.DisplayDialog("Delete Empty Folders?", "Are you sure you want to delete the empty folders from your project?", "Yes", "No"))
            {
                var directories = Directory.GetDirectories(path);
                for (int i = 0; i < directories.Length; i++)
                {
                    if(Directory.GetFiles(directories[i]).Length == 0 && Directory.GetDirectories(directories[i]).Length == 0)
                    {
                        Directory.Delete(directories[i], false);
                    }
                }

                AssetDatabase.Refresh();
            }
        }

        private static void Create(string folderName)
        {
            string directoryPath = path + folderName;

            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
    
}
