using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool smoothTransition = false;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;
    Vector3 forward;
    Vector3 backward;
    Vector3 left;
    Vector3 right;
    public GameObject InteractionIndicator;
    public static RaycastHit intCheck;

    private void Start() {
        targetGridPos = transform.position;
    }

    private void Update() {
        forward = transform.TransformDirection(Vector3.forward) * 1;
        backward = transform.TransformDirection(Vector3.back) * 1;
        left = transform.TransformDirection(Vector3.left) * 1;
        right = transform.TransformDirection(Vector3.right) * 1;

        Debug.DrawRay(transform.position, forward, Color.green);
        Debug.DrawRay(transform.position, backward, Color.red);
        Debug.DrawRay(transform.position, left, Color.blue);
        Debug.DrawRay(transform.position, right, Color.cyan);

        CheckInteractable();
    }
    private void FixedUpdate() {
        MovePlayer();
    }

    void MovePlayer() {
        if (true) {
            prevTargetGridPos = targetGridPos;
            Vector3 targetPosition = targetGridPos;
            if(targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
            if(targetRotation.y < 0f) targetRotation.y = 270f;

            if(!smoothTransition) {
                transform.position = targetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            } else {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
            }
        }
    }

    public void CheckInteractable()
    {
        if(Physics.Raycast(transform.position, forward, out intCheck))
        {
            if(intCheck.collider.CompareTag("Interact") && intCheck.distance <= 1)
            {
                InteractionIndicator.SetActive(true);
            }
                    else
            {
                InteractionIndicator.SetActive(false);
            }
        }
    }

    public void RotateLeft() {if (AtRest) targetRotation -= Vector3.up * 90f; }
    public void RotateRight() {if (AtRest) targetRotation += Vector3.up * 90f; }
    public void MoveForward() { if (AtRest && !Physics.Raycast(transform.position, forward, 1)) { targetGridPos += transform.forward; } }
    public void MoveBackward() { if (AtRest && !Physics.Raycast(transform.position, backward, 1)) { targetGridPos -= transform.forward; } }
    public void MoveLeft() { if (AtRest && !Physics.Raycast(transform.position, left, 1)) { targetGridPos -= transform.right; } }
    public void MoveRight() { if (AtRest && !Physics.Raycast(transform.position, right, 1)) { targetGridPos += transform.right; } }

    bool AtRest {
        get{
            if((Vector3.Distance(transform.position, targetGridPos) < 0.5f) &&
                (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.5f))
                return true;
            else
                return false;
        }
    }
}
