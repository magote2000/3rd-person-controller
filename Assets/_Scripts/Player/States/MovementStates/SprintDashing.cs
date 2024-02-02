using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintDashing : State
{
    [SerializeField] private float dashForce = 50.0f;
    [SerializeField] private float dashTime = 0.3f;
    private Vector3 dashDirection;
    public override void Ini()
    {
        Coroutine timerCoroutine = StartCoroutine(DashTimerCoroutine(dashTime));
        dashDirection = new Vector3(playerMovementController.playerFacingDirection.x, 0.1f, playerMovementController.playerFacingDirection.y);
    }
    public override void HandleState()
    {
        if (playerMovementController.IsGrounded())
        {
            playerMovementController.movementBehaviour.Dash(dashForce, dashDirection);
        }
        else
        {
            playerController.ChangeState("ShortFalling");
        }
    }
    private IEnumerator DashTimerCoroutine(float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        playerController.ChangeState("Running");
    }
}
