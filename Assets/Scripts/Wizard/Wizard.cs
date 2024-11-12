using UnityEngine;

public class Wizard : MonoBehaviour, Hurtable
{
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private float refireCheck = 2f;
    private Teams currentTeam;
    private ObjectPool spells;
    private Vector2 target;
    private float defaultRefireCheck;
    private new Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (currentTeam == Teams.TEAM1)
            spells = Finder.BlueSpellPool;
        else
            spells = Finder.GreenSpellPool;
        target = new Vector3(0,0,0);
        defaultRefireCheck = refireCheck;
    }

    void Update()
    {
        rigidbody.position += new Vector2(0.001f, 0.001f);
        if (refireCheck <= 0)
            fire();

        refireCheck -= Time.deltaTime;
        
    }

    public void hurt(int damage)
    {

    }

    private void fire()
    {
        var spell = spells.Get().GetComponent<Projectile>();
        if (spell != null)
        {
            spell.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
        spell.setDirection(target - rigidbody.position);
        refireCheck = defaultRefireCheck;
    }
}