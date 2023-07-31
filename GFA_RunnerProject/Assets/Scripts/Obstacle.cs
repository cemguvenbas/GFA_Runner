using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            var hitNormal = collision.GetContact(0).normal;
            
            var hitDot = Vector3.Dot(hitNormal, Vector3.forward); // Bu iki vektor tamamen paralelse 1. / zit yone bakiyorlarsa -1. / dik ise 0
            
            if (hitDot > 0.99f)
            {
                GameInstance.Instance.Lose();
                //Destroy(collision.gameObject);
            }
        }
        else
        {
            // �arptigi yone dogru ivme verebiliriz.
            var normal = collision.GetContact(0).normal;
            collision.rigidbody.AddForce(normal * 30, ForceMode.Impulse);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            Debug.Log("CollisionExit: " + collision.rigidbody.name);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            Debug.Log("CollisionStay: " + collision.rigidbody.name);
        }
    }
}
