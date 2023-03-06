using UnityEngine;

public class AttackState : StateBase
{
    private float postAttackCooldown;
    private bool attackTriggered = false;

    public AttackState(StateHandler handler, MonsterController controller)
    {
        this.handler = handler;
        this.controller = controller;
    }

    public override StateBase OnStateEnter(MonsterController controller)
    {
        controller.Agent.isStopped = true;
        postAttackCooldown = 0;
        attackTriggered = false;

        if (controller.DistanceFromPlayer() > controller.AttackRange)
        {
            return handler.chaseState;
        }

        return this;
    }

    public override StateBase Tick(MonsterController controller)
    {
        if (!attackTriggered)
        {
            Debug.Log("Distance to Player: " + controller.DistanceFromPlayer());

            controller.OnAttack();
            attackTriggered = true;
            postAttackCooldown = controller.PostAttackMovementCooldown;
        }
        else
        {
            postAttackCooldown -= Time.deltaTime;
        }

        if (postAttackCooldown > 0) return this;

        return handler.chaseState;
    }

    public override void OnStateExit(MonsterController controller)
    {
        //Do nothing
    }
}