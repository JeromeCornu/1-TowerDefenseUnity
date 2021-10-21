using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    private float rotateHorizontal;
    private float rotateVertical;
    private Transform CamPointer;
    private bool MiddleButtonPressed = false;

    public float sensitivity = 2f;
    private GameObject fixedAngle;
    Vector3 lastPosition;
    bool Stop;
    bool Ctrl;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        CamPointer = GameObject.Find("CamPointer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Camera>().fieldOfView -= Input.mouseScrollDelta[1];
        var euler = transform.rotation.eulerAngles;
        var rot = Quaternion.Euler(0, euler.y, 0);
        CamPointer.transform.rotation = rot;
        CamPointer.transform.position = transform.position + CamPointer.forward;
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
        if (Input.GetKey(KeyCode.LeftControl))
            Ctrl = true;
        else
            Ctrl = false;
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
            velocity += -CamPointer.transform.forward;
        if (Input.GetAxis("Vertical") > 0)
            velocity += CamPointer.transform.forward;
        if (Input.GetAxis("Jump") > 0)
            velocity += Vector3.up;
        if (Ctrl)
            velocity -= Vector3.up;

        if (Physics.Raycast(transform.position, velocity, 1f))
            Stop = true;
        else
            Stop = false;
        Debug.DrawRay(transform.position, velocity, Color.red);
        if (Stop == false)
        {
            Vector3 Dir = CamPointer.transform.position - transform.position;
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * 0.2f);
            transform.Translate(Dir * Input.GetAxis("Vertical") * 0.2f, Space.World);
            transform.Translate(Vector3.up * Input.GetAxis("Jump") * 0.2f, Space.World);
            if (Ctrl)
                transform.Translate(-Vector3.up * 0.2f, Space.World);
            
        }


        rotateHorizontal = Input.GetAxis("Mouse X");
        rotateVertical = Input.GetAxis("Mouse Y");
        if (MiddleButtonPressed)
        {
            transform.Rotate(Vector3.up, rotateHorizontal * sensitivity, Space.World);
            transform.Rotate(Vector3.left * rotateVertical * sensitivity);
        }

        print(Input.mouseScrollDelta.magnitude);
    }

}
