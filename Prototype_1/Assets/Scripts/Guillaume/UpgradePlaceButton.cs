using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradePlaceButton : MonoBehaviour
{


    // Start is called before the first frame update
    public Button btn;
    private ClickToSpawn SpawnScript;
    private ClickToUpgrade UpgradeScript;
    void Start()
    {
        SpawnScript = GetComponent<ClickToSpawn>();
        UpgradeScript = GetComponent<ClickToUpgrade>();
        SpawnScript.activated = true;
        UpgradeScript.activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swap()
    {
        if(SpawnScript.activated)
        {
            SpawnScript.activated = false;
            UpgradeScript.activated = true;
        }
        else
        {
            SpawnScript.activated = true;
            UpgradeScript.activated = false;
        }
    }
}
