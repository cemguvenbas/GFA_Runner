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

    private Vector3 _velocity = new Vector3();
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
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
    }
}

