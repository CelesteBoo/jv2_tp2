using UnityEngine;

public class Finder : MonoBehaviour
{
    private static ObjectPool wizardObjectPool;
    private static ObjectPool spellPool;

    public static ObjectPool WizardObjectPool
    {
        get
        {
            if (wizardObjectPool == null)
            {
                wizardObjectPool = GameObject.Find("WizardObjectPool").GetComponent<ObjectPool>();
            }
            return wizardObjectPool;
        }
    }

    public static ObjectPool SpellPool
    {
        get
        {
            if (spellPool == null)
            {
                spellPool = GameObject.Find("SpellPool").GetComponent<ObjectPool>();
            }
            return spellPool;
        }
    }

}
