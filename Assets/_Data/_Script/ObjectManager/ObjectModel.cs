using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectModel<T> : LoadComPonent
{
    [SerializeField] protected T objParent;
    [SerializeField] protected SpriteRenderer objectSpriteRenderer;
    [SerializeField] protected string effectName;

    [SerializeField] protected Color32 orginalColor = Color.white;
    [SerializeField] protected Color32 fireColor = new Color32(255, 127, 0, 255);
    [SerializeField] protected Color32 nowColor = new Color32(0, 0, 255, 255);
    public virtual void ApplyEffect()
    {
        // for override
    }



    public virtual void ObjectSpriteRenderer(Sprite objSprite) => this.objectSpriteRenderer.sprite = objSprite;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
        this.LoadObjectSpriteRenderer();
    }
    protected virtual void LoadObjParent()
    {
        if (this.objParent != null) return;
        this.objParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }

    protected virtual void LoadObjectSpriteRenderer()
    {
        if (this.objectSpriteRenderer != null) return;
        this.objectSpriteRenderer = transform.GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": Load ObjectSpriteRenderer", gameObject);
    }
}
