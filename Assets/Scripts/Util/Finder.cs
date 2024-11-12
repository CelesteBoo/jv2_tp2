using UnityEngine;

public class Finder : MonoBehaviour
{
<<<<<<< HEAD
    private static ObjectPool wizardObjectPool;
    private static ObjectPool blueSpellPool;
    private static ObjectPool greenSpellPool;   
=======
    private static ObjectPool blueWizardObjectPool;
    private static ObjectPool greenWizardObjectPool;
    private static ObjectPool spellPool;
>>>>>>> b2aa3a87651c020bcb521284d4a9ab0a6a27c39c

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
