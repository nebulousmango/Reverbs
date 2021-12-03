using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string inputAxis;

    void Update()
    {
        if (Input.GetAxis(inputAxis) != 0) animator.SetBool("IsMoving", true);
        if (Input.GetAxis(inputAxis) == 0) animator.SetBool("IsMoving", false);
    }
}
