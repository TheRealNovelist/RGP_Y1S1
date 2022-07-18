using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    Animator animator;
    public float speed;
    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        animator.speed = speed;
    }
}
