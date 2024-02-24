using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waightTimer;
    public override void Enter()
    {
    }
    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
    }
    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            waightTimer += Time.deltaTime;
            if (waightTimer > 1)
            {
                if (waypointIndex < enemy.path.waypoint.Count - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.waypoint[waypointIndex].position);
                waightTimer = 0;
            }
        }
    }
}
