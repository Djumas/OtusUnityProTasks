using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Initiable[] initiables;

    private void Awake()
    {
        foreach (var initiable in initiables)
        {
            initiable.Init();
        }
    }
}
