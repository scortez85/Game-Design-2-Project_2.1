using UnityEngine;
using System.Collections;

public class winningController : MonoBehaviour {

    public GameObject health, score, kills, towers, nugget;
    public GameObject cntrl;
	void Start () {
        //cntrl = GameObject.FindGameObjectWithTag("GameController");
        //health = cntrl.GetComponent<gameControl>().healthText;
       // score = cntrl.GetComponent<gameControl>().scoreText;
       // kills = cntrl.GetComponent<gameControl>().killText;
        //towers = cntrl.GetComponent<gameControl>().towerText;
       // nugget = cntrl.GetComponent<gameControl>().nuggetText;

    }
	public void restartGame()
    {
        Application.LoadLevel(0);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
