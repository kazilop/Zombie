
using UnityEngine;

public class EnemyIdleBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;


    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        this.enemy = enemy;
        transform = gameObject.transform;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { ResetValue(); }
    public virtual void DoFrameUpdateLogic() 
    {
        if (enemy.isAggres)
        {
            enemy.stateMachine.ChangeState(enemy.chaseState);
        }
    }
    public virtual void DoPhysicsLogic() { }
    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType) { }
    public virtual void ResetValue() { }
}
