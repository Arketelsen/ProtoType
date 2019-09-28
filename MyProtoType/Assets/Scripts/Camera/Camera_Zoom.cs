using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{

    private float _scrollSpeed = 2f;

    [SerializeField] private float _minZoom, _maxZoom;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distFromTarget = Vector3.Distance(transform.position, target.position);
        Vector3 resetDistance = new Vector3(0, 0, -1);

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distFromTarget > _minZoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _scrollSpeed);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && distFromTarget < _maxZoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, -_scrollSpeed);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && distFromTarget == 0)
        {
            
            transform.position = resetDistance;
        }
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        Debug.Log(distFromTarget);
    }
}
