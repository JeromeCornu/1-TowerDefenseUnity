using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesCount : MonoBehaviour
{
    public int EneCount;
    public TextMeshProUGUI Ui;
    public GameObject Img;
    // Start is called before the first frame update
    void Start()
    {
        EneCount = GameObject.Find("Spawn").GetComponent<Spawn>().enemy.Count;
        //Ui = GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Ui.text = EneCount.ToString();
        if (EneCount <= 0)
            Img.SetActive(true); ;
    }
}
