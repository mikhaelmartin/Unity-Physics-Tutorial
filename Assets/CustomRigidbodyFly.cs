using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRigidbodyFly : MonoBehaviour
{
    [SerializeField] CustomRigidbody rb;
    [SerializeField] float force;
    [SerializeField] ForceMode forceMode;

    bool flyKeyPressed;
    private void Update()
    {
        flyKeyPressed = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (flyKeyPressed)
            rb.AddForce(Vector3.up * force, forceMode);
    }
}
