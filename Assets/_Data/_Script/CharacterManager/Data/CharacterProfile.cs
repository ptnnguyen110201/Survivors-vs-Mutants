using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterProfile", menuName = "ScriptableObject/CharacterProfile", order = 1)]
public class CharacterProfile : ObjectProfile
{
    public string characterName;
    public Sprite characterSprite;
    public List<CharacterUpgradeProfile> charaterUpgrade;
    public List<CharacterAttributes> characterAttributes;




    public Attributes GetCharacterAttributes(int Level)
    {
        foreach (CharacterAttributes attributes in this.characterAttributes)
        {
            if (attributes.Level != Level) continue;
            return attributes.attributes;
        }
        return null;
    }

    public ItemRequirement GetItemRequirement(int currentLevel)
    {
        foreach (CharacterUpgradeProfile upgradeProfile in this.charaterUpgrade)
        {
            if (upgradeProfile.Level != currentLevel + 1) continue;

            return upgradeProfile.upgradeRequirements;

        }
        return null;
    }

}


