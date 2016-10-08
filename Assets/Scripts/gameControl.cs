using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameControl : MonoBehaviour {

    //this will hold values for the player and the game
    public int cost, damage, speed, health, score, kills,nuggets;
    public GameObject healthText, scoreText, killText, towerText, nuggetText;
    //public Collision hitByObj;
    public gameControl()
    {
        this.health = 100;
        this.nuggets = 200;

    }
	void Start () {
        this.health = 100;
        this.nuggets = 600;

    }
    public void setScore(int value)
    {
        score += value;
    }
    public void setHealth (int value)
    {
        health += value;
    }
    
    public void setNugget(int value)
    {
        nuggets += value;
    }
	
	// Update is called once per frame
	void Update () {
        //snag tower count
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        healthText.GetComponent<Text>().text = health.ToString();
        scoreText.GetComponent<Text>().text = score.ToString();
        killText.GetComponent<Text>().text = kills.ToString();
        towerText.GetComponent<Text>().text = towers.Length.ToString();
        nuggetText.GetComponent<Text>().text = nuggets.ToString();

	
	}
}
