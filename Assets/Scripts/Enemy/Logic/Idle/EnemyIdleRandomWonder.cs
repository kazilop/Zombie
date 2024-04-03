using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Random Wander", menuName = "Enemy Logic/Idle Logic/Random Wonder")]

public class EnemyIdleRandomWonder : EnemyIdleBase
{

    [SerializeField] private float randomMovementRange = 5f;
    [SerializeField] private float randomMovementSpeed = 1f;

    private Vector3 _targetPosition;
    private Vector3 _direction;

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        _targetPosition = GetRandomPointInCircle();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        _direction = (_targetPosition - enemy.transform.position).normalized;

        Vector2 moveDerection = new Vector2(_direction.x, _direction.y);
        enemy.MoveEnemy(moveDerection * randomMovementSpeed);

        if ((enemy.transform.position - _targetPosition).sqrMagnitude < 0.01f)
        {
            _targetPosition = GetRandomPointInCircle();
        }
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValue()
    {
        base.ResetValue();
    }


    private Vector3 GetRandomPointInCircle()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * randomMovementRange;
    }
}
