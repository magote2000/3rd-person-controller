using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform target; // The GameObject to follow
    [SerializeField] private float followXSpeed = 5.0f; // Speed at which to follow
    [SerializeField] private float followYSpeed = 5.0f; // Speed at which to follow
    [SerializeField] private float followZSpeed = 5.0f; // Speed at which to follow
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CameraMovementController cameraMovementDirection;
    [SerializeField] private Vector3 distance;
    [SerializeField] private Vector3 desiredVelocity;

    void FixedUpdate()
    {
        // Calculate the distance between the target and this GameObject
        distance = target.transform.position - transform.position;

        // Apply the desired velocity transformations given each axis in order to loook smooth
        desiredVelocity = VectorialBaseTransformation(distance);

        // Add velocity to the Rigidbody
        rb.velocity = desiredVelocity;
    }

    Vector3 VectorialBaseTransformation(Vector3 V)
    {
        Vector3 referenceDirection = cameraMovementDirection.facingDirection.normalized;
        referenceDirection = new Vector3(referenceDirection.x, 0, referenceDirection.y).normalized;
        Vector3 right = Vector3.Cross(-referenceDirection, Vector3.up).normalized;
        Vector3 B1 = right;
        Vector3 B2 = Vector3.up;
        Vector3 B3 = referenceDirection;

        // Express V in the new basis
        Vector3 V_in_new_basis = new Vector3(
            Vector3.Dot(V, B1),
            Vector3.Dot(V, B2),
            Vector3.Dot(V, B3)
        );

        // Apply speed to the vector in the new basis
        Vector3 V_transformed_and_scaled = new Vector3(
            V_in_new_basis.x * followXSpeed,
            V_in_new_basis.y * followYSpeed,
            V_in_new_basis.z * followZSpeed
        );

        // Convert it back to the original basis if needed
        Vector3 V_final = B1 * V_transformed_and_scaled.x + B2 * V_transformed_and_scaled.y + B3 * V_transformed_and_scaled.z;
        return V_final;
    }
}
/*void FixedUpdate()
    {
        // Calculate the distance between the target and this GameObject
        Vector3 distance = target.transform.position - transform.position;

        // Calculate the velocity needed to follow the target
        Vector3 desiredVelocity = new Vector3(distance.x * followXSpeed, distance.y * followYSpeed, distance.z * followZSpeed);

        // Add velocity to the Rigidbody
        rb.velocity = desiredVelocity;
    }*/
