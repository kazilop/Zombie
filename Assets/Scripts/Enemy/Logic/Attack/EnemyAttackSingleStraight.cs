using UnityEngine;


[CreateAssetMenu(fileName = "Attack-Straight Single", menuName = "Enemy Logic/Attack Logic/Straight Single")]

public class EnemyAttackSingleStraight : EnemyAttackBase
{

    [Header("Shoot settings")]
    [SerializeField] private Rigidbody2D monsterBullet;
    [SerializeField] private float _timeBetweenShot = 2f;
    [SerializeField] private float _distanceToCountExit = 3f;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _timeTillExit = 3f;

    private float _timer;
    private float _exitTimer;


    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        enemy.MoveEnemy(Vector2.zero);

        if (_timer > _timeBetweenShot)
        {
            _timer = 0f;

            Vector2 direction = (playerTransform.position - enemy.transform.position).normalized;

            Rigidbody2D bullet = GameObject.Instantiate(monsterBullet, enemy.transform.position, Quaternion.identity);
            bullet.velocity = direction * _bulletSpeed;
        }

        if (Vector2.Distance(playerTransform.position, enemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;

            if (_exitTimer > _timeTillExit)
            {
                enemy.stateMachine.ChangeState(enemy.chaseState);
            }
        }

        else
        {
            _exitTimer = 0f;
        }


        _timer += Time.deltaTime;
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
}
