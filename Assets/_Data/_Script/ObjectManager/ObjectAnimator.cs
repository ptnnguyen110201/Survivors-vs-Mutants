using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ObjectAnimator<T> : LoadComPonent
{
    [SerializeField] protected T objParent;
    [SerializeField] protected Animator objAnimator;
    public Animator ObjAnimator => objAnimator;

    [SerializeField] protected float objAnimationTimer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
        this.LoadObjAnimator();


    }
    public float GetAnimationDuration(string stateName)
    {
        if (this.objAnimator == null) return 0f; 
        AnimatorStateInfo stateInfo = this.objAnimator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;
    }

    public virtual void SetTriggerAnimation(string AnimationName) 
    {
        if (this.objAnimator == null) return;
        if (AnimationName == string.Empty) return;
        this.objAnimator.SetTrigger(AnimationName);
        this.objAnimationTimer = this.GetAnimationDuration(AnimationName);

    }
    public virtual void SetBoolAnimation(string AnimationName, bool AnimationBool)
    {
        if (this.objAnimator == null) return;
        if (AnimationName == string.Empty) return;
        this.objAnimator.SetBool(AnimationName, AnimationBool);
        this.objAnimationTimer = this.GetAnimationDuration(AnimationName);
    }


    protected virtual void LoadObjParent()
    {
        if (this.objParent != null) return;
        this.objParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }

    protected virtual void LoadObjAnimator()
    {
        if (this.objAnimator != null) return;
        this.objAnimator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }

}
