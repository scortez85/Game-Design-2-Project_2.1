﻿using UnityEngine;
using System.Collections;

public class onClickSelect : MonoBehaviour {

    public RaycastHit hit,oldHit;
    public Ray ray;
    public GameObject[] objProps,placableObjs;
    public int objIndex = -1;
    //public string placeableObj;
    public GameObject tower;
    public GameObject[] propList;

    void Start () {
	
	}
    public void setPlaceableObj(int num)
    {
        //placeableObj = name;
        objIndex = num;
    }
	
	// Update is called once per frame
	void Update () {
        //check for props
        propList = GameObject.FindGameObjectsWithTag("Prop");
        //remove props by right click
        if (Input.GetMouseButton(1))
            for (int k = 0; k < propList.Length; k++)
                Destroy(propList[k]);

        if (objIndex>=0)
        {
            makeObj();
        }
        //if (!placeableObj.Equals(""))
           // makeObj();

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
        if (propList.Length.Equals(0))
        {
            GameObject prop = (GameObject)Instantiate(objProps[objIndex], propPos, Quaternion.identity);
            prop.name = "Prop";
            prop.tag = "Prop";
            prop.GetComponent<selectableProp>().propPos = propPos;
            prop.GetComponent<selectableProp>().obj = placableObjs[objIndex];
            objIndex = -1;
        }
        /*
        Vector3 propPos = new Vector3(Input.mousePosition.x, 3.84f, Input.mousePosition.z);
        if (placeableObj.Equals("Tower"))
        {
            placeableObj = "prop";
            GameObject towerProp = (GameObject)Instantiate(tower, propPos, Quaternion.identity);
            towerProp.name = "prop";
            towerProp.GetComponent<selectableProp>().propPos = propPos;
        }
        */

    }
}
