using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float _sensitivity = 1f;
    [SerializeField]private float _minPitch, _maxPitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y") * _sensitivity;
        float _mouseX = Input.GetAxis("Mouse X") * _sensitivity;


        //_mouseY = Mathf.Clamp(_mouseX, _minPitch, _maxPitch);

        transform.eulerAngles = new Vector3(_mouseY, _mouseX, 0f);
    }
}
