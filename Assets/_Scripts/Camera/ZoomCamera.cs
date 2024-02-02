using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float zoomSpeed = 1f; // Speed of the zoom
    [SerializeField] private float iniZoom = 10f; // Initial zoom distance
    [SerializeField] private float minZoom = 5f; // Minimum zoom distance
    [SerializeField] private float maxZoom = 20f; // Maximum zoom distance
    public void Ini()
    {
        _camera.fieldOfView = iniZoom;
    }
    public void Zoom(Vector2 scrollDelta)
    {
        _camera.fieldOfView -= scrollDelta.y * zoomSpeed;
        _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, minZoom, maxZoom);
    }
}
