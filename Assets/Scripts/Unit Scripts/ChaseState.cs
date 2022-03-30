using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    public GameObject Unit; 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Unit = animator.transform.parent.gameObject.GetComponent<ModelInfo>().Parent; ;
        NavMeshAgent UnitNavMesh = Unit.GetComponent<NavMeshAgent>();
        if (UnitNavMesh)
        {
            Debug.Log("Unit has NavMesh");
            Targeting UnitTargeting = Unit.GetComponent<Targeting>();
            if (UnitTargeting)
            {
                Debug.Log("Unit has targeting");
                if (UnitNavMesh.isStopped)
                {
                    UnitNavMesh.isStopped = false;
                }
                UnitNavMesh.destination = UnitTargeting.Target.transform.gameObject.transform.position;
            }

        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}