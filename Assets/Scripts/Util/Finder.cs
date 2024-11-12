using UnityEngine;

public class Finder : MonoBehaviour
{
    private static ObjectPool blueWizardObjectPool;
    private static ObjectPool greenWizardObjectPool;
    private static ObjectPool spellPool;

    public static ObjectPool BlueWizardObjectPool
    {
        get
        {
            if (blueWizardObjectPool == null)
            {
                blueWizardObjectPool = GameObject.Find("BlueWizardObjectPool").GetComponent<ObjectPool>();
            }
            return blueWizardObjectPool;
        }
    }

    public static ObjectPool GreenWizardObjectPool
    {
        get
        {
            if (greenWizardObjectPool == null)
            {
                greenWizardObjectPool = GameObject.Find("GreenWizardObjectPool").GetComponent<ObjectPool>();
            }
            return greenWizardObjectPool;
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
