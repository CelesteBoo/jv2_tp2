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
    [SerializeField] private float refireCheck = 2f;

    private WizardBlackboard blackBoard;
    private ObjectPool wizardObjectPool;
    private ObjectPool spells;
    private WizardManager manager;
    private float defaultRefireCheck;

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
            spells = Finder.BlueSpellPool;
        else
            spells = Finder.GreenSpellPool;

        defaultRefireCheck = refireCheck;

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

        if (baseTarget.IsDead)
        {
            //change base target
        }
        state.update(this, blackBoard);

        return health <= 0;
    }

    private void fire()
    {
        var spell = spells.Get().GetComponent<Projectile>();
        if (spell != null)
        {
            spell.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
        //doit être fix
        spell.setDirection(target.position - rigidBody.position);
        refireCheck = defaultRefireCheck;
    }
}