using UnityEngine;
using System.Collections;
using System;

public class Holder : HolderBase, IPickupable
{
    public GameObject wantedItem;
    private IHolder myHolder;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
    public bool CheckPickupHeld()
    {
        throw new NotImplementedException();
    }

    public void PickMeUp(IHolder holder)
    {
        throw new NotImplementedException();
    }

    public void ReleaseMe()
    {
        throw new NotImplementedException();
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
