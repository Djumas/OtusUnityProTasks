using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using Sirenix.OdinInspector;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using VContainer;

public class UnitSaveLoader : ISaveLoader
{
    [ShowInInspector] private UnitManager _unitManager;
    [ShowInInspector] private UnitSaveLoaderConfig _saveLoaderConfig;
 
    [Inject]
    public UnitSaveLoader(UnitManager unitManager)
    {
        _unitManager = unitManager;
    }

    [Button]
    public string Save()
    {
        var units = _unitManager.GetAllUnits();
        var collectedUnitProperties = new List<UnitProperties>();

        if (!units.Any())
        {
            Debug.LogWarning("No units to save");
            return "";
        }

        foreach (var unit in units)
        {
            var unitProperties = new UnitProperties
            {
                type = unit.Type,
                position = new Float3Simple(unit.Position),
                rotation = new Float3Simple(unit.Rotation),
                hitPoints = unit.HitPoints
            };

            collectedUnitProperties.Add(unitProperties);

            //var json = JsonConvert.SerializeObject(unitProperties);
            //Debug.Log(json);
        }

        var json = JsonConvert.SerializeObject(collectedUnitProperties);
        //Debug.Log(json);

        return json;
    }

    [Button]
    public void Load(string json)
    {
        var spawnedUnits = _unitManager.GetAllUnits();

        if (_saveLoaderConfig == null)
        {
            _saveLoaderConfig = Resources.Load<UnitSaveLoaderConfig>("UnitSaveLoaderConfig");
            //Debug.Log(_saveLoaderConfig.name);
        }

        var unitsCount = spawnedUnits.Count();
        Debug.Log("units to destroy:"+unitsCount);
        
        for (var i = 0; i<unitsCount;i++){
            _unitManager.DestroyUnit(spawnedUnits.First());
        }
        
        Debug.Log("Units destroyed");
        
        var unitPropertiesList = JsonConvert.DeserializeObject<List<UnitProperties>>(json);
        
        Debug.Log("Units to spawn:"+unitPropertiesList.Count);
        
        foreach (var unitProperties in unitPropertiesList)
        {
            var unitPrefab = _saveLoaderConfig.GetPrefabByType(unitProperties.type);
            var rotation = Quaternion.Euler(unitProperties.rotation.ToVector3());
            var position = unitProperties.position.ToVector3();
            var unit = _unitManager.SpawnUnit(unitPrefab, position, rotation);
            unit.HitPoints = unitProperties.hitPoints;
            Debug.Log(unit.name + " spawned!");
        }
    }
}

[Serializable]
class UnitProperties
{
    public string type;
    public Float3Simple position;
    public Float3Simple rotation;
    public int hitPoints;

    public override string ToString()
    {
        return ($"type:{type}; position:{position}; rotation:{rotation}; hitPoints:{hitPoints}");
    }
}

[Serializable]
class Float3Simple
{
    public float x;
    public float y;
    public float z;

    public Float3Simple(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public override string ToString()
    {
        return ($"(x={x}; y={y}; z={z})");
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}