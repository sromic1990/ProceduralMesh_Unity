using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YValue : MonoBehaviour 
{
    public static YValue Instance;

    public float yValue;

    private void Awake()
    {
        Instance = this;
    }
}
