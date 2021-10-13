using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody enemyRb;
    private Transform target;
    public bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
       // enemy = GameObject.FindGameObjectWithTag("Enemy");
        //enemyRb = enemy.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(fire);   
        if (fire)
            transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if (other.tag == "Enemy" && fire == false)
        {
            enemyRb = other.GetComponentInParent<Rigidbody>();
            enemy = enemyRb.gameObject;
            target = enemy.GetComponentInChildren<Transform>();
            fire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" && fire == true)
        {
            enemy = null;
            enemyRb = null;
            target = null;
            fire = false;
        }
    }

    public void EnemyDown()
    {
        enemy = null;
        enemyRb = null;
        target = null;
        fire = false;
    }
}
