using UnityEngine;
using System.Collections;

public interface IHolder : IGetGameObject
{
    void HoldObject(IPickupable pickup);
    bool CheckHoldingObject();
    IPickupable ReleaseObject();
    
    
    
}
