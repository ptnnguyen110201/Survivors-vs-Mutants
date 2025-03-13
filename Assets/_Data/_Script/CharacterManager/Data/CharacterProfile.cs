
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterProfile", menuName = "ScriptableObject/CharacterProfile", order = 1)]
public class CharacterProfile : ObjectProfile
{

    public Sprite chacracterSprite;
    public int maxHP;
    public int attackDamage;
    public float fireRate;
    public float moveSpeed;

}

