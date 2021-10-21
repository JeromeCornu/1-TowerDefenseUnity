using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private Transform goal;
    public Animator animator;

    [HideInInspector]
    public float health = 100f;
    public GameObject deathEffect;
    public GameObject HealthBarUI;
    private GameObject GameManager;
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal").GetComponent<Transform>();

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject, 0);
        }
    }

    public void TakeDamage(float amount)
    {

        if (gameObject.name == "Agent Robuste(Clone)")
        {
            health -= amount / 4f;
            healthBar.fillAmount = health / 100f;
        }
        else
        {
            health -= amount;
            healthBar.fillAmount = health / 100f;
        }

        if (health <= 0 && !isDead)
        {
            Die();
        }

        if (health <= 100f)
        {
            HealthBarUI.SetActive(true);
        }


    }

    void Die()
    {
        isDead = true;

        if (gameObject.name == "Agent Volant(Clone)")
        {
            Destroy(gameObject);
            SoundManager.Instance.PlaySFX("VolantDieSound");
        }
        animator.SetTrigger("Death");

        if (gameObject.name == "Agent Robuste(Clone)")
        {
            SoundManager.Instance.PlaySFX("RobusteDieSound");

        }
        if (gameObject.name == "Agent(Clone)")
        {
            SoundManager.Instance.PlaySFX("SimpleDieSound");

        }

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        GameObject killerTuret = GameObject.Find("CanonOrigin");
        killerTuret.GetComponent<CanonBehaviour>().EnemyDown();

        this.GetComponent<Collider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        this.GetComponent<NavMeshAgent>().enabled = false;
        GameManager.GetComponent<EnemiesCount>().EneCount--;
        if (gameObject.name == "Agent Robuste(Clone)")
            GameManager.GetComponent<money>().Money += 20;
        else
            GameManager.GetComponent<money>().Money += 10;
        Destroy(gameObject, 1.5F);
    }

}
