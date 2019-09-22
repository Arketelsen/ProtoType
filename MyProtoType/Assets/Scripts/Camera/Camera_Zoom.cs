using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{

    private float _scrollSpeed = 2f;

    [SerializeField] private float _minZoom, _maxZoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.z > _minZoom)
        {
            //Camera.main.orthographicSize = Camera.main.orthographicSize -= _scrollSpeed;
            transform.Translate(0, 0, _scrollSpeed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.z > _maxZoom)
        {
            //Camera.main.orthographicSize = Camera.main.orthographicSize += _scrollSpeed;
            
        }
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }
}
