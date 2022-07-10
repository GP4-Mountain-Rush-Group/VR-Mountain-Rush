using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float maxSpeed = 30f;
    [SerializeField] float turnSpeed = 0.1f;
    [SerializeField]float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward*-1 * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed, 0);
        }

        Vector3 vel = rb.velocity;
        if (vel.magnitude > maxSpeed)
        {
            rb.velocity = vel.normalized * maxSpeed;
        }

    }

}
