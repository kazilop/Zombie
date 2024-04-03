using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; } = true;

    [SerializeField] Slider slider;

    [SerializeField] private GameObject[] dropList;




    #region State Machine Variables
    public EnemyStateMachine stateMachine { get; set; }
    public EnemyIdleState idleState { get; set; }
    public EnemyChaseState chaseState { get; set; }
    public EnemyAttackState attackState { get; set; }
    public bool isAggres { get; set; }
    public bool isInStrikeDistance { get; set; }
    #endregion


    #region ScriptableObject Variables

    [Header("Setup Logic")]
    [SerializeField] private EnemyIdleBase enemyIdleBase;
    [SerializeField] private EnemyChaseBase enemyChaseBase;
    [SerializeField] private EnemyAttackBase enemyAttackBase;

    public EnemyIdleBase EnemyIdleBaseInstance { get; set; }
    public EnemyChaseBase EnemyChaseBaseInstance { get; set; }
    public EnemyAttackBase EnemyAttackBaseInstance { get; set; }

    #endregion


    private void Awake()
    {
        EnemyIdleBaseInstance = Instantiate(enemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(enemyChaseBase);
        EnemyAttackBaseInstance = Instantiate(enemyAttackBase);

        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);
    }


    private void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;

        slider.maxValue = maxHealth;
        slider.minValue = 0f;
        UpdateUI();

        rb = GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.gravityScale = 0f;
        }

        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        stateMachine.Initialize(idleState);
    }


    private void Update()
    {
        stateMachine.currentEnemyState.FrameUpdate();
    }


    private void FixedUpdate()
    {
        stateMachine.currentEnemyState.PhysicsUpdate();
    }


    #region Health and Die function
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateUI();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        DropItem();
        Destroy(gameObject);
    }


    private void DropItem()
    {
        if (dropList.Length > 0)
        {
            int randomIndex = Random.Range(0, dropList.Length);
            GameObject itemToDrop = dropList[randomIndex];

            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }

    #endregion


    #region Movement functions
    public void MoveEnemy(Vector2 velocity)
    {
        rb.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }


    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if(isFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }

        else if(!isFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
    }

    #endregion


    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        stateMachine.currentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepSound
    }

    #endregion


    #region Agro Trigers
    public void SetAgroStatus(bool isAggr)
    {
        isAggres = isAggr;
    }

    public void SetStrikeDistanceBool(bool isInStrike)
    {
        isInStrikeDistance = isInStrike;
    }

    #endregion


    private void UpdateUI()
    {
        slider.value = currentHealth;
    }

}
