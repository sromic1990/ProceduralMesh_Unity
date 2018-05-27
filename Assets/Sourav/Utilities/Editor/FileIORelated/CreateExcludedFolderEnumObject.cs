using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Sourav.Utilities.EditorUtils
{
    public class CreateExcludedFolderEnumObject : MonoBehaviour
    {
        [MenuItem("ProjectUtility/Utilities/Create List Of Excluded folders")]
        public static void CreateExcludedFolderObject()
        {
#if GENERATED_FILES
            if(FindObjectOfType<ExcludedFolders>() == null)
            {
                GameObject go = new GameObject("ExcludedFoldersList");
                go.tag = "Generated";
                go.AddComponent<DontDestroyOnLoad>();
                go.AddComponent<ExcludedFolders>();
            }
#endif
            SortScripts.SortScriptsAsPerFolder();

        }
    }
    
}
