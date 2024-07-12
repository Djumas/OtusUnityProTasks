using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;

        private readonly Queue<Bullet> _bulletPool = new();
        private GameManager _gameManager;


        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
            
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, container);
                _gameManager.Register(bullet);
                _bulletPool.Enqueue(bullet);
            }
        }

        public Bullet Get()
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = Instantiate(prefab, worldTransform);
                _gameManager.Register(bullet);
            }
            return bullet;
        }

        public void Release(Bullet otherBullet)
        {
            otherBullet.transform.SetParent(container);
            otherBullet.Reset();
            _bulletPool.Enqueue(otherBullet);
        }
    }
}