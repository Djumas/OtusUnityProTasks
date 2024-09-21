using System;
using System.Collections.Generic;
using GameEngine;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class ResourceSaveLoader : ISaveLoader
{
    [ShowInInspector] private ResourceService _resourceService;
    
    [Inject]
    public ResourceSaveLoader(ResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [Button]
    public string Save()
    {
        var resources = _resourceService.GetResources();

        var resourceProperties = new List<ResourceProperties>();

        foreach (var resource in resources)
        {
            resourceProperties.Add(new ResourceProperties(resource.ID,resource.Amount));
        }

        var json = JsonConvert.SerializeObject(resourceProperties);
       
        return json;
    }

    [Button]
    public void Load(string json)
    {
        var loadedResources = JsonConvert.DeserializeObject<List<Resource>>(json);
        var sceneResources = _resourceService.GetResources();
        
        foreach (var loadedResource in loadedResources)
        {
            foreach (var sceneResource in sceneResources)
            {
                if (sceneResource.ID == loadedResource.ID)
                {
                    Debug.Log($"Seting {sceneResource.ID} from {sceneResource.Amount} to {loadedResource.Amount} value" );
                    sceneResource.Amount = loadedResource.Amount;
                }
            }
        }
    }
}

[Serializable]
public class ResourceProperties
{
    public string id;
    public int amount;

    public ResourceProperties(string _id, int _amount)
    {
        id = _id;
        amount = _amount;
    }
}