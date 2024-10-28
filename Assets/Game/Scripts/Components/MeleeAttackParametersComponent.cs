using System;
using Atomic.Elements;
using UnityEngine;

[Serializable]
public class AttackParametersComponent
{
    public AtomicVariable<int> damage;
    public AtomicVariable<float> coolDown;
}
