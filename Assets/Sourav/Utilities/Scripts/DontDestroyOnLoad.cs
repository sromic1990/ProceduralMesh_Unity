using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this);
	}
}
