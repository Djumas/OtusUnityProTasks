using System;
using System.Collections;
using System.Collections.Generic;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class UnitManagerHelper : MonoBehaviour
{
    [SerializeField] private Transform container;
    [ShowInInspector] private UnitManager _unitManager;

    [Inject]
    private void Construct(UnitManager unitManager)
    {
        _unitManager = unitManager;
    }

    private void Start()
    {
        _unitManager.SetContainer(container);
        _unitManager.SetupUnits(FindObjectsOfType<Unit>());
    }
}
