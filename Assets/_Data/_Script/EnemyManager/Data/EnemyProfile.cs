
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProfile", menuName = "ScriptableObject/EnemyProfile", order = 2)]
public class EnemyProfile : ObjectProfile
{

    public Sprite enemySprite;
    public int maxHP;
    public int attackDamage;
    public float fireRate;
    public float moveSpeed;
}

