public interface IWizardState
{
    void Enter(Wizard wizard, WizardBlackboard blackBoard);
    IWizardState update(Wizard wizard, WizardBlackboard blackBoard);
    void Leave(Wizard wizard, WizardBlackboard blackBoard);

}