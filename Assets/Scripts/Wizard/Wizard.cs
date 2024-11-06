using UnityEngine;

public class Wizard : MonoBehaviour, Hurtable
{
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject range;
    [SerializeField] private int health = 100;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Teams team;


    private Teams curentTeam;
    private WizardBlackboard blackBoard;
    private Wizard activeTarget;

    public Teams CurrentTeam => team;
    public int CurrentHP => health;
    
    void Awake()
    {
        blackBoard = new WizardBlackboard(new WizardNormalState(), new WizardIntrepidState(), new WizardFleeState(), new WizardHideState(), new WizardSafeState());
    }

    public void SetTeam(Teams team)
    {
        curentTeam = team;
    }

    public void SetBaseTarget(GameObject tower)
    {

    }

    void Update()
    {
        if (activeTarget != null)
        {
            //shoot target
            if (activeTarget.CurrentHP <= 0)
            {
                activeTarget = null;
            }
            
            return;
        }
        
        gameObject.transform.position += new Vector3(speed, speed);
        
    }
    public void WizardToShoot(Wizard wizard)
    {
        if (activeTarget == null && wizard.CurrentTeam != team)
        {
            activeTarget = wizard;
        }
        Debug.Log(wizard.CurrentTeam);
        Debug.Log(team);
    }

    public void TowerToShoot(GameObject tower)
    {

    }
    public void hurt(int damage)
    {

    }
}