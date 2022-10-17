using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRigidbody : MonoBehaviour
{
    [SerializeField] float mass;
    [SerializeField] Vector3 gravity;

    private Vector3 lastVelocity;
    private Vector3 lastPosition;
    private Vector3 dv;

    private void Start() {
        lastPosition = this.transform.position;
    }

    private void FixedUpdate()
    {      
        Move();

        // simulate ground collision
        if (this.transform.position.y <= 0.5f)
        {
            this.transform.position = new Vector3(
                transform.position.x, 
                0.5f, 
                transform.position.z);
        }

        // reset all value;
        lastVelocity = (this.transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = this.transform.position;
        dv = Vector3.zero;
    }

    public void AddForce(Vector3 force, ForceMode forceMode)
    {   
        switch (forceMode)
        {
            case ForceMode.Force:
                dv += force * Time.fixedDeltaTime / mass;
                break;
            case ForceMode.Acceleration:
                dv += force * Time.fixedDeltaTime;
                break;
            case ForceMode.Impulse:
                dv += force / mass;
                break;
            case ForceMode.VelocityChange:
                dv += force;
                break;
        }
    }

    private void Move()
    {
        // gravity is acceleration (a): change of velocity (dv), overtime (dt)
        // a = dv/dt  <=>  dv = a * dt  
        dv += gravity * Time.fixedDeltaTime;
        
        // change of velocity (dv) = current velocity - last velocity
        // current velocity = last velocity + dv 
        var velocity = this.lastVelocity + dv;

        // velocity is change of position overtime
        // velocity = ds/dt  <==>  ds = velocity* dt
        var ds = velocity * Time.fixedDeltaTime;

        // change of position = current position - last position
        // current position = last position + change of position
        this.transform.position = lastPosition + ds;
    }
}
