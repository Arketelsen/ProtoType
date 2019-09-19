using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float _sensitivity = 2f;
    [SerializeField]private float _minPitch, _maxPitch;

    [SerializeField]private Transform currentTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentTransform = transform.parent.GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = currentTransform.localEulerAngles;
        _mouseY = Mathf.Clamp(_mouseY, _minPitch, _maxPitch);
        newRotation.x = _mouseY * _sensitivity * -1;
        newRotation.y = _mouseX * _sensitivity;
        

        transform.localEulerAngles = newRotation;
    }
}
