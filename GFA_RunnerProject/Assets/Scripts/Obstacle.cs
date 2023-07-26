using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log(collision.rigidbody.name);
            GameInstance.Instance.Lose();
        }
        else
        {
            collision.rigidbody.AddForce(Vector3.up * 30, ForceMode.Impulse);
            //var normal =  collision.GetContact(0).normal; 
        }
    }
    
}
