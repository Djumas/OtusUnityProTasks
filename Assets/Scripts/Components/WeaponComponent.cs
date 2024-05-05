using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] BulletSystem _bulletSystem;
        [SerializeField] BulletConfig _bulletConfig;
        [SerializeField] private Transform firePoint;


        public void Init(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }

        public void Fire(Vector3 targetPosition, bool isPlayer)
        {
            var startPosition = (Vector2)firePoint.position;
            var vector = (Vector2)targetPosition - startPosition;
            var direction = vector.normalized;
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = isPlayer,
                physicsLayer = (int)this._bulletConfig.physicsLayer,
                color = this._bulletConfig.color,
                damage = this._bulletConfig.damage,
                position = startPosition,
                velocity = direction * this._bulletConfig.speed
            });
        }

        public void Fire()
        {
            var direction = firePoint.rotation * Vector3.up + firePoint.position;
            Fire(direction, true);
        }
    }
}