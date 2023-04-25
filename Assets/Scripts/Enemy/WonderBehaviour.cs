using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class WonderBehaviour : StateMachineBehaviour
{
    Transform player;
    private PatrollingScript_EdgeDetection script;
    public List<Transform> wayPoints;
    public float detectDistance = 4;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        script = animator.gameObject.GetComponent<PatrollingScript_EdgeDetection>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        Execute(animator);
        CheckTriggers(animator);
        
    }

    private void Execute(Animator animator)
    {
        if (!animator.GetBool("IsPatrolling"))
        {
            script.enabled = false;
        }
        else
        {
            script.enabled = true;

        }


    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayer = isPlayerClose(player, animator.transform);
        animator.SetBool("IsChasing", isPlayer);
        animator.SetBool("IsPatrolling", !isPlayer);
    }
    public bool isPlayerClose(Transform player, Transform enemy)
    {

        return Vector3.Distance(player.position, enemy.position) < detectDistance;
    }

    
}
