using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region references
    public MovementBehaviour movementBehaviour;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform[] GroundRaycastEmitterTransforms;
    [SerializeField] private CameraMovementController cameraMovementDirection;
    #endregion
    #region movement parameters
    [Header("Movement Parameters")]
    public Vector2 moveInput;
    public Vector2 playerFacingDirection;
    public float glidingSpeed;
    public float walkingSpeed;
    public float runningSpeed;
    public float currentSpeed = 5.0f;
    public float defaultRotationSpeed;
    public float glidingRotationSpeed;
    public float currentRotationSpeed;
    [SerializeField] private float distanceToGround = 0.1f;
    [SerializeField] private float longFallingDistanceToGround = 1.5f;
    #endregion
    public void UpdateMoveInput()
    {
        if (inputManager == null) return;
        moveInput = inputManager.PlayerMoveDirection;
    }
    public Vector2 GetMoveInput()
    {
        UpdateMoveInput();
        return moveInput;
    }
    public void HandleMoveInput() 
    {
        //lerp cameradirection facing direction con la velocidad que se mueva la camara
        UpdateMoveInput();
        Vector2 direction = GetDirection(moveInput).normalized;
        playerFacingDirection = direction;
        movementBehaviour.Move(direction * currentSpeed);
        RotatePlayerTowardsItsFacingDirection();
    }
    public void RotatePlayerTowardsItsFacingDirection()
    {
        movementBehaviour.FaceTowards(playerFacingDirection, currentRotationSpeed);
    }
    public Vector2 GetDirection(Vector2 inputDirection)
    {
        // Get the camera's forward and right vectors
        Vector3 cameraForward = -cameraMovementDirection.facingDirection.normalized;
        Vector3 cameraRight = Vector3.Cross(-cameraForward, Vector3.up).normalized;

        // Project them onto the horizontal plane (y = 0)
        cameraForward = new Vector2(cameraForward.x, cameraForward.z);
        cameraRight = new Vector2(cameraRight.x, cameraRight.z);
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the adjusted movement direction
        Vector2 moveDirection = cameraRight * inputDirection.x + cameraForward * inputDirection.y;
        return moveDirection;

    }
    public bool IsGrounded()
    {
        // Check if there are any colliders under the player within a small distance.
        foreach (Transform emitter in GroundRaycastEmitterTransforms)
        {
            if (Physics.Raycast(emitter.position + Vector3.up, Vector3.down, distanceToGround)) return true;
        }
        return false;
    }
    public bool IsLongFalling()
    {
        // Check if there are any colliders under the player within a large distance.
        foreach (Transform emitter in GroundRaycastEmitterTransforms)
        {
            if (Physics.Raycast(emitter.position + Vector3.up, Vector3.down, longFallingDistanceToGround)) return false;
        }
        return true;
    }
}
