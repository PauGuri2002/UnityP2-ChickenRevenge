using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    Transform player;
    float timer;
    public float waitTime = 2;
    public float detectDistance = 4;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute();
        CheckTriggers(animator);

    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayer = IsPlayerClose(player, animator.transform);
        if (animator.gameObject.CompareTag("ChaserEnemy"))

        {
            animator.SetBool("IsChasing", isPlayer);

        }

        bool timeUp = IsTimeUp();
        animator.SetBool("IsPatrolling", timeUp);
    }
    private void Execute()
    {
        timer += Time.deltaTime;
    }


    public bool IsPlayerClose(Transform player, Transform enemy)
    {

        return Vector3.Distance(player.position, enemy.position) < detectDistance;
    }
    public bool IsTimeUp()
    {
        return timer > waitTime;
    }
}
