using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemySpawn : MonoBehaviour {

    public int[] spawnWaves;
    public int spawnSpeed, numEnemies, currentWave,enemiesKilled; 
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
            GameObject.Find("crossHair").GetComponent<Image>().enabled = true;
        }
    }

    void endWave()
    {
        //Debug.Log(spawnWaves[currentWave]);
        //Debug.Log(enemiesKilled);

        if (enemiesKilled == spawnWaves[currentWave] *2)
        {
            GameObject[] nuggets = GameObject.FindGameObjectsWithTag("Nugget");
            //Debug.Log("end;");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<cameraController>().camAngle = 2;
            enemiesKilled = 0;
            for (int k = 0; k < nuggets.Length; k++)
                nuggets[k].GetComponent<nuggetValues>().moveToPlayer = true;
            GameObject.Find("crossHair").GetComponent<Image>().enabled = false;
            
        }
    }
    void Start () {
            //setWave(1);//use setWave to generate each new wave of enemies 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*
        for (int k = 0; k < enem.Length; k++)
        {
            enem[k].GetComponent<NavMeshAgent>().speed += (currentWave/0.05f);
            enem[k].GetComponent<Enemy>().setHealth(100 + (currentWave * 25 ));
        }
        */
        if (currentWave == spawnWaves.Length - 1 && numEnemies - enemiesKilled / 2 == 0)
        {
            //Debug.Log("You win");//add winning screen
            Application.LoadLevel(2);
        }
        if (currentWave < spawnWaves.Length)
            endWave();
        
    }
    public void addKill()
    {
        enemiesKilled += 1;
        return;
    }
    void Update () {
        enem = GameObject.FindGameObjectsWithTag("Enemy");
        
        
        if (spawnSpeed < spawnSpeedInterval && numEnemies < maxNumEnemies)
            spawnSpeed++;

        

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
