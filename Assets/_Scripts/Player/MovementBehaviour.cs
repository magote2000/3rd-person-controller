using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    public void Move(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x, rb.velocity.y, direction.y);
        rb.velocity = move;
    }
    public void FaceTowards(Vector2 direction, float rotationSpeed)
    {
        if (direction.x != 0 || direction.y != 0) // Avoids unnecessary rotations
        {
            Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        }
    }
    public void Jump(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public void Dash(float dashForce, Vector3 direction)
    {
        rb.AddForce(direction * dashForce, ForceMode.Impulse);
    }
    public void Glide(float glideSpeed)
    {
        Vector3 move = new Vector3(rb.velocity.x, -glideSpeed, rb.velocity.z);
        rb.velocity = move;
    }
}
