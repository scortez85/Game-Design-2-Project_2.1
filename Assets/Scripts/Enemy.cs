using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform target;
    private int health, damage;
    private float speed;
    private string enemyType;
    private NavMeshAgent agent;
    public GameObject healthText;
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
        agent.speed = speed;
        target = GameObject.Find("EnemyGoal").transform;
    }
    void Update()
    {
        agent.SetDestination(target.position);
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Destroy(gameObject);
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
        }
    }

    public float GetDistanceToEnd()
    {
        return agent.remainingDistance; 
    }

    public int GetHealth()
    {
        return health;
    }
}
