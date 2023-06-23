using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Platform : MonoBehaviour
{
    public float rotatespeed;
    public float touchrotationspeed;
    

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            float mousex = Input.GetAxisRaw("Mouse X");
            transform.Rotate(transform.position.x, -mousex * rotatespeed * Time.deltaTime, transform.position.z);

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(transform.position.x, xDeltaPos * touchrotationspeed * Time.fixedDeltaTime, transform.position.z);
        }

    }
}
