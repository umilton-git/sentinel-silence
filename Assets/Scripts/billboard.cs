using UnityEngine;

public class billboard : MonoBehaviour
{
    public Camera mainCamera;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        // Use the camera's forward vector for alignment in the case of an orthographic camera
        Vector3 directionToCamera = mainCamera.transform.forward;

        // Calculate the rotation required to make the GameObject face the camera
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera, mainCamera.transform.up);

        // Apply the rotation to the GameObject
        transform.rotation = targetRotation;
    }
}