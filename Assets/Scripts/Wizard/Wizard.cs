using UnityEngine;

public class Wizard : MonoBehaviour, Hurtable
{
    [Header("Prefabs")]
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject range;
    [Header("Stats")]
    [SerializeField] private int health = 100;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Teams team;

    private WizardBlackboard blackBoard;
    private ObjectPool wizardObjectPool;
    private WizardManager manager;

    private Hurtable target;
    [SerializeField] private Tower baseTarget;
    private IWizardState state;

    private Rigidbody2D rigidBody;

    public Teams CurrentTeam => team;
    public int CurrentHP => health;

    public Hurtable Target => target;
    
    void Awake()
    {
        blackBoard = new WizardBlackboard(new WizardNormalState(), new WizardIntrepidState(), new WizardFleeState(), new WizardHideState(), new WizardSafeState());
        state = blackBoard.NormalState;

        if (team == Teams.TEAM1)
        {
            wizardObjectPool = Finder.BlueWizardObjectPool;
        }
        else
        {
            wizardObjectPool = Finder.GreenWizardObjectPool;
        }
        
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetBaseTarget(Tower tower)
    {
        baseTarget = tower;
    }

    void Update()
    {
        if (health <= 0)
        {
            
        }

        if (baseTarget.IsDead)
        {
            //change base target
        }
        state.update(this, blackBoard);
    }
    public void WizardToShoot(Wizard wizard)
    {
        if (target == null && wizard.CurrentTeam != team)
        {
            target = wizard;
        }
    }

    public void TowerToShoot(Tower tower)
    {
        if (target == null && tower.CurrentTeam != team)
        {
            target = tower;

        }
    }

    public void MoveTowardTarget()
    {
        Vector3 direction = baseTarget.transform.position - gameObject.transform.position;
        rigidBody.linearVelocity = direction.normalized * Time.deltaTime;
    }

    public bool hurt(int damage)
    {
        health -= damage;
        return health <= 0;
    }
}