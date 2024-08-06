using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [ShowInInspector, ReadOnly] private BulletSpawnSystem _bulletSpawnSystem;
        [SerializeField] BulletConfig bulletConfig;
        [SerializeField] private Transform firePoint;

        [Inject]
        public void Init(BulletSpawnSystem otherBulletSpawnSystem)
        {
            _bulletSpawnSystem = otherBulletSpawnSystem;
        }

        public void Fire(Vector3 targetPosition, bool isPlayer)
        {
            var startPosition = (Vector2)firePoint.position;
            var vector = (Vector2)targetPosition - startPosition;
            var direction = vector.normalized;
            _bulletSpawnSystem.FlyBulletByArgs(new BulletSpawnArgs
            {
                isPlayer = isPlayer,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = startPosition,
                velocity = direction * bulletConfig.speed
            });
        }

        public void Fire()
        {
            var direction = firePoint.rotation * Vector3.up + firePoint.position;
            Fire(direction, true);
        }
    }
}