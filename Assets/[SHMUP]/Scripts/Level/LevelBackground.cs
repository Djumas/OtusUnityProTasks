using System;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IGameFixedUpdateListener
    {
        private float _startPositionY;

        private float _endPositionY;

        private float _movingSpeedY;

        private float _positionX;

        private float _positionZ;

        private Transform _myTransform;

        [SerializeField]
        private Params mParams;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            Debug.Log($"{name} Construct");
            //gameManager.Register(this);
            _startPositionY = mParams.mStartPositionY;
            _endPositionY = mParams.mEndPositionY;
            _movingSpeedY = mParams.mMovingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;

        }

        public void OnFixedUpdateGame(float fixedDeltaTime)
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * fixedDeltaTime,
                _positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [FormerlySerializedAs("m_startPositionY")] [SerializeField]
            public float mStartPositionY;

            [FormerlySerializedAs("m_endPositionY")] [SerializeField]
            public float mEndPositionY;

            [FormerlySerializedAs("m_movingSpeedY")] [SerializeField]
            public float mMovingSpeedY;
        }
    }
}