using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float size;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraMovement1();
        CameraZoom();
      
    }

    public void CameraMovement1()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

    public void CameraZoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (size> 0)
            {
                size -= 1;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (size < 20)
            {
                size += 1;
            }
        }
        GetComponent<Camera>().orthographicSize = size;
    }
}
