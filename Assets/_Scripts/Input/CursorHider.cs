using UnityEngine;

public class CursorHider : MonoBehaviour
{
    void Start()
    {
        // Hides the cursor
        Cursor.visible = false;

        // Locks the cursor in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Press ESC to show the cursor for debugging or menu navigation
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}