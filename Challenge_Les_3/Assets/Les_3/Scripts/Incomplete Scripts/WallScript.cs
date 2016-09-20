using UnityEngine;
using System.Collections;
using System;

public class WallScript : HolderBase
{
    public GameObject wantedItem;
    private Vector3 offSet;



    // Use this for initialization
    protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        if (currentItem != null)
        {
            currentItem.GetGameObject().transform.position = transform.position + offSet;
            currentItem.GetGameObject().transform.rotation = transform.rotation;
        }
	}

    public override bool CheckCorrectItem()
    {
        throw new NotImplementedException();
    }

    public override void HoldObject(IPickupable pickup)
    {
        throw new NotImplementedException();
    }

    public override bool CheckHoldingObject()
    {
        throw new NotImplementedException();
    }

    public override IPickupable ReleaseObject()
    {
        throw new NotImplementedException();
    }
}