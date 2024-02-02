using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private ZoomCamera zoomCamera;
    [SerializeField] private CameraMovementController angularMovement;
    private void OnEnable()
    {
        angularMovement.Ini();
        angularMovement.FocusOnTarget();
        zoomCamera.Ini();
    }
    void LateUpdate()
    {
        angularMovement.HandleMovement();
        angularMovement.FocusOnTarget();
    }
}
