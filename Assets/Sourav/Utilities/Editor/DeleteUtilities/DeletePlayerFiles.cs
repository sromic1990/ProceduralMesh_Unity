using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Sourav.Utilities.EditorUtils
{
    public class DeletePlayerFiles : Editor
    {
        [MenuItem("ProjectUtility/Utilities/Delete PlayerPrefs &d")]
        public static void DeletePrefs()
        {
            if(EditorUtility.DisplayDialog("Delete Player Prefs?", "Are you sure you want to delete the data in PlayerPrefs?", "Yes", "No"))
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("<color=red>PlayerPrefs Data Deleted</color>");
            }
        }
        
        //Validation Method
        [MenuItem("ProjectUtility/Utilities/Delete Saved Files", true)]
        public static bool CanDeleteSavedfiles()
        {
            //Checks and return whether the game is in play or pause mode, that is we don't want the game to be play or pause mode. This function should only work in edit mode.
            return !(EditorApplication.isPaused | EditorApplication.isPlaying);
        }
        
        //Actual Method
        [ExecuteInEditMode]
        [MenuItem("ProjectUtility/Utilities/Delete Saved Files #d")]
        public static void DeleteSavedFiles()
        {
            if(EditorUtility.DisplayDialog("Delete All Saved Files?", "Are you sure you want to delete all saved files?", "Yes", "No"))
            {
                DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
                dir.Delete(true);
                Debug.Log("All saved files deleted at <color=red>" + Application.persistentDataPath+"</color>");
            }
            
        }
        
    }
}
