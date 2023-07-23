using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed; // SerializeField inspectordan degistirmemizi saðlar.
    //public float Speed => _speedMultiplier; => sadece read yapýlýr. deðer deðiþtirilemez. deðer degistirmek için get set.

    [SerializeField] private float _horizontalSpeed;
    private void Start()
    {
        
    }

    private void Update()
    {
        //Transform tr = GetComponent<Transform>(); // GetComponent<Transform>(); == transform
        //GetComponent<Rigidbody>();

        //Input.GetKey(KeyCode.A);
        //Input.GetKeyDown(KeyCode.A);
        //Input.GetKeyUp(KeyCode.A);
        
        Vector3 velocity = Vector3.forward * _forwardSpeed;
        velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed; // A = -1, D = 1
        transform.position += velocity * Time.deltaTime;

    }
}

