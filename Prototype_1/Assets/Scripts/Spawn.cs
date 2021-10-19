using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    public GameObject firstobjectToSpawn;
    public GameObject secondToSpawn;
    public GameObject thirdToSpawn;
    //public static int firstNumberToSpawn = 5;       //ennemi simple
    //public static int secondNumberToSpawn = 2;   //ennemi robuste
    //public static int thirdNumberToSpawn = 3;    //ennemi volant
    //private int numberToSpawn = firstNumberToSpawn + secondNumberToSpawn + thirdNumberToSpawn;
    float spawnTimer = 0.7f;

    public List<GameObject> enemy;
    int listLenght;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        listLenght = GameObject.Find("Spawn").GetComponent<Spawn>().enemy.Count;
        i = listLenght-1;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (i >= 0 && spawnTimer <= 0)
        {
            var Agent = Instantiate(enemy[i], this.transform.position, this.transform.rotation);
            i--;
            spawnTimer = 1f;
        }
    }


}
