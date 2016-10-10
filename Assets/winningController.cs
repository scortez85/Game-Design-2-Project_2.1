using UnityEngine;
using System.Collections;

public class winningController : MonoBehaviour {

    public GameObject health, score, kills, towers, nugget;
    public GameObject cntrl;
	void Start () {
        

    }
	public void restartGame()
    {
        Application.LoadLevel(0);
    }
	// Update is called once per frame
	void Update () {
        cntrl = GameObject.FindGameObjectWithTag("GameController");
        cntrl.GetComponent<gameControl>().healthText = health;
        cntrl.GetComponent<gameControl>().scoreText = score;
        cntrl.GetComponent<gameControl>().killText = kills;
        cntrl.GetComponent<gameControl>().towerText = towers;
        cntrl.GetComponent<gameControl>().nuggetText = nugget;
    }
}
