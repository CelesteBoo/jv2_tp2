using Unity.VisualScripting;
using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField] private Wizard wizard;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.GetComponent<Wizard>();
        if (other != null)
        {
            wizard.WizardToShoot(other);
            return;
        }
    }
}