using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickToSpawn : MonoBehaviour
{
    public GameObject turet;
    public bool activated;
    GameObject NodeUI;
    

    
    // Start is called before the first frame update
    void Start()
    {
        NodeUI = GameObject.Find("Node UI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && activated == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.Log("event getMouseButton");
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("RayCast ok");

                Debug.DrawLine(ray.origin, hit.point, Color.red, 3f);

                //Debug.Log(hit.point);
                print(hit.collider.tag);
                if (hit.collider.tag != "Turet")
                    Instantiate(turet, hit.point, Quaternion.identity);
                else
                {
                    NodeUI.transform.position = hit.transform.position;
                }
            }
        }
    }

    private void OnMouseDown()
    {

    }
}

