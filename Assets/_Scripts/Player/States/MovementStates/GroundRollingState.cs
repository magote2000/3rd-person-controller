using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRollingState : State
{
    [SerializeField] private float rollingTime = 0.15f;
    public override void Ini()
    {
        Coroutine timerCoroutine = StartCoroutine(RollTimerCoroutine(rollingTime));
    }
    private IEnumerator RollTimerCoroutine(float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        playerController.ChangeState("Walking");
    }
}
