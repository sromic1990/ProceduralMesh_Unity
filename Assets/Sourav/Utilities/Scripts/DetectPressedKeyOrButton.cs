using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sourav.Utilities.Scripts
{
    public class DetectPressedKeyOrButton : MonoBehaviour 
    {
        
        // Use this for initialization
        void Start () 
        {
            
        }
        
        // Update is called once per frame
        void Update () 
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                    Debug.Log("<color=orange>KeyCode down: " + kcode+"</color>");
            }
        }
    }
    
}