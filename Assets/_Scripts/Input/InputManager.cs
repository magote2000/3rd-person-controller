using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerControls playerControls;

    #region camera
    public Vector2 cameraMoveDirection;
    private InputAction cameraMovement;
    private Vector2 scrollDelta;
    private InputAction zoom;
    #endregion
    #region movements
    public Vector2 PlayerMoveDirection;
    private InputAction movements;
    private InputAction jump;
    private InputAction sprint;
    #endregion
    #region combat
    private InputAction basicAttack;
    private InputAction ability1;
    private InputAction ability2;
    private InputAction ultimate;
    #endregion
    #region interact
    private InputAction interact;
    #endregion
    #region classes refernces
    [SerializeField] private ZoomCamera zoomCamera;
    [SerializeField] private PlayerController playerController;
    #endregion

    private void OnEnable()
    {
        playerControls = new PlayerControls();
        #region camera
        cameraMovement = playerControls.Camera.Move;
        cameraMovement.Enable();
        cameraMovement.performed += ctx => cameraMoveDirection = ctx.ReadValue<Vector2>();

        zoom = playerControls.Camera.Zoom;
        zoom.Enable();
        zoom.performed += Zoom;
        #endregion
        #region movements
        movements = playerControls.PlayerMovements.Move;
        movements.Enable();
        movements.performed += ctx => PlayerMoveDirection = ctx.ReadValue<Vector2>();

        jump = playerControls.PlayerMovements.Jump;
        jump.Enable();
        jump.performed += Jump;

        sprint = playerControls.PlayerMovements.Sprint;
        sprint.Enable();
        sprint.performed += Sprint;
        #endregion
        #region combat
        basicAttack = playerControls.PlayerCombat.BasicAttack;
        basicAttack.Enable();
        basicAttack.performed += BasicAttack;

        ability1 = playerControls.PlayerCombat.Ability1;
        ability1.Enable();
        ability1.performed += Ability1;

        ability2 = playerControls.PlayerCombat.Ability2;
        ability2.Enable();
        ability2.performed += Ability2;

        ultimate = playerControls.PlayerCombat.Ultimate;
        ultimate.Enable();
        ultimate.performed += Ultimate;
        #endregion
        #region interact
        interact = playerControls.PlayerMovements.Interact;
        interact.Enable();
        interact.performed += Interact;
        #endregion
    }

    private void OnDisable()
    {
        #region camera disable
        cameraMovement.Disable();
        zoom.Disable();
        zoom.performed -= Zoom;
        #endregion
        #region movements disable
        movements.Disable();
        jump.Disable();
        sprint.Disable();
        #endregion
        #region combat disable
        basicAttack.Disable();
        ability1.Disable();
        ability2.Disable();
        ultimate.Disable();
        #endregion
        #region interact disable
        interact.Disable();
        #endregion
    }
    private void Update()
    {
        PlayerMoveDirection = movements.ReadValue<Vector2>();
        cameraMoveDirection = cameraMovement.ReadValue<Vector2>();
    }
    #region camera functions
    private void Zoom(InputAction.CallbackContext context)
    {
        scrollDelta = context.ReadValue<Vector2>();
        zoomCamera.Zoom(scrollDelta);
    }
    #endregion
    #region movements functions
    private void Jump(InputAction.CallbackContext context)
    {
        playerController.Jump();
    }
    private void Sprint(InputAction.CallbackContext context)
    {
        playerController.SprintStart();
    }
    #endregion
    #region combat functions
    private void BasicAttack(InputAction.CallbackContext context)
    {
    }
    private void Ability1(InputAction.CallbackContext context)
    {
    }
    private void Ability2(InputAction.CallbackContext context)
    {
    }
    private void Ultimate(InputAction.CallbackContext context)
    {
    }
    #endregion
    #region interact functions
    private void Interact(InputAction.CallbackContext context)
    {
    }
    #endregion
}
