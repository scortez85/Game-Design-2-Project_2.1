using UnityEngine;
using System.Collections;

public class onClickSelect : MonoBehaviour {

    public RaycastHit hit,oldHit;
    public Ray ray;
    public string placeableObj;
    public GameObject tower;
	void Start () {
	
	}
    public void setPlaceableObj(string name)
    {
        placeableObj = name;
    }
	
	// Update is called once per frame
	void Update () {
        if (!placeableObj.Equals(""))
            makeObj();

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast (ray, out hit, 1000.0f))
            {
                //Debug.Log(hit.collider.name);
                if (hit.collider.tag.Equals("Tower"))
                {
                    oldHit = hit;
                    hit.collider.gameObject.GetComponent<Tower>().selected = true;
                }
                else if (!hit.collider.tag.Equals("Tower") && oldHit.collider.gameObject.tag.Equals("Tower"))
                {
                    oldHit.collider.gameObject.GetComponent<Tower>().selected = false;
                }
            }
        }
	
	}
    void makeObj()
    {
        Vector3 propPos = new Vector3(Input.mousePosition.x, 3.84f, Input.mousePosition.z);
        if (placeableObj.Equals("Tower"))
        {
            placeableObj = "";
            GameObject towerProp = (GameObject)Instantiate(tower, propPos, Quaternion.identity);
            towerProp.GetComponent<selectableProp>().propPos = propPos;
        }

    }
}
