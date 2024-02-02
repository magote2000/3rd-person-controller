using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongFallingState : State
{
    public override void Ini()
    {

    }
    public override void HandleState()
    {
        if (playerMovementController.IsGrounded())
        {
            if (playerMovementController.GetMoveInput() == Vector2.zero)
            {
                playerController.ChangeState("GroundFalling");
            }
            else
            {
                playerController.ChangeState("GroundRolling");
            }
        }
    }
    public override void Jump()
    {
        playerController.ChangeState("Gliding");
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
