using UnityEngine;

public class Finder : MonoBehaviour
{
    private static ObjectPool wizardObjectPool;
    private static ObjectPool blueSpellPool;
    private static ObjectPool greenSpellPool;   

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

    public static ObjectPool BlueSpellPool
    {
        get
        {
            if (blueSpellPool == null)
            {
                blueSpellPool = GameObject.Find("BlueSpellPool").GetComponent<ObjectPool>();
            }
            return blueSpellPool;
        }
    }

    public static ObjectPool GreenSpellPool
    {
        get
        {
            if (greenSpellPool == null)
            {
                greenSpellPool = GameObject.Find("GreenSpellPool").GetComponent<ObjectPool>();
            }
            return greenSpellPool;
        }
    }

}
