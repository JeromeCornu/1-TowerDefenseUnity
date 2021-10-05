using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickToSpawn : MonoBehaviour
{
    public Transform target;
    public float distance = Mathf.Infinity;
    public GameObject turet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("event getMouseButton");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("RayCast ok");

                Debug.DrawLine(ray.origin, hit.point, Color.red, 3f);

                Debug.Log(hit.point);
                Instantiate(turet, hit.point, Quaternion.identity);
            }
        }
    }
}

