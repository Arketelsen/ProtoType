using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]private float _sensitivity = 2f;
    [SerializeField]private float _minPitch, _maxPitch;

    [SerializeField] private Transform currentPlayerTransform, currentHeadTransform;
    private Vector3 newPlayerRotation;
    private Vector3 newHeadRotation;

    // Start is called before the first frame update
    void Start()
    {

        currentPlayerTransform = transform.parent.GetComponentInParent<Transform>();
        newPlayerRotation = currentPlayerTransform.localEulerAngles;
        currentHeadTransform = transform.GetComponent<Transform>();
        newHeadRotation = currentPlayerTransform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        float _mouseX = Input.GetAxis("Mouse X");
        
        
        
        newHeadRotation.x += _mouseY * _sensitivity * -1;
        newPlayerRotation.y += _mouseX * _sensitivity;
        float yRotation = transform.rotation.y;

        currentPlayerTransform.localEulerAngles = newPlayerRotation;
        newHeadRotation.x = Mathf.Clamp(newHeadRotation.x, _minPitch, _maxPitch);
        currentHeadTransform.localEulerAngles = newHeadRotation;
    }
}
