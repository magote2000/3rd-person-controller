using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    [SerializeField] private Vector3 newGravity = new Vector3(0, -20.0f, 0);

    private void Start()
    {
        Physics.gravity = newGravity;
    }
}