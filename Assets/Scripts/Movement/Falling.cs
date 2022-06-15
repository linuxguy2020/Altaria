using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float gravity = 1.6f;  //gravity on the moon.

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * gravity);
    }

}
