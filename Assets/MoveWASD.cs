using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Method method;

    [SerializeField] float force;
    [SerializeField] float velocity;

    Vector3 moveDir;

    public enum Method
    {
        Force,
        Velocity
    }

    void Update()
    {
        moveDir = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical")
        );

        if (method == Method.Velocity && moveDir != Vector3.zero)
            rb.velocity = moveDir * velocity;
    }

    private void FixedUpdate()
    {
        if (method == Method.Force && moveDir != Vector3.zero)
            rb.AddForce(moveDir * force);
    }
}
