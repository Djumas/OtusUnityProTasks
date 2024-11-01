using System;
using System.Collections;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class UnitDeathController
{
    [SerializeField] private bool destroyAfterDeath;
    [SerializeField] private float destroyDelay;
    [SerializeField, ReadOnly] private AtomicObject unit;
    [SerializeField, ReadOnly] private Rigidbody playerRG;
    [SerializeField, ReadOnly] private Collider playerCollider;
    
    
    public void Construct(AtomicVariable<bool> isDead, AtomicObject _player)
    {
        isDead.Subscribe(OnDeath);
        unit = _player;
        playerRG = unit.GetComponent<Rigidbody>();
        playerCollider = unit.GetComponent<Collider>();
    }

    private void OnDeath(bool isDeadValue)
    {
        if (isDeadValue)
        {
            unit.RemoveAllLogic<IAtomicLogic>();
            playerRG.isKinematic = true;
            playerCollider.enabled = false;
            if (destroyAfterDeath)
            {
                unit.StartCoroutine(WaitAndDestroy());
            }
        }
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Object.Destroy(unit.gameObject);
    }
}