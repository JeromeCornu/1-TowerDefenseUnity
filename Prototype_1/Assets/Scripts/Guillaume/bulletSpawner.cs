using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject BulletParent;
    public float timer = 0.2f;
    private GameObject target;
    private bool fire;
    private GameObject turet;
    float i;

    // Start is called before the first frame update
    void Start()
    {
        
        BulletParent = new GameObject();
        if (GameObject.Find("BulletParent") == null)
            BulletParent.name = "BulletParent";
    }

    // Update is called once per frame
    void Update()
    {
        //print(fire);
        fire = GetComponentInParent<CanonBehaviour>().fire;
        i -= Time.deltaTime;
        if(i <= 0 && fire == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation, this.transform);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 2600);
            bullet.transform.parent = BulletParent.transform;
            Destroy(bullet, 2f);
            i = timer;
        }
    }

    private Vector3 predictedPosition(Vector3 targetPosition, Vector3 shooterPosition, Vector3 targetVelocity, float projectileSpeed)
    {
        Vector3 displacement = targetPosition - shooterPosition;
        float targetMoveAngle = Vector3.Angle(-displacement, targetVelocity) * Mathf.Deg2Rad;
        //if the target is stopping or if it is impossible for the projectile to catch up with the target (Sine Formula)
        if (targetVelocity.magnitude == 0 || targetVelocity.magnitude > projectileSpeed && Mathf.Sin(targetMoveAngle) / projectileSpeed > Mathf.Cos(targetMoveAngle) / targetVelocity.magnitude)
        {
            Debug.Log("Position prediction is not feasible.");
            return targetPosition;
        }
        //also Sine Formula
        float shootAngle = Mathf.Asin(Mathf.Sin(targetMoveAngle) * targetVelocity.magnitude / projectileSpeed);
        return targetPosition + targetVelocity * displacement.magnitude / Mathf.Sin(Mathf.PI - targetMoveAngle - shootAngle) * Mathf.Sin(shootAngle) / targetVelocity.magnitude;
    }

}


