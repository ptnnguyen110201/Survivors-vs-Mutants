
using System.Collections.Generic;
using UnityEngine;

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
            enemy.EnemyAttack.Attacking();

        }
    }


    public List<EnemyCtrl> GetEnemiesInLanes(List<int> lanes, Vector3 position, float range, bool allowTwoWayAttack = false)
    {
        List<EnemyCtrl> enemiesInRange = new List<EnemyCtrl>();

        List<EnemyCtrl> leftEnemies = new List<EnemyCtrl>();
        List<EnemyCtrl> rightEnemies = new List<EnemyCtrl>();

        foreach (EnemyCtrl enemy in this.T_ListObj)
        {
            if (enemy == null) continue;
            if (enemy.EnemyDamageReceiver.IsDead()) continue;
            if (lanes.Contains(enemy.Lane))
            {
                float distanceX = enemy.transform.position.x - position.x;
                Camera mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                if (Mathf.Abs(distanceX) <= range && IsVisibleToCamera(mainCam, enemy.transform.position))
                {
                    if (distanceX < 0)
                        leftEnemies.Add(enemy);
                    else
                        rightEnemies.Add(enemy);
                }
            }
        }

        if (allowTwoWayAttack)
        {
            enemiesInRange.AddRange(leftEnemies);
            enemiesInRange.AddRange(rightEnemies);
        }
        else
        {
            if (leftEnemies.Count > 0)
                enemiesInRange.Add(leftEnemies[0]);
            else if (rightEnemies.Count > 0)
                enemiesInRange.Add(rightEnemies[0]);
        }

        return enemiesInRange;
    }

    private bool IsVisibleToCamera(Camera camera, Vector3 worldPos)
    {
        Vector3 viewportPoint = camera.WorldToViewportPoint(worldPos);
        return viewportPoint.z > 0 &&
               viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
               viewportPoint.y >= 0 && viewportPoint.y <= 1;
    }

}
