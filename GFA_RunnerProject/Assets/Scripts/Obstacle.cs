using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            var hitNormal =  collision.GetContact(0).normal;
            var hitDot = Vector3.Dot(hitNormal, Vector3.forward);

            if (hitDot > 0.99f)
            {
                GameInstance.Instance.Lose();
            }
            //Debug.Log(collision.rigidbody.name);
            
        }
        else
        {

            collision.rigidbody.AddForce(Vector3.up * 30, ForceMode.Impulse);
            //var normal =  collision.GetContact(0).normal; 
        }
    }
    
}
