using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 10f;
    [SerializeField]private float rotateSpeed = 10f;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private LayerMask counterLayerMask;

    private ClearCounter selectedCounter;
    private bool isWalking = false;
    
    private void Start ()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }
    void Update()
    {
        HandleInterection();
    }
    void FixedUpdate() {
        HandleMovement();
    }
    private void GameInput_OnInteractAction (object sender, System.EventArgs e)
    {
        selectedCounter?.Interect();
    }
    public bool Iswalking
    {
        get
        {
            return isWalking;
        }
    }
    private void HandleMovement()
    {
        Vector3 direction = gameInput.GetMoveDircetionNormalized();
        isWalking = direction != Vector3.zero;
        transform.position += direction*Time.deltaTime*moveSpeed;
        if(direction!=Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime*rotateSpeed);
        }
    }
    private void HandleInterection()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,1f,counterLayerMask)){
            if(hit.transform.TryGetComponent<ClearCounter>(out ClearCounter clearCounter)){
                SetSelectedCounter(clearCounter);
            }else{
                SetSelectedCounter(null);
            }
        }else{
            SetSelectedCounter(null);
        }
    }
    private void SetSelectedCounter(ClearCounter clearCounter)
    {
        if(clearCounter!=selectedCounter){
            selectedCounter?.UnSelectedCounter();
            clearCounter?.SelectedCounter();
            selectedCounter = clearCounter;
        }
    }
}
