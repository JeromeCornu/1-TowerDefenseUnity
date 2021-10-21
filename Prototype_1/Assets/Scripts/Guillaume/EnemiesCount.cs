using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemiesCount : MonoBehaviour
{
    public int EneCount;
    public TextMeshProUGUI Ui;
    public GameObject Victory;
    public bool win = false;
    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("GameManager");
        EneCount = GameObject.Find("Spawn").GetComponent<Spawn>().enemy.Count;
        EneCount += GameObject.Find("FlyingSpawn").GetComponent<FlyingSpawn>().enemy.Count;
        //Ui = GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Ui.text = EneCount.ToString();
        if (EneCount <= 0 && win == false && GameManager.GetComponent<BaseHealth>().health > 0)
        {
            win = true; ;
            SoundManager.Instance.PlaySFX("VictorySound");
            Victory.SetActive(true);
        }
    }
}
