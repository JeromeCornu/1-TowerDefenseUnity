using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float amount = 10f;
    private Rigidbody BulletRb;

    // Start is called before the first frame update
    void Start()
    {
        BulletRb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameObject Agent = collision.gameObject;
            Agent.GetComponent<Enemy>().TakeDamage(amount);
        }
        Destroy(gameObject);
    }
}
