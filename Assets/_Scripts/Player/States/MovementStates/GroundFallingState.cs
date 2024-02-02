using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFallingState : State
{
    [SerializeField] private float fallingTime = 0.15f;
    public override void Ini()
    {
        Coroutine timerCoroutine = StartCoroutine(FallTimerCoroutine(fallingTime));
    }
    private IEnumerator FallTimerCoroutine(float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        playerController.ChangeState("Idle");
    }
}
