using System;
using System.Collections;
using System.Collections.Generic;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class ResourceServiceHelper : MonoBehaviour
{
    [ShowInInspector] private ResourceService _resourceService;

    [Inject]
    private void Construct(ResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    private void Start()
    {
        _resourceService.SetResources(FindObjectsOfType<Resource>());
    }
}
