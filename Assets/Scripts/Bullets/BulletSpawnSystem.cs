using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class BulletSpawnSystem : IGameFixedUpdateListener
    {
        [ShowInInspector, ReadOnly] private LevelBounds _levelBounds;
        [ShowInInspector, ReadOnly] private BulletPool _bulletPool;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        [Inject]
        private void Construct(BulletPool bulletPool, LevelBounds levelBounds)
        {
            Debug.Log($"BulletSpawnSystem Construct");
            _levelBounds = levelBounds;
            _bulletPool = bulletPool;
        }

        public void OnFixedUpdateGame(float deltaTime)
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(BulletSpawnArgs args)
        {
            var bullet = _bulletPool.Get();

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.Damage = args.damage;
            bullet.IsPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);

            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletPool.Release(bullet);
            }
        }
    }
}