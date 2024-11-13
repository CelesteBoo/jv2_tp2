using UnityEngine;

public class WizardHideState : IWizardState
{
    public void Enter(Wizard wizard, WizardBlackboard blackBoard)
    {
        
    }

    public IWizardState Update(Wizard wizard, WizardBlackboard blackBoard)
    {
        
        return this;
    }

    public void Leave(Wizard wizard, WizardBlackboard blackBoard)
    {

    }
}