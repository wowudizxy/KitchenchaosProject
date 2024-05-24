using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private GameControl gameControl;
    private void Awake() {
        gameControl = new GameControl();
        gameControl.Player.Enable();
        gameControl.Player.Interact.performed += Interact_Performed;
    }

    private void Interact_Performed (UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMoveDircetionNormalized(){
        Vector2 vector2 = gameControl.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(vector2.x, 0, vector2.y).normalized;
        return direction;
    }
}
