using UnityEngine;

public class followPlane : MonoBehaviour
{
    public Transform floorPlane;
    public float yOffset = 0.1f;

    private void Update()
    {
        // Synchronize position with floor plane
        Vector3 newPosition = floorPlane.position;
        newPosition.y += yOffset;
        transform.position = newPosition;

        // Synchronize rotation with floor plane
        Quaternion newRotation = floorPlane.rotation;
        transform.rotation = newRotation;
    }
}
