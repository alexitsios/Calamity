public abstract class StateBase
{
    public MonsterController controller;
    public StateHandler handler;

    public abstract StateBase OnStateEnter(MonsterController controller);
    public abstract StateBase Tick(MonsterController controller);
    public abstract void OnStateExit(MonsterController controller);
}