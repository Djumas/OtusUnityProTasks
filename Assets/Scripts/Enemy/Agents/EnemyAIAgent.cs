using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{

    
    public class EnemyAIAgent : MonoBehaviour
    {
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private EnemyAttackAgent _attackAgent;
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        private void Awake()
        {
            _attackAgent.enabled = false;
        }

        private void FixedUpdate()
        {
            if (!this._moveAgent.IsReached)
            {
                return;
            }

            if (!_hitPointsComponent.IsHitPointsExists())
            {
                _attackAgent.enabled = false;
                return;
            }

            if (!_attackAgent.enabled)
            {
                _attackAgent.enabled = true;
            }
        }
    }
}