using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WizardNormalState : IWizardState
{
    public void Enter(Wizard wizard, WizardBlackboard blackBoard)
    {
        
    }

    public IWizardState Update(Wizard wizard, WizardBlackboard blackBoard)
    {
        if (wizard.CurrentHP <= wizard.MaxHP * 0.25f)
        {
            Debug.Log("FLEEING");
            return blackBoard.FleeState;
        }
        else if (wizard.ActiveTarget == null)
        {
            wizard.MoveTowardBaseTarget();   
        }
        else
        {
            wizard.fire();
        }
        return this;
    }

    public void Leave(Wizard wizard, WizardBlackboard blackBoard)
    {

    }
}