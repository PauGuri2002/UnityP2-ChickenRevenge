using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class WonderBehaviour : StateMachineBehaviour
{
    Transform player;
    private PatrollingScript_EdgeDetection script;
    public List<Transform> wayPoints;
    //private int nextPosition = 0;
    //private int lastPosition = 0;
    //public float speed = 3f;
    //private Vector3 dir;
    //private Vector3 goTo;
    //private bool isReturning = false;
    public float detectDistance = 4;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        script = animator.GetComponent<PatrollingScript_EdgeDetection>();

        //for (int i = 0; i < length; i++)
        //{

        //        wayPoints.Add( GameObject.FindGameObjectsWithTag("WayPoint")[i].transform);


            
        //}
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //CheckPosition(animator);
        //SetDirection(animator);
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
