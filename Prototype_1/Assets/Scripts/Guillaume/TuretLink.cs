using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretLink : MonoBehaviour
{
    public GameObject TuretBase;
    public GameObject Lvl1;
    public GameObject Lvl2;
    public GameObject Lvl3;
    public int lvl;
    // Start is called before the first frame update
    void Start()
    {
        lvl = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (lvl == 2)
        {
            Lvl1.SetActive(false);
            Lvl2.SetActive(true);
        }
        if (lvl >= 3)
        {
            Lvl2.SetActive(false);
            Lvl3.SetActive(true);
        }
    }
}
