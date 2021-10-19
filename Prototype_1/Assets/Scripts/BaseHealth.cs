using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public TextMeshProUGUI HP;
    public GameObject Defeat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = health.ToString();
        if (health <= 0)
            Defeat.SetActive(true);
    }
}
