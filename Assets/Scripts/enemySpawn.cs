using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

    public int[] spawnWaves;
    public int spawnSpeed, numEnemies, currentWave; 
    public int maxNumEnemies, spawnSpeedInterval, totalNumEnemies;
    public GameObject enemPrefab;
    private GameObject[] enem;

    public void setWave(int waveNum)
    {
        currentWave = waveNum;
        numEnemies = 0;
    }
    public void nextWave()
    {
        if (currentWave < spawnWaves.Length)
        {
            setWave(currentWave + 1);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<cameraController>().camAngle = 3; 
        }
    }
    void Start () {
            //setWave(1);//use setWave to generate each new wave of enemies 
    }

    // Update is called once per frame
    void Update () {
        if (spawnSpeed < spawnSpeedInterval && numEnemies < maxNumEnemies)
            spawnSpeed++;

        enem = GameObject.FindGameObjectsWithTag("Enemy");

        {
                if (spawnSpeed.Equals(spawnSpeedInterval) &&
                    numEnemies < spawnWaves[currentWave])
            {
                spawnSpeed = 0;

                Instantiate(enemPrefab, transform.position, transform.rotation);
                numEnemies++;
                maxNumEnemies++;
                totalNumEnemies++;
            }
        }

    }
}
