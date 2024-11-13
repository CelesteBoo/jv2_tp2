using UnityEngine;

public class WizardFleeState : IWizardState
{
    private WizardManager m_wizardManager;
    private HidingSpot fleeingTarget;
    public void Enter(Wizard wizard, WizardBlackboard blackBoard)
    {
        m_wizardManager = Finder.WizardManager;
        fleeingTarget = m_wizardManager.getClosestHidingSpot(wizard.CurrentTeam, wizard.transform.position);
    }

    public IWizardState Update(Wizard wizard, WizardBlackboard blackBoard)
    {
        wizard.MoveTowards(fleeingTarget.getPosition());
        return this;
    }

    public void Leave(Wizard wizard, WizardBlackboard blackBoard)
    {

    }
}