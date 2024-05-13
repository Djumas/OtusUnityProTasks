using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private float countdown;

        private GameObject target;
        private float currentTime;

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void Reset()
        {
            currentTime = countdown;
        }

        private void FixedUpdate()
        {
            currentTime -= Time.fixedDeltaTime;
            if (currentTime <= 0)
            {
                Fire();
                currentTime += countdown;
            }
        }

        private void Fire()
        {
            weaponComponent.Fire(target.transform.position, false);
        }
    }
}