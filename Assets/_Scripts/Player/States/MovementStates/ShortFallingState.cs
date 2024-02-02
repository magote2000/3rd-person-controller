using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortFallingState : State
{
    public override void Ini()
    {

    }
    public override void HandleState()
    {
        if (playerMovementController.IsGrounded())
        {
            if (playerMovementController.currentSpeed > playerMovementController.walkingSpeed)
            {
                playerController.ChangeState("Running");
                return;
            }
            else if (playerMovementController.currentSpeed > 0)
            {
                playerController.ChangeState("Walking");
                return;
            }
            else
            {
                playerController.ChangeState("Idle");
                return;
            }
        }
        else if (playerMovementController.IsLongFalling())
        {
            playerController.ChangeState("LongFalling");
            return;
        }
    }
}
