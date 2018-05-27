using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using Sourav.Utilities.Scripts.Attributes;

namespace Sourav.Utilities.EditorScripts
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UnityEngine.Object), editorForChildClasses: true, isFallback = false)]
	public class MyCustomInspector : Editor 
	{
        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();
            //Draw my button and relevent code
            Type type = target.GetType();
            MethodInfo[] methods = type.GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                ButtonAttribute attribute = (ButtonAttribute)Attribute.GetCustomAttribute(methods[i], typeof(ButtonAttribute));
                if(attribute != null)
                {
                    if(attribute.WorkMode == ButtonWorkType.Both)
                    {
                        DrawButtonAndInvokeMethod(attribute, methods[i]);
                    }
                    else
                    {
                        if(Application.isPlaying)
                        {
                            if(attribute.WorkMode == ButtonWorkType.RunTimeOnly)
                            {
                                DrawButtonAndInvokeMethod(attribute, methods[i]);
                            }
                        }
                        else
                        {
                            if(attribute.WorkMode == ButtonWorkType.EditorOnly)
                            {
                                DrawButtonAndInvokeMethod(attribute, methods[i]);
                            }    
                        }
                    }
                }
            }

            EditorGUILayout.Space();
            DrawDefaultInspector();

        }

        void DrawButtonAndInvokeMethod(ButtonAttribute attribute, MethodInfo methodInfo)
        {
            if (GUILayout.Button(attribute.ButtonName.Equals("") ? methodInfo.Name : attribute.ButtonName))
            {
                foreach (var item in targets)
                {
                    methodInfo.Invoke(item, null);
                }
            }
        }
	}
}
