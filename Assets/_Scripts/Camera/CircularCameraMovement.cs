using UnityEngine;

public class CircularCameraMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager; // Reference to the input manager in order to get the mouse/joystick movement
    [SerializeField] private Transform positionTarget; // The point around which the camera revolves
    [SerializeField] private Transform lookAtTarget; // Target to look at
    [SerializeField] private float radius = 5.0f; // Radius of the circular path
    [SerializeField] private float xSensitivity = 3.0f; // Speed of rotation around the target in the horizontal axis
    [SerializeField] private float ySensitivity = 1.0f; // Speed of rotation around the target in the vertical axis
    [SerializeField] private float speed = 30.0f; // Speed of rotation around the target in the vertical axis
    [SerializeField] private Rigidbody rb; // Rigidbody of the camera
    public Vector3 facingDirection;
    public void Ini()
    {

    }

    public void HandleMovement()
    {
        Vector2 inputDirection = inputManager.cameraMoveDirection;
        Vector3 desiredDirectionPreOffset = GetDesiredDirection(inputDirection);

        // Calculate the new position of the camera
        Vector3 desiredPositionPreOffset = transform.position + desiredDirectionPreOffset;

        // Calculate and Apply the offset and redirect towards new calculated position
        Vector3 desiredPosition = ApplyOffset(desiredPositionPreOffset);
        Vector3 desiredDirection = desiredPosition - transform.position;

        FocusOnTarget(lookAtTarget);

        // Move towards the calculated direction
        Move(desiredDirection);
    }
    private Vector3 GetDesiredDirection(Vector2 inputDirection)
    {
        // Calculate vector from camera to target
        Vector3 cameraTargetVector = positionTarget.position - transform.position;
        facingDirection = cameraTargetVector.normalized;

        // Calculate right and forward direction relative to the target point and input
        Vector3 right = Vector3.Cross(-facingDirection, Vector3.up).normalized;
        Vector3 upwards = Vector3.Cross(facingDirection, right).normalized;

        // Skew horizontal and vertical axis to feel more natural
        right *= xSensitivity;
        upwards *= ySensitivity;

        // Calculate the desired direction based on input and return it
        return (right * inputDirection.x + upwards * inputDirection.y);
    }
    private Vector3 ApplyOffset(Vector3 newPosition)
    {
        Vector3 directionToTarget = positionTarget.position - newPosition;
        return (newPosition + (directionToTarget - directionToTarget.normalized * radius));
    }
    private void Move(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
    public void FocusOnTarget(Transform target)
    {
        transform.LookAt(target);
    }
    public void FocusOnTarget()
    {
        transform.LookAt(lookAtTarget);
    }
}
