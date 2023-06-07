using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputManager inputManager;

    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    private bool isWalking;
    private Vector3 lastInteractDir;

    // Update is called once per frame
    void Update()
    {
        //call functions
        MovePlayerCharacter();
        HandleInteractions();
    }

    private void MovePlayerCharacter()
    {
        Vector2 inputVec = inputManager.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVec.x, 0, inputVec.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 0.7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            //cannot move in the moveDir direction
            //Attempt to move on the x axis

            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                //can move only on the x axis
                moveDir = moveDirX;
            }
            else
            {
                //cant move on the x axis, attempt to move on the z axis
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    //can move only on the z axis
                    moveDir = moveDirZ;
                }
                else
                {
                    //cant move at all
                }
            }

        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        float rotationSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

    private void HandleInteractions()
    {
        Vector2 inputVec = inputManager.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVec.x, 0, inputVec.y);
        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDist = 2.0f;
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hitInfo, interactDist))
        {
            Debug.Log(hitInfo.transform.name);
        }
        else
        {
            Debug.Log("--");
        }
    }
    public bool IsWalking()
    {
        return isWalking;
    }

 
}
