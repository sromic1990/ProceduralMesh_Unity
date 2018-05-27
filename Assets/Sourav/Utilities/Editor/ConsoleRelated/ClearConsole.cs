using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace Sourav.Utilities.EditorUtils
{
    public class ClearConsole : Editor 
    {
        //# = shift, % = ctrl, & = alt
        [MenuItem("ProjectUtility/Utilities/Clear Console %#c")] // CMD + SHIFT + C
        public static void ClearDebugConsole()
        {

            // This simply does "LogEntries.Clear()" the long way:
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var logEntries = assembly.GetType("UnityEditor.LogEntries");
            var clearMethod = logEntries.GetMethod("Clear");
            clearMethod.Invoke(new object(), null);

            //Debug.Log("Clear Debug Console");
        }
    }
    
}