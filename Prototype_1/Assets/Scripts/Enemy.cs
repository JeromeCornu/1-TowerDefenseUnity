using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 100;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {

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

    void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            //Die();
        }
    }

    // BRAKEYS Health ennemies https://www.youtube.com/watch?v=UKs1qO8w7qc a 5 min

}
