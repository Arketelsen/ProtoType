using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform currentTransform;
    [SerializeField] private float _speed, _walkSpeed, _runSpeed, _crouchSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float _fallSpeed;
    [SerializeField] private bool _isCrouched = false;
    [SerializeField] private float _sensitivity = 4f;


    private Vector3 jumpVector;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField] private float raycastDistance;

    private Transform mainCameraTransform;
   
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Crouch();
    }
    private void FixedUpdate()
    {
        Movement();
        
    }


    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        //float mouseX = Input.GetAxis("Mouse X");
        
        Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput).normalized * _speed * Time.fixedDeltaTime;  //walking
        Vector3 newPostion = rb.position + rb.transform.TransformDirection(inputVector); //walking
        //Vector3 newRotation = transform.localEulerAngles;
        //newRotation.y += mouseX * _sensitivity;
        //transform.localEulerAngles = newRotation;

        if (Input.GetKey(KeyCode.LeftShift) && _isCrouched == false && Input.GetAxisRaw("Vertical") > 0)
        {
            //speed while standing
            _speed = _runSpeed;
            rb.MovePosition (newPostion);
            
        }
        else if (_isCrouched == true)
        {
            //speed while crouched
            _speed = _crouchSpeed;
            rb.MovePosition(newPostion);
        }
        else
        {
            //normal speed
            _speed = _walkSpeed;
            rb.MovePosition(newPostion);
        }

    }
    
    private void Crouch()
    {

        if (Input.GetKeyDown(KeyCode.C) && _isCrouched == false)
        {
            //Crouch
            Debug.Log("Im Crouched");
            _isCrouched = true;
            transform.localScale -= new Vector3(0, .5f, 0);
            StartCoroutine(CrouchTimer());
            
        }
        
        else if (Input.GetKeyDown(KeyCode.C) && _isCrouched == true)
        {
            //stand up
            Debug.Log("Im Standing");
            _isCrouched = false;
            transform.localScale += new Vector3(0, .5f, 0);
            StartCoroutine(CrouchTimer());
        }
            
        
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance); 
    }

    IEnumerator CrouchTimer()
    {
        
        yield return new WaitForSeconds(.5f);
    }
}
