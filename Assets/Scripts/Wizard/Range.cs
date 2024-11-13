using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class Range : MonoBehaviour
{
    [SerializeField] private Wizard wizard;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherWiz = collision.GetComponent<Wizard>();
        if (otherWiz != null)
        {
            wizard.SetActiveTarget(otherWiz);
            return;
        }
        var otherTower = collision.GetComponent<Tower>();
        if (otherTower != null)
        {
            wizard.SetActiveTarget(otherTower);
            return;
        }
    }
}