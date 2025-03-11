using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyManager : ObjectManager<EnemyCtrl>
{
    protected virtual void Update()
    {
        this.UpdateAction();
    }

    protected virtual void UpdateAction()
    {
        foreach (EnemyCtrl enemy in this.T_List)
        {
            if (!enemy.gameObject.activeSelf) continue;
            enemy.ObjectTargeting.CheckTargeting();
            enemy.ObjectMove.Moving();
            enemy.ObjectAttack.Attacking();

        }
    }



    public List<EnemyCtrl> GetEnemiesInLanes(List<int> lanes, Vector3 position, float range, bool allowTwoWayAttack = false)
    {
        List<EnemyCtrl> enemiesInRange = new List<EnemyCtrl>();

        List<EnemyCtrl> leftEnemies = new List<EnemyCtrl>();  // Enemy b?n tr?i
        List<EnemyCtrl> rightEnemies = new List<EnemyCtrl>(); // Enemy b?n ph?i

        foreach (EnemyCtrl enemy in this.T_ListObj)
        {
            if (enemy == null) continue;

            if (lanes.Contains(enemy.Lane))
            {
                float distanceX = enemy.transform.position.x - position.x; // Kho?ng c?ch theo tr?c X
                if (Mathf.Abs(distanceX) <= range) // Ki?m tra trong ph?m vi range
                {
                    if (distanceX < 0)
                        leftEnemies.Add(enemy); // N?u enemy ? b?n tr?i
                    else
                        rightEnemies.Add(enemy); // N?u enemy ? b?n ph?i
                }
            }
        }

        if (allowTwoWayAttack)
        {
            enemiesInRange.AddRange(leftEnemies); // Th?m enemy b?n tr?i
            enemiesInRange.AddRange(rightEnemies); // Th?m enemy b?n ph?i
        }
        else
        {
            if (leftEnemies.Count > 0)
                enemiesInRange.Add(leftEnemies[0]); // ?u ti?n enemy b?n tr?i
            else if (rightEnemies.Count > 0)
                enemiesInRange.Add(rightEnemies[0]); // N?u kh?ng c? enemy tr?i, b?n enemy ph?i
        }

        return enemiesInRange;
    }


}
