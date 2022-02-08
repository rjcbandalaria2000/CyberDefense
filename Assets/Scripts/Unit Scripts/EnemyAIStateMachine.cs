using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIStateMachine : StateMachineBehaviour
{
    public GameObject unit;
    public GameObject target;
    public float unitBaseAttackTime;
    public float attackTime;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        unit = animator.gameObject.transform.parent.transform.parent.gameObject;
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = unit.GetComponent<Targeting>().Target;
        if (target)
        {
            animator.SetBool("hasTarget", true);
        }
        else
        {
            animator.SetBool("hasTarget", false);
            animator.SetBool("isPatrolling", true);
        }
        //if (unit.GetComponent<AIMovement>().IsLastWaypoint())
        //{
        //    animator.SetBool("isPatrolling", false);
        //    animator.SetBool("isIdle", true);
        //}
       
        //else if (unit.GetComponent<Enemy>().Target)
        //{
        //    if (unit.GetComponent<Animator>().GetBool("hasTarget") == false)
        //    {
        //        unit.GetComponent<Animator>().SetBool("hasTarget", true);
        //    }
        //}
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}