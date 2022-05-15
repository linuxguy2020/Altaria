using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMovement : MonoBehaviour
{
    //velocità di movimento
    public float speed = 0.8f;
    //asse su cui viene eseguito il movimento
    public char axis = 'x';
    //indicatore della direzione dello spostamento
    public bool positiveDirection = true;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            MoveObject();
        }
    }


    void MoveObject()
    {

        if (axis == 'y')
        {
            if (positiveDirection == true)
            {
                rb.AddForce(Vector3.up * rb.mass * speed);
            }
            else
            {
                rb.AddForce(Vector3.down * rb.mass * speed);
            }
        }
        else if (axis == 'z')
        {
            if (positiveDirection == true)
            {
                rb.AddForce(Vector3.forward * rb.mass * speed);
            }
            else
            {
                rb.AddForce(Vector3.back * rb.mass * speed);
            }
        }
        else
        {
            if (positiveDirection == true)
            {
                rb.AddForce(Vector3.right * rb.mass * speed);
            }
            else
            {
                rb.AddForce(Vector3.left * rb.mass * speed);
            }
        }
    }

}
