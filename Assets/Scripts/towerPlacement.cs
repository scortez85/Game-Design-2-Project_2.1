using UnityEngine;
using System.Collections;

public class towerPlacement : MonoBehaviour {

    private bool objPlaceable = true;

    public void setPlaceable(bool value)
    {
        objPlaceable = value;
    }

    public bool getPlaceable()
    {
        return objPlaceable;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
