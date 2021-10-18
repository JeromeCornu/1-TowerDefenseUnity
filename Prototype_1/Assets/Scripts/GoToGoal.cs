using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGoal : MonoBehaviour
{
    private GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameManager.GetComponent<BaseHealth>().health--;
            GameManager.GetComponent<EnemiesCount>().EneCount--;
            Destroy(other.gameObject, 1.5f);
        }
    }

}
