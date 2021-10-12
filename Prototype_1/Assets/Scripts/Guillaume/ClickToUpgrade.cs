using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToUpgrade : MonoBehaviour
{
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.DrawLine(ray.origin, hit.point, Color.red, 3f);
                print(hit.collider.name);
                if (hit.transform.tag == "Turet")
                {
                    print("cast hitting turet");
                    hit.collider.gameObject.GetComponentInChildren<Canvas>().enabled = false;
                }
            }
        }
    }
}
