using UnityEngine;

[CreateAssetMenu(fileName = "CharacterProfile", menuName = "ScriptableObject/CharacterProfile", order = 1)]
public class CharacterProfile : ObjectProfile
{


    public string characterName;
    public int maxHP;
    public int attackDamage;
    public float fireRate;
    public float moveSpeed;

}


