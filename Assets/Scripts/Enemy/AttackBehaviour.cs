using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    //public float speed = 5f;
    //private Vector3 goTo;
    [SerializeField]
    [Range(0f, 10f)]
    public float detectDistance = 7f;
    private AttackDetectionScript script;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        script = animator.gameObject.GetComponent<AttackDetectionScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // SetDirection(animator);
        Execute(animator);
        CheckTriggers(animator);

    }
    private void Execute(Animator animator)
    {

    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.3f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.3f);

            animator.SetIKPosition(AvatarIKGoal.LeftHand, player.position);
        }
    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayer = isPlayerClose(player, animator.transform);
        animator.SetBool("IsPatrolling", !isPlayer);
    }
    public bool isPlayerClose(Transform player, Transform enemy)
    {

        return Vector3.Distance(player.position, enemy.position) < detectDistance;
    }



}
