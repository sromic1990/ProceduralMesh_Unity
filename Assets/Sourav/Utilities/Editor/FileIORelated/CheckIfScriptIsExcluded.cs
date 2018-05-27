using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Sourav.Utilities.EditorUtils
{
    public class CheckIfScriptIsExcluded : Editor
    {
        public static bool IsScriptExcluded(string scriptName)
        {
            bool isExcluded = false;

#if GENERATED_FILES
            GameObject go = GameObject.FindWithTag("Generated");
            ExcludedFolders expFolders = go.GetComponent<ExcludedFolders>();

            if(expFolders != null)
            {
                if(SortScripts.scriptsDict.ContainsKey(scriptName))
                {
                    for (int i = 0; i < SortScripts.scriptsDict[scriptName].Count; i++)
                    {
                        for (int j = 0; j < expFolders.excludedFolders.Count; j++)
                        {
                            if(expFolders.excludedFolders[j].ToString().Equals(SortScripts.scriptsDict[scriptName][i]))
                            {
                                isExcluded = true;
                                break;
                            }
                        }

                        if (isExcluded)
                            break;
                    }
                }
            }

#endif
            return isExcluded;
        }
    }
    
}
