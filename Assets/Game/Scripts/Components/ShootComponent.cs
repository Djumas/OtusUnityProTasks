using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class ShootComponent : IAtomicUpdate
{
    public AtomicEvent shootRequest;
    public AtomicEvent shootAction;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shootCoolDown = 0.5f;
    [SerializeField] private float bulletRespawnCoolDown = 1f;
    [SerializeField] private int ammoCapacity = 10;
    [SerializeField, ReadOnly] private bool isGunReady = true;
    [SerializeField, ReadOnly] private float coolDownLeft;
    [SerializeField, ReadOnly] private float bulletCoolDownLeft;
    [SerializeField, ReadOnly] private int ammoLeft;


    public void Construct()
    {
        shootRequest.Subscribe(OnShootRequest);
        shootAction.Subscribe(OnShootAction);
        ammoLeft = ammoCapacity;
    }

    public void OnUpdate(float deltaTime)
    {
        EvaluateFireCooldown(deltaTime);
        EvaluateAmmoCooldown(deltaTime);
    }

    private void EvaluateFireCooldown(float deltaTime)
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

    private void EvaluateAmmoCooldown(float deltatime)
    {
        if(ammoLeft >= ammoCapacity) return;
        bulletCoolDownLeft -= deltatime;
        if (bulletCoolDownLeft <= 0)
        {
            ammoLeft += 1;
            bulletCoolDownLeft = bulletRespawnCoolDown;
        }
    }

    private void OnShootRequest()
    {
        if (isGunReady)
        {
            if (ammoLeft <= 0) return;
            shootAction.Invoke();
        }
    }

    private void OnShootAction()
    {
        Shoot();
    }

    private void Shoot()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        var bulletAtomicObject = bullet.GetComponent<AtomicObject>();
        bulletAtomicObject.GetVariable<int>(ShootAPI.BulletDamage).Value = bulletDamage;
        bulletAtomicObject.GetVariable<float>(MoveAPI.MoveSpeed).Value = bulletSpeed;
        coolDownLeft = shootCoolDown;
        ammoLeft -= 1;
    }
}