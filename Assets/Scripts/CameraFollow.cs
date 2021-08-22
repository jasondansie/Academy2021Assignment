using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    public Vector3 newPosition;

   


    private void FixedUpdate()
    {
        if (target != null)
        {
            if (target.position.y > newPosition.y)
            {
                MoveCamera();
            }
        }
        
       
        
    }

    private void MoveCamera()
    {
        // Get the current position
        newPosition = transform.position;
        // Only modifies the y axis
        newPosition.y = target.position.y;

        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }
}
