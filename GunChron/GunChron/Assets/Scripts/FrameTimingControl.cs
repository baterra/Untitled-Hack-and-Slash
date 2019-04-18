using UnityEngine;
using System.Collections;

namespace WellTold.Animation
{

    public class FrameTimingControl : StateMachineBehaviour
    {
        public AnimationCurve speedCurve;
        public bool isDebugging;
        private float? originalAnimatorSpeed = null;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{

        //}

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (originalAnimatorSpeed == null)
            {
                originalAnimatorSpeed = animator.speed;
            }
            if (animator.GetBool("StopPunch"))
            {
                animator.speed = 1;
                return;
            }
            animator.speed = speedCurve.Evaluate(stateInfo.normalizedTime % 1);

            if (isDebugging) Debug.Log("Speed = " + animator.speed + " , stateTime = " + stateInfo.normalizedTime % 1);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (originalAnimatorSpeed != null)
            {
                animator.speed = (float) originalAnimatorSpeed;
            }
            else
            {
                animator.speed = 1f;
            }
            originalAnimatorSpeed = null;
        }

        // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}
    }
}
