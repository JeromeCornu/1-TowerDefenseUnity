using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody BulletRb;
    // Start is called before the first frame update
    void Start()
    {
        BulletRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(BulletRb.velocity.magnitude);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        Destroy(gameObject);
    }
}
