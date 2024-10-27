using System;
using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;


[Serializable]
public class ShootComponent : IAtomicUpdate
{
    public AtomicEvent shootRequest;
    public AtomicEvent shootAction;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float coolDown;
    [SerializeField, ReadOnly] private bool isGunReady = true;
    [SerializeField, ReadOnly] private float coolDownLeft;


    public void Construct()
    {
        shootRequest.Subscribe(OnShootRequest);
        shootAction.Subscribe(OnShootAction);
    }

    public void OnUpdate(float deltaTime)
    {
        if (coolDownLeft <= 0)
        {
            coolDownLeft = 0;
            isGunReady = true;
            return;
        }

        isGunReady = false;
        coolDownLeft -= deltaTime;
    }

    private void OnShootRequest()
    {
        //Debug.Log("Shoot Requested");
        if (isGunReady)
        {
            shootAction.Invoke();
        }
    }

    private void OnShootAction()
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject.Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        coolDownLeft = coolDown;
    }
}