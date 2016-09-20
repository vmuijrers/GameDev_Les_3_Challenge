using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour ,IPickupable {

    private Rigidbody rb;
    private IHolder myHolder;
    // Use this for initialization
    protected virtual void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update () {
	    
	}
 

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void PickMeUp(IHolder holder)
    {
        throw new NotImplementedException();
    }

    public void ReleaseMe()
    {
        throw new NotImplementedException();
    }

    public bool CheckPickupHeld()
    {
        throw new NotImplementedException();
    }
}
