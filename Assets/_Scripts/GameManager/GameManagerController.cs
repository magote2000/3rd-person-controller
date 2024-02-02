using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    #region reerences
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;
    #endregion
    void Start()
    {
        cameraController.enabled = true;
        playerController.enabled = true;
        inputManager.enabled = true;
    }
}
