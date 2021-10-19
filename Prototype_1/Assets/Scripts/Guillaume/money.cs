using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class money : MonoBehaviour
{
    public int Money;
    public TextMeshProUGUI gold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = Money.ToString();
    }
}
