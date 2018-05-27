using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sourav.Utilities.Scripts;
using System.IO;

namespace Sourav.Utilities.EditorUtils
{
    public class ExportAssetPackage : Editor 
    {
        //% = cmd or ctrl, # = shift, & = alt
        [MenuItem("ProjectUtility/Utilities/Export UnityProject %e")]
        public static void ExportUnityPackage()
        {
            DirectoryInfo di = new DirectoryInfo(Application.dataPath);
            string exportDirectory = di.Parent.FullName + "/Exported Packages";
            if(!Directory.Exists(exportDirectory))
            {
                Directory.CreateDirectory(exportDirectory);
            }

            if(EditorUtility.DisplayDialog("Export UnityPackage", "Do you want to start exporting a package from your current project?", "Yes", "No"))
            {
                CheckGameObjectsPresetInScene<ExportHelper> exportHelper = new CheckGameObjectsPresetInScene<ExportHelper>();
                GameObjectSerachResult result = exportHelper.CheckForGameObject();
                if(result.numberOfObjects >= 1)
                {
                    string packageFolderName = result.foundGameObjects[0].GetComponent<ExportHelper>().PackageFolder;
                    string exportedPackageName = result.foundGameObjects[0].GetComponent<ExportHelper>().ExportedPackageName;
                    if(!string.IsNullOrEmpty(packageFolderName) &&  !string.IsNullOrEmpty(exportedPackageName))
                    {
                        Debug.Log("AssetName = "+Application.dataPath + "/"+packageFolderName + ConvertDateTimeToString.StringFromDateTime() + ".unitypackage");
                        if(Directory.Exists(Application.dataPath + "/"+packageFolderName))
                        {
                            AssetDatabase.ExportPackage("Assets/" + packageFolderName, exportDirectory + "/"+exportedPackageName + ConvertDateTimeToString.StringFromDateTime() + ".unitypackage", ExportPackageOptions.IncludeDependencies | ExportPackageOptions.Recurse);
                            EditorUtility.DisplayDialog("Package exported", "Package successfully exported to " + exportDirectory + ".", "Ok");
                            AssetDatabase.Refresh();
                        }
                        else
                        {
                            //Warn that directory does not exist
                            EditorUtility.DisplayDialog("Directory does not exist", "Your specified directory does not exist", "Ok");
                        }
                    }
                    else
                    {
                        //Warn that no package folder name is specified
                        EditorUtility.DisplayDialog("Export package folder unspecified", "No package folder name is specified. Enter the name of the package you want to export and try again", "Ok");
                    }
                }
                else
                {
                    //Create export helper
                    //Ask to try again
                    EditorUtility.DisplayDialog("Export Helper Not found", "No export helper present in scene. Now one has been created. Enter correct Folder name and try again", "Ok");
                    CreatePrefabInstance createPrefab = new CreatePrefabInstance("Prefabs/ExportHelper");
                }
            }
        }
    }
    
}