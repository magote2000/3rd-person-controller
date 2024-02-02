using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidingState : State
{
    [SerializeField] private float glidingFallingSpeed = 5.0f;
    public override void Ini()
    {
        playerMovementController.currentSpeed = playerMovementController.glidingSpeed;
        playerMovementController.currentRotationSpeed = playerMovementController.glidingRotationSpeed;
    }
    public override void HandleState()
    {
        if (playerMovementController.IsGrounded())
        {
            playerController.ChangeState("ShortFalling");
        }
        else
        {
            playerMovementController.HandleMoveInput();
        }
        playerMovementController.movementBehaviour.Glide(glidingFallingSpeed);
    }
    public override void Jump()
    {
        playerController.ChangeState("ShortFalling");
    }
    public override void SprintStart()
    {

    }
    public override void AutoAttack()
    {

    }
    public override void CastSpell1()
    {

    }
    public override void CastSpell2()
    {

    }
    public override void CastUltimate()
    {

    }
}
