using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State
{
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float jumpTime = 0.3f;
    public override void Ini()
    {
        Coroutine timerCoroutine = StartCoroutine(JumpTimerCoroutine(jumpTime));
        playerMovementController.movementBehaviour.Jump(jumpForce);
    }
    private IEnumerator JumpTimerCoroutine(float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        playerController.ChangeState("ShortFalling");
    }
}
