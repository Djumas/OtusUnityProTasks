using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> hpEmpty;

        [SerializeField] private int maxHitPoints;
        [ShowInInspector] private int hitPoints;

        public void Init()
        {
            hitPoints = maxHitPoints;
        }

        public bool IsHitPointsExists()
        {
            return this.hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            Debug.Log("Damage taken");
            this.hitPoints -= damage;
            if (this.hitPoints <= 0)
            {
                this.hpEmpty?.Invoke(this.gameObject);
            }
        }
    }
}