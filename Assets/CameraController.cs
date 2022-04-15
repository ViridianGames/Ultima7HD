using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float movementSpeed;
    public float movementAccelerator;
    public float movementTime;
    public float rotationAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 zoomAmount;
    public Vector3 newZoom;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //    int speed = 10;

        //// Debug.LogError("ATS: Script is running.");
        //    Vector3 motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //    transform.position += motion;

        //    if(Input.GetKey(KeyCode.A))
        //    {

        //    }

        //    if (Input.GetKey(KeyCode.Q))
        //    {
        //        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
        //        //transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        //    }
        //    if (Input.GetKey(KeyCode.E))
        //    {
        //        transform.RotateAround(transform.position, Vector3.up, -speed * Time.deltaTime);
        //        //transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
        //    }

        //    if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //    {
        //        transform.Translate(Vector3.forward * speed * 1000 * Time.deltaTime);
        //    }
        //    if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //    {
        //        transform.Translate(Vector3.back * speed * 1000 * Time.deltaTime);
        //    }
    }

    private void LateUpdate()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float thisMovementSpeed = movementSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            thisMovementSpeed *= movementAccelerator;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * thisMovementSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition -= (transform.right * thisMovementSpeed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition -= (transform.forward * thisMovementSpeed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * thisMovementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        if (Input.GetKey(KeyCode.R) || Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            newZoom += zoomAmount;

        }

        if (Input.GetKey(KeyCode.F) || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            newZoom -= zoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }
}

