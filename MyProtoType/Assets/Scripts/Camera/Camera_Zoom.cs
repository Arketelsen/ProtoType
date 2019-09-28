using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{

    private float _scrollSpeed = 2f;

    [SerializeField] private float _minZoom, _maxZoom;

    [SerializeField] private Transform target;
    [SerializeField]
    private Camera _cameraMain, _cameraSecondary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distFromTarget = Vector3.Distance(transform.position, target.position);
        //Vector3 resetDistance = new Vector3(0, 0, target.transform.position.z - 1);
        float tempDist = 2;
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distFromTarget > _minZoom)
        {
            float CameraMove = _scrollSpeed * Time.deltaTime * 10f ;
            transform.position = Vector3.MoveTowards(transform.position, target.position, CameraMove);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && distFromTarget < _maxZoom)
        {
            float CameraMove = _scrollSpeed * Time.deltaTime * 10f ;
            transform.position = Vector3.MoveTowards(transform.position, target.position, -CameraMove);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && distFromTarget <= _minZoom)
        {
            tempDist = distFromTarget;
            _cameraMain.enabled = false;
            _cameraSecondary.enabled = true;

        }
        else if (distFromTarget > tempDist)
        {
            _cameraMain.enabled = true;
            _cameraSecondary.enabled = false;
        }
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        Debug.Log(distFromTarget);
    }
}
