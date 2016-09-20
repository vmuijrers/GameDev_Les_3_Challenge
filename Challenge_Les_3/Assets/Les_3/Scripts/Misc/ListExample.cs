using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using System.Collections.Generic;

public class ListExample : MonoBehaviour {
    [HideInInspector]
    public List<ListItemExample> list;
    // Use this for initialization
    void Start () {
	    

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
[System.Serializable]
public class ListItemExample
{
    public float someFloat;
    public bool someBool;
}
