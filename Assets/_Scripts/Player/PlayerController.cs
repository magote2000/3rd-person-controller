using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("States Dictionary")]
    [SerializeField] private string[] _keys;
    [SerializeField] private State[] _values;
    private Dictionary<string, State> statesDictionary = new Dictionary<string, State>();
    public State currentState;
    #region references
    [Header("References")]
    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Animator playerAnimator;
    #endregion

    private void Awake()
    {
        for (int i = 0; i < _keys.Length; i++)
        {
            statesDictionary.Add(_keys[i], _values[i]);
        }
    }
    void Update()
    {
        currentState.HandleState();
    }
    public void Jump()
    {
        currentState.Jump();
        //movementController.Jump();
    }
    public void SprintStart()
    {
        currentState.SprintStart();
    }
    public bool IsGrounded()
    {
        return movementController.IsGrounded();
    }
    public void ChangeState(string name)
    {
        currentState = statesDictionary[name];
        currentState.Ini();
        playerAnimator.SetTrigger(currentState.animatorTrigger);
    }
}
