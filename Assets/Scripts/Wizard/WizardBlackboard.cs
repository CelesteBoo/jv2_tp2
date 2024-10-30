public class WizardBlackboard
{
    private readonly WizardNormalState normalState;
    private readonly WizardIntrepidState intrepidState;
    private readonly WizardFleeState fleeState;
    private readonly WizardHideState hideState;
    private readonly WizardSafeState safeState;
    //private readonly WizardLastStandState lastStandState;

    public WizardNormalState NormalState => normalState;
    public WizardIntrepidState IntrepidState => intrepidState;
    public WizardFleeState FleeState => fleeState;
    public WizardHideState HideState => hideState;
    public WizardSafeState SafeState => safeState;

    public WizardBlackboard
    (
        WizardNormalState normalState,
        WizardIntrepidState intrepidState,
        WizardFleeState fleeState,
        WizardHideState hideState,
        WizardSafeState safeState
    )
    {
        this.normalState = normalState;
        this.intrepidState = intrepidState;
        this.fleeState = fleeState;
        this.hideState = hideState;
        this.safeState = safeState;
    }
}