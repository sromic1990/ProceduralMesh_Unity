using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace Sourav.Utilities.Scripts
{
    public class CreatePrefabInstance
    {
        public CreatePrefabInstance(string path)
        {
            GameObject gObj = (GameObject)PrefabUtility.InstantiatePrefab(Resources.Load(path));
        }
    }

}
#endif