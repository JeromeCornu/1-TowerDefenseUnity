using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretBase : MonoBehaviour
{
    public bool Tureted;
    public GameObject BluePrint;
    private GameObject SpawnedBP;

    // Start is called before the first frame update
    void Start()
    {
        Tureted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (!Tureted)
            SpawnedBP = Instantiate(BluePrint, transform.position + transform.up * 2.69f, Quaternion.identity);
    }

    private void OnMouseExit()
    {
        Destroy(SpawnedBP);
    }

    private void OnMouseDown()
    {
        Destroy(SpawnedBP);
    }
}
