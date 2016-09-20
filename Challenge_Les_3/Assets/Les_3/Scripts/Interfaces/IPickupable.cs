using UnityEngine;
using System.Collections;

public interface IPickupable : IGetGameObject
{
    void PickMeUp(IHolder holder);
    void ReleaseMe();
    bool CheckPickupHeld();
}
