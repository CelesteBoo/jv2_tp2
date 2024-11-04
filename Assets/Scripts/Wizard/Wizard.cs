using UnityEngine;

public class Wizard : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

public enum Teams { TEAM1, TEAM2 };