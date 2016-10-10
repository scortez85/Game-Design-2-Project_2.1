using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform target;
    private int health, damage,nuggetMin,nuggetMax;
    private float speed;
    private string enemyType;
    private NavMeshAgent agent;
    public GameObject healthText,nugget;
    private AudioSource enemSfx;
    public AudioClip enemDeath,enemNorm;
    public int randSfxNum,sfxTime;


    public Enemy()
    {
        switch(enemyType)
        {
            case "Chicken Bandit":
                health = 100;
                damage = 1;
                speed = 20;
                break;
            case "Chicken Overlord":
                health = 1000;
                speed = 5f;
                damage = 50;
                break;
            case "Robot Chicken":
                health = 175;
                speed = 155f;
                damage = 5;
                break;
            default:
                health = 100;
                damage = 1;
                speed = 20;
                break;

        }
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemSfx = GetComponent<AudioSource>();
        agent.speed = speed;
        target = GameObject.Find("EnemyGoal").transform;
        nuggetMin = 10;
        nuggetMax = 40;
        randSfxNum = Random.Range(100, 500);
    }
    void Update()
    {
        //sound 
        if (sfxTime < 500)
            sfxTime++;
        if (sfxTime.Equals(randSfxNum))
        {
            enemSfx.Play();
            sfxTime = 0;
        }

        agent.SetDestination(target.position);
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Destroy(gameObject);
                    GameObject.Find("GameController").GetComponent<gameControl>().setHealth(-1);
                }
            }
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        healthText.GetComponent<TextMesh>().text = health.ToString();
        //healthText.transform.LookAt(Camera.current.transform);
        healthText.transform.rotation = GameObject.Find("Player").transform.rotation;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            health-=col.gameObject.GetComponent<Bullet>().GetDamage();
            col.gameObject.GetComponent<Bullet>().SubrtractHealth(1);
            GameObject.Find("GameController").GetComponent<gameControl>().setScore(col.gameObject.GetComponent<Bullet>().getScoreValue());
            enemSfx.clip = enemDeath;
            enemSfx.Play();
        }

    }
    void OnCollisionExit()
    {
        enemSfx.clip = enemNorm;

    }

    public float GetDistanceToEnd()
    {
        return agent.remainingDistance; 
    }

    public int GetHealth()
    {
        return health;
    }
    public void OnDestroy()
    {
        
        //send value to gamecontroller
        {
            GameObject.Find("GameController").GetComponent<gameControl>().kills += 1;
           GameObject nuggetObj = (GameObject) Instantiate(nugget, transform.position, transform.rotation);
            nuggetObj.GetComponent<nuggetValues>().nuggetValue = Random.Range(nuggetMin, nuggetMax);
            GameObject.Find("EnemySpawn").GetComponent<enemySpawn>().addKill();
            return;
        }
    }
}
