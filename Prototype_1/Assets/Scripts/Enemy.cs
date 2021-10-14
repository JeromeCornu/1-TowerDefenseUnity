using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    private Transform goal;

    [HideInInspector]
    public float health = 100f;
    public GameObject deathEffect;
    public GameObject HealthBarUI;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal").GetComponent<Transform>();

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
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
        health -= amount;

        healthBar.fillAmount = health / 100f;
        
        
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

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        GameObject killerTuret = GameObject.Find("CanonOrigin");
        killerTuret.GetComponent<CanonBehaviour>().EnemyDown();

        Destroy(gameObject);
    }

}
