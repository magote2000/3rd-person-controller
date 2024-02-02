using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Ini()
    {
        playerMovementController.currentSpeed = 0;
        playerMovementController.currentRotationSpeed = playerMovementController.defaultRotationSpeed;
    }
    public override void HandleState()
    {
        if (playerMovementController.GetMoveInput()!=Vector2.zero)
        {
            playerController.ChangeState("Walking");
        }
        playerMovementController.RotatePlayerTowardsItsFacingDirection();
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
