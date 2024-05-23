using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameControl gameControl;
    private void Awake() {
        gameControl = new GameControl();
        gameControl.Player.Move.Enable();
    }
    public Vector3 GetMoveDircetionNormalized(){
        Vector2 vector2 = gameControl.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(vector2.x, 0, vector2.y).normalized;
        return direction;
    }
}
