using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{

    
    public class EnemyAIAgent : MonoBehaviour
    {
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private EnemyAttackAgent attackAgent;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        private void Awake()
        {
            attackAgent.enabled = false;
        }

        private void FixedUpdate()
        {
            if (!moveAgent.IsReached)
            {
                return;
            }

            if (!hitPointsComponent.IsHitPointsExists())
            {
                attackAgent.enabled = false;
                return;
            }

            if (!attackAgent.enabled)
            {
                attackAgent.enabled = true;
            }
        }
    }
}