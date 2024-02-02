using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerMovementController playerMovementController;
    public string animatorTrigger;
    public virtual void Ini()
    {

    }
    public virtual void HandleState()
    {

    }
    public virtual void Jump()
    {

    }
    public virtual void SprintStart()
    {

    }
    public virtual void AutoAttack()
    {

    }
    public virtual void CastSpell1()
    {

    }
    public virtual void CastSpell2()
    {

    }
    public virtual void CastUltimate()
    {

    }
}
