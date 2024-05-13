using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnHpEmpty;

        [SerializeField] private int maxHitPoints;
        [ShowInInspector] private int hitPoints;

        public void Init()
        {
            hitPoints = maxHitPoints;
        }

        public bool IsHitPointsExists()
        {
            return hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Damage taken");
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                OnHpEmpty?.Invoke(gameObject);
            }
        }
    }
}