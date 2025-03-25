
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterBuyProfile", menuName = "ScriptableObject/CharacterBuyProfile", order = 2)]
public class CharacterBuyProfile : ObjectProfile
{

    public CharacterProfile characterProfile; 
    public Sprite chacracterSprite;
    public int chacracterCoints;
    public int currentMap;

}

