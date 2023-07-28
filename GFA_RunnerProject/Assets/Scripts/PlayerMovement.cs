using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed; // SerializeField inspectordan degistirmemizi saðlar.
    //public float Speed => _speedMultiplier; => sadece read yapýlýr. deðer deðiþtirilemez. deðer degistirmek için get set.

    [SerializeField] private float _horizontalSpeed;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _jumpPower;

    private Vector3 _velocity = new Vector3();
    private bool _isGrounded;
    [SerializeField] private int _maxHorizontalDistance;
    private void Awake() // Olustugu an, constructor
    {
        
    }
    private void Start() // Bir frame baslangýcýnda
    {
        
    }

    private void Update()
    {
        //Transform tr = GetComponent<Transform>(); // GetComponent<Transform>(); == transform
        //GetComponent<Rigidbody>();

        //Input.GetKey(KeyCode.A);
        //Input.GetKeyDown(KeyCode.A);
        //Input.GetKeyUp(KeyCode.A);

        _velocity.z = _forwardSpeed;
        _velocity.y = _rigidbody.velocity.y; // To prevent going object in the air
        _velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(_rigidbody.position.x) > _maxHorizontalDistance)
        {
            var clampedPosition = _rigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_maxHorizontalDistance, _maxHorizontalDistance);
            _rigidbody.position = clampedPosition;
        }
        _rigidbody.velocity = _velocity;
        _velocity.x = 0;

        Debug.DrawRay(transform.position,Vector3.down * 1.05f);
        _isGrounded = Physics.Raycast(transform.position,Vector3.down,1.05f);
       
    }
}

