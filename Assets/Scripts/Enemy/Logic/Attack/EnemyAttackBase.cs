using UnityEngine;

public class EnemyAttackBase : ScriptableObject
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
    public virtual void DoFrameUpdateLogic()   { }
    public virtual void DoPhysicsLogic() { }
    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType) { }
    public virtual void ResetValue() { }
}
