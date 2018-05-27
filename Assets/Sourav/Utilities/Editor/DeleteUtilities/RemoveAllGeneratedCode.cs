using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Sourav.Utilities.EditorUtils
{
    public class RemoveAllGeneratedCode : Editor 
    {
        [MenuItem("ProjectUtility/Utilities/Delete All Generated")]
        public static void RemoveGenerated()
        {
            string path = Application.dataPath + "/Generated";

            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
            Directory.Delete(path);

            GameObject[] InHierarchy = Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < InHierarchy.Length; i++)
            {
                if (InHierarchy[i].name.Equals("ExcludedFoldersList"))
                {
                    DestroyImmediate(InHierarchy[i]);
                }
            }

            SwitchOnOffMacro.MacroOnOff(GetBuildTargetGroup.GetCorrectBuildTargetGroup(), Definitions.GENERATED_MACRO, MacroAction.Off);

            AssetDatabase.Refresh();
        }
    }
    
}
