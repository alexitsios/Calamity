using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    public IdleState(StateHandler handler, MonsterController controller)
    {
        this.handler = handler;
        this.controller = controller;
    }

    public override StateBase OnStateEnter(MonsterController controller)
    {
        return this;
    }

    public override StateBase Tick(MonsterController controller)
    {
        //Player is within the chase radius of the monster
        if (controller.DistanceFromPlayer() <= controller.TriggerChaseDistance)
        {
            Vector3 directionToPlayer = (controller.Player.position - controller.Eyes.position);
            Vector3 rayPosition = controller.Eyes.position;

            RaycastHit hit;
            Ray ray = new Ray(rayPosition, directionToPlayer);
            Debug.DrawRay(rayPosition, directionToPlayer, Color.red);

            if (Physics.Raycast(ray, out hit, controller.TriggerChaseDistance))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    //The monster has a straight line of sight to the player
                    //Debug.Log("Can see player");
                    return handler.chaseState;
                }
            }
        }

        return this;
    }

    public override void OnStateExit(MonsterController controller)
    {
        //Do nothing
    }
}
