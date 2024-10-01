using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

    }

    public bool getJumpInput()
    {
        if(playerInputActions.Player.Jump.ReadValue<float>() == 1)
        {
            return true;
        }
        return false;
    }


    public Vector2 getMovementInputVectorNormalized()
    {
        Vector2 movementInput = playerInputActions.Player.Move.ReadValue<Vector2>();
       /*
        if(movementInput.y == 0)
        {
            movementInput.x = 0;
        }*/
 
        if (movementInput.y < 0)
        {
            movementInput.x *= -1;
        }

        movementInput = movementInput.normalized;

        return movementInput;
    }
}
