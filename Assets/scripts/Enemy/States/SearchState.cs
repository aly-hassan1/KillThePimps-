using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    public Weapon weapon;

    
    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnowPos);
        weapon = GameObject.FindWithTag("Weapon").GetComponent<Weapon>();

    }
    public override void Perform()
    {

        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        else if (weapon.isShooting)
        {
            enemy.Agent.SetDestination(enemy.Player.transform.position);
        }
        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(2, 3))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));

                moveTimer = 0;
            }
            if (searchTimer > 10)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
    public override void Exit()
    {

    }
}
