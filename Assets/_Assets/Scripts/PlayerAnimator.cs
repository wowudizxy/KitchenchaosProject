using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private Animator animator;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(IS_WALKING, player.Iswalking);
    }
}
