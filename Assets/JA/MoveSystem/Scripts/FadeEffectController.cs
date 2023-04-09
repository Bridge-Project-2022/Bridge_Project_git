using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffectController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        FadeOut();
    }
    
    public void FadeInOut()
    {
        animator.SetTrigger("FadeInOut");
    }
    
    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }
    
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}
