using UnityEngine;
using System.Collections;

public class selectableProp : MonoBehaviour {

    public Vector3 propPos,posOffset;
    public RaycastHit hit;
    bool ableToPlace = true;
    public GameObject obj,normProp,unableProp;

    //public SkinnedMeshRenderer[] normMesh,currentMesh;
   // public Material unPlaceableMesh;

    void Start()
    {
        normProp.SetActive(false);
        unableProp.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //place object
        if (Input.GetMouseButton(0))
        {
            GameObject newTower = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            newTower.name = "Tower";
            newTower.tag = "Tower";
            Destroy(gameObject);
        }
        */

        Vector3 mousePos = Input.mousePosition;
        if (obj.name.Equals("Tower 1"))
            mousePos.z = 136F;
        else if (obj.name.Equals("realSherrif"))
            mousePos.z = 136f;

        Vector3 objPos = Camera.current.ScreenToWorldPoint(mousePos);
        transform.position = objPos;

    }

    void OnCollisionStay(Collision col)
    {
        //change mesh
        if (col.gameObject.tag.Equals("Placeable") && col.gameObject.GetComponent<towerPlacement>().getPlaceable().Equals(true))
        {
            normProp.SetActive(true);
            unableProp.SetActive(false);
        }
        else
        {
            normProp.SetActive(false);
            unableProp.SetActive(true);
        }

            if (Input.GetMouseButton(0) && col.gameObject.tag.Equals("Placeable") && col.gameObject.GetComponent<towerPlacement>().getPlaceable().Equals(true))
        {
            GameObject newTower = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            Vector3 oldPos = newTower.transform.position;
            oldPos.x = col.transform.position.x;
            oldPos.z = col.transform.position.z;
            newTower.transform.position = oldPos;
            newTower.name = obj.name;
            newTower.tag = "Tower";
            col.gameObject.GetComponent<towerPlacement>().setPlaceable(false);
            newTower.GetComponent<Tower>().selected = false;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {

        //if (!col.gameObject.tag.Equals("Terrain"))
            //Debug.Log(col.collider.tag);
    }
}   
