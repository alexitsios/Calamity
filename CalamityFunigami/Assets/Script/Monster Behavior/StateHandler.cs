public class StateHandler
{
    private MonsterController controller;
    public StateBase currentState { get; private set; }

    public IdleState idleState { get; private set; }
    public ChaseState chaseState { get; private set; }
    public AttackState attackState { get; private set; }

    public StateHandler(MonsterController controller)
    {
        this.controller = controller;

        idleState = new IdleState(this, controller);
        chaseState = new ChaseState(this, controller);
        attackState = new AttackState(this, controller);

        currentState = idleState;
        currentState.OnStateEnter(controller);
    }

    public void HandleStateMachine()
    {
        if (currentState != null)
        {
            StateBase nextPhase = currentState.Tick(controller);
            if (nextPhase != null) SwitchToNextState(nextPhase);
        }
        else currentState = idleState;
    }

    private void SwitchToNextState(StateBase phase)
    {
        if (currentState != phase)
        {
            currentState.OnStateExit(controller);

            currentState = phase.OnStateEnter(controller);
        }
        else currentState = phase;
    }
}
