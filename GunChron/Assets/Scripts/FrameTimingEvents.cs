using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WellTold.Animation
{
    public class FrameTimingEvents : StateMachineBehaviour
    {
        [System.Serializable]
        public struct FrameEvent
        {
            public string EventName;
            [Range(0f, 1f)] public float FramePercent;
            private bool _hasFired;

            public bool HasFired
            {
                get { return _hasFired; }
            } // set { _hasFired = value; } }

            public void FireEvent(GameObject go, AnimatorStateInfo info)
            {
                _hasFired = true;
                go.SendMessage(EventName, info, SendMessageOptions.DontRequireReceiver);
            }

            public void Reset()
            {
                _hasFired = false;
            }
        }

        [SerializeField] private FrameEvent[] _frameEvents;
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float framePercent = stateInfo.normalizedTime % 1;
            for (int i = 0; i < _frameEvents.Length; i++)
            {
                if (!_frameEvents[i].HasFired)
                {
                    if (framePercent >= _frameEvents[i].FramePercent)
                    {
                        _frameEvents[i].FireEvent(animator.gameObject, stateInfo);

                        
                    }
                }
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (FrameEvent frameEvent in _frameEvents)
            {
                frameEvent.Reset();
            }
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