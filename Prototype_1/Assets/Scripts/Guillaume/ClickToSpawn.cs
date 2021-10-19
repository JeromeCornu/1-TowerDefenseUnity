using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickToSpawn : MonoBehaviour
{
    public GameObject turet;
    public bool activated;
    GameObject NodeUI;
    GameObject selectedTuret;
    private GameObject GameManager;
    public int TuretPrice;
    

    
    // Start is called before the first frame update
    void Start()
    {
        NodeUI = GameObject.Find("Node UI");
        GameManager = GameObject.Find("GameManager");
        NodeUI.SetActive(false);
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

                if (hit.collider.tag != "Turet" && hit.collider.tag != "UI" && GameManager.GetComponent<money>().Money >= 100)
                {
                    Instantiate(turet, hit.point, Quaternion.identity);
                    GameManager.GetComponent<money>().Money -= TuretPrice;
                }
                else if (hit.collider.tag == "Turet")
                {
                    NodeUI.transform.position = hit.transform.position;
                    NodeUI.SetActive(true);
                    selectedTuret = hit.collider.gameObject;
                }
                else if (hit.collider.tag != "UI")
                    NodeUI.SetActive(false);
            }
        }
    }

    public void Upgrade()
    {
        if (GameManager.GetComponent<money>().Money >= 75)
        {
            selectedTuret.transform.Find("turet").Find("CanonOrigin").Find("canon").GetComponentInChildren<bulletSpawner>().timer *= 0.85f;
            GameManager.GetComponent<money>().Money -= 75;
        }
    }

    private void OnMouseDown()
    {

    }

    public void Sell()
    {
        Destroy(selectedTuret);
        NodeUI.SetActive(false);
        GameManager.GetComponent<money>().Money += 90;
    }
}

