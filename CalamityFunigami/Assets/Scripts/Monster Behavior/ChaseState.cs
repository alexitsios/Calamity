using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateBase
{
    public ChaseState(StateHandler handler, MonsterController controller)
    {
        this.handler = handler;
        this.controller = controller;
    }

    public override StateBase OnStateEnter(MonsterController controller)
    {
        controller.Agent.speed = controller.MovementSpeed;
        return this;
    }

    public override StateBase Tick(MonsterController controller)
    {
        if (controller.DistanceFromPlayer() > controller.ChaseDistance)
        {
            return handler.idleState;
        }

        if (controller.DistanceFromPlayer() <= controller.AttackRange)
        {
            //Stop agent on the spot
            controller.Agent.isStopped = true;

            if (controller.TimeToNextAttack <= 0)
            {
                return handler.attackState;
            }
        }
        else
        {
            //resume agent movement
            controller.Agent.isStopped = false;
        }

        controller.FaceTarget(controller.Player.position);
        controller.Agent.SetDestination(controller.Player.position);

        return this;
    }

    public override void OnStateExit(MonsterController controller)
    {
        //Do nothing
    }
}
