using UnityEngine;

public class Wizard : MonoBehaviour, Hurtable
{
    [SerializeField] private GameObject HealthBar;
    private Teams curentTeam;
    
    void Awake()
    {

    }

    public void SetTeam(Teams team)
    {
        curentTeam = team;
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(0.01f, 0.01f);
        
    }

    public void hurt(int damage)
    {

    }
}