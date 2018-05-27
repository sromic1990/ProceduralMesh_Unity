

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Sourav.Utilities.EditorUtils
{
    public class ShowInExplorer : Editor 
    {
        [MenuItem("ProjectUtility/Utilities/ShowInExplorer %&f")]
        public static void Show()
        {
            string path = "";
            Object obj = Selection.activeObject;
            if(obj)
            {
                path = AssetDatabase.GetAssetPath(obj);
            }
            else
            {
                path = Application.dataPath;
            }

            if(Selection.activeObject)
            {
                Debug.Log(Selection.activeObject.name + " is selected.");
            }
            else
            {
                Debug.Log("Nothing selected.");
            }

            ShowExplorer(path);
        }

        public static void ShowExplorer(string path)
        {
            EditorUtility.RevealInFinder(path);
        }
    }
}

