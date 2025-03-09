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
    public int GetAnimationDuration(ObjectAnimationEnum objectAnimationEnum)
    {
        if (this.objAnimator == null) return 0; 
        AnimatorStateInfo stateInfo = this.objAnimator.GetCurrentAnimatorStateInfo(0);
        return (int)stateInfo.length;
    }

    public virtual void SetTriggerAnimation(ObjectAnimationEnum objectAnimationEnum) 
    {
        if (this.objAnimator == null) return;
        if (objectAnimationEnum == ObjectAnimationEnum.None) return;
        this.objAnimator.SetTrigger(objectAnimationEnum.ToString());
        this.objAnimationTimer = this.GetAnimationDuration(objectAnimationEnum);

    }
    public virtual void SetBoolAnimation(ObjectAnimationEnum objectAnimationEnum, bool AnimationBool)
    {
        if (this.objAnimator == null) return;
        if (objectAnimationEnum == ObjectAnimationEnum.None) return;
        this.objAnimator.SetBool(objectAnimationEnum.ToString(), AnimationBool);
        this.objAnimationTimer = this.GetAnimationDuration(objectAnimationEnum);
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
