using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamageSender : BulletDamageSender
{
    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.tag == "Enemy") return;
        base.OnTriggerEnter2D(collider2D);
    }
}
