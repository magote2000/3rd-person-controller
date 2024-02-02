using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : State
{
    public override void Ini()
    {
        playerMovementController.currentSpeed = playerMovementController.walkingSpeed;
        playerMovementController.currentRotationSpeed = playerMovementController.defaultRotationSpeed;
    }
    public override void HandleState()
    {
        if (playerMovementController.IsGrounded())
        {
            if (playerMovementController.GetMoveInput() == Vector2.zero)
            {
                playerController.ChangeState("Idle");
                return;
            }
            playerMovementController.HandleMoveInput();
        }
        else
        {
            playerController.ChangeState("ShortFalling");
        }
    }
    public override void Jump()
    {
        playerController.ChangeState("Jumping");
    }
    public override void SprintStart()
    {
        playerController.ChangeState("SprintDashing");
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
