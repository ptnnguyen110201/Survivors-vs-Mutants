
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProfile", menuName = "ScriptableObject/EnemyProfile", order = 2)]
public class EnemyProfile : ObjectProfile
{
    public string enemyName;
    public Sprite enemySprite;
    public EnemyAttributes enemyAttributes;
}

