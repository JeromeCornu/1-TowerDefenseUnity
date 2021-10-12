using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject cam;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
