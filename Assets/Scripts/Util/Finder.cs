using UnityEngine;

public class Finder : MonoBehaviour
{
    private static ObjectPool blueSpellPool;
    private static ObjectPool greenSpellPool;
    private static ObjectPool blueWizardObjectPool;
    private static ObjectPool greenWizardObjectPool;
    private static WizardManager wizardManager;

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

    public static WizardManager WizardManager
    {
        get
        {
            if (wizardManager == null)
            {
                wizardManager = GameObject.Find("GameController").GetComponent<WizardManager>();
            }
            return wizardManager;
        }
    }

}
