using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskeladdController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("O componente Animator não foi encontrado no NPC.");
        }
    }

    private void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("Idle");
        }
    }
}
