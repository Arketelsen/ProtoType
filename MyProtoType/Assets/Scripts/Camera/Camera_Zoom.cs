using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{

    private float _scrollSpeed = 2f;
    private float distance = -3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;

        if (distance < 1)
        {
            distance = 1;
            
        }
        if (distance > 6)
        {
            distance = 6;
        }
    }
}
