using UnityEngine;
using System.Collections;
using System;

public abstract class HolderBase : MonoBehaviour, IHolder, ICheckCorrectItem {

    public delegate bool CheckWin();
    public static event CheckWin OnCheckWin;

    protected IPickupable currentItem;
    protected Rigidbody rb;
    // Use this for initialization
    protected virtual void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        if (currentItem != null)
        {
            GameObject go = currentItem.GetGameObject();
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
        }
    }

    public virtual GameObject GetGameObject()
    {
        return gameObject;
    }

    public abstract bool CheckCorrectItem();
    public abstract void HoldObject(IPickupable pickup);
    public abstract bool CheckHoldingObject();
    public abstract IPickupable ReleaseObject();
}