
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectProfile", menuName = "ScriptableObject/ObjectProfile", order = 0)]
public abstract class ObjectProfile : ScriptableObject
{
    public ObjectType ObjectType = ObjectType.NoType;

}

