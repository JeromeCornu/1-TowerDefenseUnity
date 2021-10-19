using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickToSpawn : MonoBehaviour
{
    public GameObject turet;
    public bool activated;
    GameObject NodeUI;
    bulletSpawner selectedTuret;
    private GameObject GameManager;
    

    
    // Start is called before the first frame update
    void Start()
    {
        NodeUI = GameObject.Find("Node UI");
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") /*&& activated == true*/)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.Log("event getMouseButton");
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("RayCast ok");

                Debug.DrawLine(ray.origin, hit.point, Color.red, 3f);

                //Debug.Log(hit.point);

                if (hit.collider.tag != "Turet" && hit.collider.tag != "UI")
                    Instantiate(turet, hit.point, Quaternion.identity);
                else if (hit.collider.tag != "UI")
                {
                    NodeUI.transform.position = hit.transform.position;
                    selectedTuret = hit.collider.transform.Find("turet").Find("CanonOrigin").Find("canon").GetComponentInChildren<bulletSpawner>();
                }
            }
        }
    }

    public void Upgrade()
    {
        selectedTuret.timer *= 0.85f;
    }

    private void OnMouseDown()
    {

    }
}

