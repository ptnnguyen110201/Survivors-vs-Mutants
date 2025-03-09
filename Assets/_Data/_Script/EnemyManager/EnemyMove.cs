using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : ObjectMove<EnemyCtrl>
{
    [SerializeField] protected PathMap pathMap;
    [SerializeField] protected int pointIndex = 0;
    [SerializeField] protected Vector3 nextPoint;
    [SerializeField] protected float stoppingDistance = 0.1f;

    public virtual void SetPathMap(PathMap PathMap)
    {
        this.pathMap = PathMap;
        this.pointIndex = 0;
        if (this.pathMap == null) return;

        List<Vector3> points = this.pathMap.GetPoints();
        if (points.Count <= 0) return;

        this.nextPoint = points[0];

    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.objectAnimationEnum = ObjectAnimationEnum.IsMoving;
        this.moveSpeed = 1f;
    }

    public override void Moving()
    {
        if (!this.canMove)
        {
            this.ObjParent.ObjectAnimator.SetBoolAnimation(this.objectAnimationEnum, this.canMove);
            return;
        }

        this.MoveToNextPoint();
        this.ObjParent.ObjectAnimator.SetBoolAnimation(this.objectAnimationEnum, this.canMove);
    }

    protected virtual void MoveToNextPoint()
    {
        List<Vector3> pathPoints = this.pathMap.GetPoints();
        if (pathPoints.Count == 0) return;

        if (this.pointIndex >= pathPoints.Count)
        {
            this.canMove = false;
            return;
        }

        Vector3 target = pathPoints[this.pointIndex];
        transform.parent.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.parent.position, target) > stoppingDistance) return;

        this.pointIndex++;

    }
}
