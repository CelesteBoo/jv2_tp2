public interface IWizardState
{
    void Enter(Wizard wizard, WizardBlackboard blackBoard);
    IWizardState Update(Wizard wizard, WizardBlackboard blackBoard);
    void Leave(Wizard wizard, WizardBlackboard blackBoard);

}