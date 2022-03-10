using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private void Update()
    {
        if (FindObjectOfType<PlayerMovement>() != null)
        {
            Vector3 newPosition = FindObjectOfType<PlayerMovement>().transform.position;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
