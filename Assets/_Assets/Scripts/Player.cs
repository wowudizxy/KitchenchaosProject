using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 10f;
    [SerializeField]private float rotateSpeed = 10f;
    [SerializeField]private GameInput gameInput;
    private bool isWalking = false;
    
    void Update()
    {
        Vector3 direction = gameInput.GetMoveDircetionNormalized();    
        isWalking = direction!=Vector3.zero;
        transform.position += direction*Time.deltaTime*moveSpeed;
        if(direction!=Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime*rotateSpeed);
        }
    }
    public bool Iswalking
    {
        get
        {
            return isWalking;
        }
    }
    
}
