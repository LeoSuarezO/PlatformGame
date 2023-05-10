using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    
    private bool attack;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate() {
        HandleAttack();
        ResetValues();
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space)) attack = true;
    }

    private void HandleAttack()
    {
        if(attack) animator.SetTrigger("attack");
    }

    private void ResetValues()
    {
        attack=false;
    }
}
