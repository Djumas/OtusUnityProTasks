using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

public class Bullet : AtomicObject
{
    [Get(MoveAPI.MoveDirection)] public AtomicVariable<Vector3> _moveDirection => _moveComponent.moveDirection;
    
    [SerializeField] private MoveComponent _moveComponent;
    [SerializeField] private BulletFlyMechanics _bulletFlyMechanics;
    [SerializeField] private DoDamageMechanics _doDamageMechanics;


    private void Awake()
    {
        AddLogic(_moveComponent);
        AddLogic(_bulletFlyMechanics);
    }

    private void Update()
    {
        OnUpdate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        OnFixedUpdate(Time.fixedDeltaTime);    
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: Вынести нанесение урона в отдельную механику.
        var atomicObject = other.GetComponent<AtomicObject>();
        if (atomicObject)
        {
            _doDamageMechanics.DoDamage(atomicObject);
        }
        GameObject.Destroy(gameObject);
    }
}
