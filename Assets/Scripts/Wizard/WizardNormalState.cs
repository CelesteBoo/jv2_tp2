using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WizardNormalState : IWizardState
{
    public void Enter(Wizard wizard, WizardBlackboard blackBoard)
    {
        
    }

    public IWizardState update(Wizard wizard, WizardBlackboard blackBoard)
    {
        Debug.Log("Yes1");
        Hurtable target = wizard.Target;
        if (target == null)
        {
            wizard.MoveTowardTarget();   
        }
        else if (!target.hurt(10))
        {
            
        }
        return this;
    }

    public void Leave(Wizard wizard, WizardBlackboard blackBoard)
    {

    }
}