using UnityEngine;
using System.Collections;

public class selectableProp : MonoBehaviour {

    public Vector3 propPos;
    public RaycastHit hit;
    bool ableToPlace = true;
    public GameObject obj;

    void Start()
    {

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
        mousePos.z = 136F;

        Vector3 objPos = Camera.current.ScreenToWorldPoint(mousePos);
        transform.position = objPos;

    }

    void OnCollisionStay(Collision col)
    {
        //if (!col.gameObject.tag.Equals("Terrain"))
            //Debug.Log(col.collider.tag);

        if (Input.GetMouseButton(0) && col.gameObject.tag.Equals("Placeable") && col.gameObject.GetComponent<towerPlacement>().getPlaceable().Equals(true))
        {
            GameObject newTower = (GameObject)Instantiate(obj, transform.position, transform.rotation);
            Vector3 oldPos = newTower.transform.position;
            oldPos.x = col.transform.position.x;
            oldPos.z = col.transform.position.z;
            newTower.transform.position = oldPos;
            newTower.name = "Tower";
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
