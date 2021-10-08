using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * 0.02f);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * 0.02f, Space.World);
    }
}
