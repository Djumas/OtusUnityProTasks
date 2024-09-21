using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using GameEngine;

[Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitSaveLoaderConfig", order = 1)]
public class UnitSaveLoaderConfig : ScriptableObject
{
    public PrefabType[] prefabTypes;

    [Button]
    public Unit GetPrefabByType(string type)
    {
        foreach (var prefabType in prefabTypes)
        {
            if (prefabType.type == type)
            {
                return prefabType.prefab;
            }
        }

        Debug.LogWarning("No such type");
        return null;
    }
}

[Serializable]
public class PrefabType
{
    public string type;
    public Unit prefab;
}
