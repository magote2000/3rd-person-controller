using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    #region parameters
    [SerializeField] Vector3 cameraRotation; // Rotation vector of the camera
    [SerializeField] float radius; // Distance to the center of rotation
    [SerializeField] float moveSpeed; // Speed at which the camera moves to its desired position
    [SerializeField] float horizontalRotationSpeed; // Speed at which the camera revolves around the player based on the horizontal inputs
    [SerializeField] float verticalRotationSpeed; // Speed at which the camera revolves around the player based on the vertical inputs
    private Vector3 desiredPosition;
    private Vector3 desiredDirection;
    [HideInInspector] public Vector3 facingDirection;
    #endregion
    #region references
    [SerializeField] private InputManager inputManager; // Reference to the input manager in order to get the mouse/joystick movement
    [SerializeField] Transform targetCenter; // Target to rotate around
    [SerializeField] Transform energyHud; // Energy hud to rotate around
    [SerializeField] private Transform lookAtTarget; // Target to look at
    [SerializeField] Rigidbody rb;
    #endregion

    public void Ini()
    {
        PlaceCamera(cameraRotation);
    }
    public void HandleMovement()
    {
        HandleInputs();
        PlaceCamera(cameraRotation);
        //MoveCamera(cameraRotation);
    }
    private void HandleInputs()
    {
        Vector2 inputDirection = inputManager.cameraMoveDirection;
        cameraRotation.x += inputDirection.y * verticalRotationSpeed / 100;
        cameraRotation.y += -inputDirection.x * horizontalRotationSpeed / 100;
        cameraRotation.x %= 360;
        cameraRotation.y %= 360;
    }
    public void OrientCamera(Vector3 rotation)
    {
        facingDirection = Quaternion.Euler(rotation) * Vector3.back;
        RotateTarget(rotation);
    }
    public void PlaceCamera(Vector3 rotation)
    {
        OrientCamera(rotation);
        CalculateDesiredPosition();
        MoveTowardsPos(desiredPosition);
    }
    public void MoveCamera(Vector3 rotation)
    {
        OrientCamera(rotation);
        CalculateDesiredDirection();
        MoveTowardsDir(desiredDirection);
    }
    private void CalculateDesiredPosition()
    {
        desiredPosition = facingDirection.normalized * radius + targetCenter.position;
    }
    private void CalculateDesiredDirection()
    {
        CalculateDesiredPosition();
        desiredDirection = desiredPosition - transform.position;
    }
    public void MoveTowardsPos(Vector3 position)
    {
        transform.position = position;
    }
    private void MoveTowardsDir(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed;
    }
    private void RotateTarget(Vector3 rotation)
    {
        targetCenter.rotation = Quaternion.Euler(rotation);
        energyHud.rotation = Quaternion.Euler(rotation);
    }
    public void FocusOnTarget()
    {
        transform.LookAt(lookAtTarget);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(targetCenter.position, desiredPosition);
    }
}
