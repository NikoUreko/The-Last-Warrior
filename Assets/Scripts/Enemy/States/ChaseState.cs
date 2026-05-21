using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    private float losePlayerTimer;

    public override void Enter()
    {
      enemy.Agent.isStopped = false;
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;

            // Cek apakah sudah cukup dekat untuk menyerang
            float distance = Vector3.Distance(enemy.transform.position, enemy.Player.transform.position);
            if (distance < 11f) // Ganti sesuai jarak serang kamu
            {
                stateMachine.ChangeState(new AttackState());
                return;
            }

            // Mengejar player
            enemy.Agent.SetDestination(enemy.Player.transform.position);
        }
        else
        {
            losePlayerTimer += Time.deltaTime;

            if (losePlayerTimer > 5f)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
}
