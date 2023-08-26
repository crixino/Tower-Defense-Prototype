using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    private float speed = 10f;
    private float distance = 10;
    private Camera cam;

    private float minFOV = 30;
    private float maxFOV = 100;
    private float sensitivity = 20f;

    private float prevMouseScrollWheel = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        CameraZoom();
    }

    private void CameraMovement()
    {
        if(Input.mousePosition.x < 40 && Input.mousePosition.x > 0 && Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height)
        {
            MoveLeft();
        }
        if (Input.mousePosition.y < 40 && Input.mousePosition.y > 0 && Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width)
        {
            MoveDown();
        }  
        if (Input.mousePosition.x > Screen.width-40 && Input.mousePosition.x < Screen.width && Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height)
        {
            MoveRight();
        }
        if (Input.mousePosition.y > Screen.height-40 && Input.mousePosition.y < Screen.height && Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width)
        {
            MoveUp();
        }
    }

    private void CameraZoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != prevMouseScrollWheel)
        {
            float fov = cam.fieldOfView;
            fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFOV, maxFOV);
            cam.fieldOfView = fov;
            prevMouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        }
    }

    private void MoveLeft()
    {
        this.cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z - distance), speed * Time.deltaTime);
    }

    private void MoveRight()
    {
        this.cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(cam.transform.position.x , cam.transform.position.y, cam.transform.position.z + distance), speed * Time.deltaTime);
    }

    private void MoveUp()
    {
        this.cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(cam.transform.position.x - distance, cam.transform.position.y, cam.transform.position.z), speed * Time.deltaTime);
    }

    private void MoveDown()
    {
        this.cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(cam.transform.position.x + distance, cam.transform.position.y, cam.transform.position.z), speed * Time.deltaTime);
    }
}
