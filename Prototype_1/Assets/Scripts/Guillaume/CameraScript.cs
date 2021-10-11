using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float rotateHorizontal;
    private float rotateVertical;

    private bool MiddleButtonPressed = false;

    public float sensitivity = 2f;
    private GameObject fixedAngle;
    Vector3 lastPosition;
    bool Stop;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
 

        if (Input.GetMouseButtonDown(2))
        {
            MiddleButtonPressed = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(2))
        {
            MiddleButtonPressed = false;
            Cursor.lockState = CursorLockMode.None;
        }

        //transform.Translate(Vector3.forward * Input.mouseScrollDelta * 100);


    }

    private void FixedUpdate()
    {

        Vector3 velocity = new Vector3(0, 0, 0);
        
        if (Input.GetAxis("Horizontal") > 0)
            velocity += transform.right;
        if (Input.GetAxis("Horizontal") < 0)
            velocity += -transform.right;

        if (Input.GetAxis("Vertical") < 0)
            velocity += -transform.forward;
        if (Input.GetAxis("Vertical") > 0)
            velocity += transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, velocity, 1f))
            Stop = true;
        else
            Stop = false;
        Debug.DrawRay(transform.position, velocity, Color.red);
        if (Stop == false)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * 0.2f);
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * 0.2f, Space.World);
        }


        rotateHorizontal = Input.GetAxis("Mouse X");
        rotateVertical = Input.GetAxis("Mouse Y");
        if (MiddleButtonPressed)
        {
            transform.Rotate(Vector3.up, rotateHorizontal * sensitivity, Space.World);
            transform.Rotate(Vector3.left * rotateVertical * sensitivity);
        }
        
        //print(Input.mouseScrollDelta);
    }

}
