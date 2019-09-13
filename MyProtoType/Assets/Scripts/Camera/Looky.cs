using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looky : MonoBehaviour
{

    [SerializeField] private float _sensitivity = 1f;
    private int _invertY = -1;
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        _mouseY = Mathf.Clamp(_mouseY, pitchMinMax.x, pitchMinMax.y);

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x += _mouseY * _sensitivity * _invertY;
        
        transform.localEulerAngles = newRotation;
    }
}
