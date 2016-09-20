using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HolderManager : MonoBehaviour {

    public List<ICheckCorrectItem> myHolders;
    private bool win = false;
    void OnEnable()
    {
        HolderBase.OnCheckWin += CheckUnlock;

    }

    void OnDisable()
    {
        HolderBase.OnCheckWin -= CheckUnlock;

    }
    // Use this for initialization
    void Start () {
        myHolders = new List<ICheckCorrectItem>();
        foreach (Transform t in transform)
        {
            ICheckCorrectItem item = t.GetComponent<ICheckCorrectItem>();
            if (item != null)
            {
                myHolders.Add(item);
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (win)
        {
            transform.position += transform.up * 3 * Time.deltaTime;
        }
	}

    public bool CheckUnlock()
    {
        bool res = true;
        foreach(ICheckCorrectItem h in myHolders)
        {
            res &= h.CheckCorrectItem();
        }
        if (res)
        {
            Debug.Log("You Win!");
            win = true;
        }
        else
        {
            win = false;
            Debug.Log("Nope!");
        }
        return res;
    }
}
