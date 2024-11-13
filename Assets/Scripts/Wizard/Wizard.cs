using UnityEngine;

public class Wizard : MonoBehaviour, Hurtable
{
    [Header("Prefabs")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject range;
    [Header("Stats")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float baseSpeed = 200;
    [SerializeField] private Teams team;
    [SerializeField] private float fireRate = 2;

    private WizardBlackboard blackBoard;
    private ObjectPool wizardObjectPool;
    private ObjectPool spells;
    private WizardManager manager;
    

    private Hurtable activeTarget;
    private Tower baseTarget;
    private IWizardState state;

    private Rigidbody2D rigidBody;

    private int health;
    private float fireRateTimer;
    private float healthBarMaxScale;

    public Teams CurrentTeam => team;
    public int CurrentHP => health;
    public int MaxHP => maxHealth;

    public float BaseSpeed => baseSpeed;

    public float FireRateTimer => fireRateTimer;

    public Hurtable ActiveTarget => activeTarget;
    
    void Awake()
    {
        blackBoard = new WizardBlackboard(new WizardNormalState(), new WizardIntrepidState(), new WizardFleeState(), new WizardHideState(), new WizardSafeState());
        state = blackBoard.NormalState;

        if (team == Teams.TEAM1)
            spells = Finder.BlueSpellPool;
        else
            spells = Finder.GreenSpellPool;

        if (team == Teams.TEAM1)
        {
            wizardObjectPool = Finder.BlueWizardObjectPool;
        }
        else
        {
            wizardObjectPool = Finder.GreenWizardObjectPool;
        }

        manager = Finder.WizardManager;
        
        rigidBody = GetComponent<Rigidbody2D>();

        health = maxHealth;
        healthBarMaxScale = healthBar.transform.lossyScale.x;
        baseTarget = manager.getRandomEnemyTower(team);
        fireRateTimer = fireRate;
    }

    private void Update()
    {
        if (activeTarget != null && !activeTarget.isAlive())
        {
            activeTarget = null;
        }
        if (baseTarget.IsDead)
        {
            baseTarget = manager.getRandomEnemyTower(team);
        }

        float percentHealth = health / maxHealth;
        if (percentHealth < 0)
        {
            percentHealth = 0;
        }
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.y, healthBarMaxScale * percentHealth);

        fireRateTimer -= Time.deltaTime;

        var nextState = state.Update(this, blackBoard);
        if (nextState != state)
        {
            state.Leave(this, blackBoard);
            state = nextState;
            state.Enter(this, blackBoard);
        }
    }

    public void SetActiveTarget(Hurtable target)
    {
        if (activeTarget == null && target.getTeam() != team)
        {
            activeTarget = target;
        }
    }

    public void MoveTowards(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        rigidBody.rotation = angle;
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * baseSpeed);
    }

    public void MoveTowardBaseTarget()
    {
        MoveTowards(baseTarget.transform.position);
    }

    public void hurt(int damage)
    {
        health -= damage;
    }

    public void fire()
    {
        if (fireRateTimer <= 0)
        {
            var spell = spells.Get().GetComponent<Projectile>();
            if (spell != null)
            {
                spell.transform.SetPositionAndRotation(transform.position, transform.rotation);
            }
            spell.setDirection(activeTarget.getPosition() - gameObject.transform.position);
            fireRateTimer = fireRate;
        }
    }

    public bool isAlive()
    {
        return health > 0;
    }

    public Vector3 getPosition()
    {
        return gameObject.transform.position;
    }

    public Teams getTeam()
    {
        return team;
    }
}