using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed; 

    [SerializeField] protected Vector3 moveDirection;
   
    public void Moving() 
    {
        transform.Translate(Time.deltaTime * Vector3.left);
    }
    public virtual void SetMoveSpeed(float moveSpeed ) => this.moveSpeed = moveSpeed;
    public virtual void SetMoveDirection(Vector3 moveDirection) => this.moveDirection = moveDirection;
}
