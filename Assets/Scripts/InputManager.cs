using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("References")]
    private InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.PlayerInputs.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVec = new Vector2(0,0);
        inputVec = inputActions.PlayerInputs.Movement.ReadValue<Vector2>();
   
        return inputVec.normalized;
    }
}
