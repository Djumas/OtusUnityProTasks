using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class CooldownMeleeAttackMechanics : IAtomicUpdate
{
    [SerializeField, ReadOnly] private DoDamageMechanics _doDamageMechanics;
    [SerializeField, ReadOnly] private AtomicVariable<AtomicObject> target;
    [SerializeField, ReadOnly] private AtomicVariable<int> damage;
    [SerializeField, ReadOnly] private AtomicVariable<float> coolDown;

    [SerializeField, ReadOnly] private bool isEnabled;
    [SerializeField, ReadOnly] private float coolDownLeft;

    public void Construct(DoDamageMechanics doDamageMechanics, AtomicVariable<AtomicObject> target, AtomicVariable<int> damage, AtomicVariable<float> coolDown)
    {
        _doDamageMechanics = doDamageMechanics;
        this.target = target;
        this.damage = damage;
        this.coolDown = coolDown;
    }

    public void Stop()
    {
        isEnabled = false;
    }

    public void Start()
    {
        isEnabled = true;
    }

    public void OnUpdate(float deltaTime)
    {
        if (coolDownLeft > 0)
        {
            coolDownLeft -= deltaTime;
        }
        else
        {
            if (!isEnabled) return;
            _doDamageMechanics.DoDamage(target.Value, damage.Value);
            coolDownLeft = coolDown.Value;
        }
    }
}