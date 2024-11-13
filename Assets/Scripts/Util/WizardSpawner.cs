using UnityEngine;

public class WizardSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private ObjectPool wizardPool;
    [SerializeField, Tooltip("In seconds."), Min(0)] private float delay = 3f;
    [SerializeField] private Teams team;

    private WizardManager wizardManager;

    private Awaitable routine;

    private void OnEnable()
    {
        wizardManager = Finder.WizardManager;
        routine = SpawningRoutine();
    }

    private void OnDisable()
    {
        routine.Cancel();
    }

    private async Awaitable SpawningRoutine()
    {
        while (isActiveAndEnabled)
        {
            var wizard = wizardPool.Get();
            if (wizard != null)
            {
                Tower spawnTower = wizardManager.getRandomAllyTower(team);
                wizard.transform.position = spawnTower.transform.position;
            }
            await Awaitable.WaitForSecondsAsync(delay);
        }
    }
}
