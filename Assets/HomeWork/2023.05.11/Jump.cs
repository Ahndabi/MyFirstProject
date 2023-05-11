using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public int force;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ȥ�� transform.position = Vector3.up * force;
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
