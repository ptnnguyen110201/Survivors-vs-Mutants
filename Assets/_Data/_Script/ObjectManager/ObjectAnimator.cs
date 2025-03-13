using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ObjectAnimator<T> : LoadComPonent
{
    [SerializeField] protected T objParent;
    [SerializeField] protected Animator objAnimator;
    public Animator ObjAnimator => objAnimator;

    [SerializeField] protected int objAnimationTimer;
    public int ObjAnimationTimer => objAnimationTimer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
        this.LoadObjAnimator();


    }
    public int GetAnimationDuration(string animationName)
    {
        if (this.objAnimator == null) return 0; 
        AnimatorStateInfo stateInfo = this.objAnimator.GetCurrentAnimatorStateInfo(0);
        return (int)stateInfo.length;
    }

    public virtual void SetTriggerAnimation(string animationName) 
    {
        if (this.objAnimator == null) return;
        if (animationName == string.Empty) return;
        this.objAnimator.SetTrigger(animationName.ToString());
        this.objAnimationTimer = this.GetAnimationDuration(animationName);

    }
    public virtual void SetBoolAnimation(string animationName, bool AnimationBool)
    {
        if (this.objAnimator == null) return;
        if (animationName == string.Empty) return;
        this.objAnimator.SetBool(animationName.ToString(), AnimationBool);
        this.objAnimationTimer = this.GetAnimationDuration(animationName);
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
