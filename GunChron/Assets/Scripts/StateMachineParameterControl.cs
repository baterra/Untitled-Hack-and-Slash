using UnityEngine;
using System.Collections;

namespace WellTold.Animation
{
    public class StateMachineParameterControl : StateMachineBehaviour
    {
        [System.Serializable]
        public struct BoolParameter
        {
            public string name;
            public bool setValue;
        }

        [System.Serializable]
        public struct FloatParameter
        {
            public string name;
            public float setValue;
        }

        [System.Serializable]
        public struct IntParameter
        {
            public string name;
            public int setValue;
        }

        public bool isSubStateMachine;
        [Header("On Enter Parameters")] [SerializeField] public BoolParameter[] boolParameters_OnEnter;
        [SerializeField] public FloatParameter[] floatParameters_OnEnter;
        [SerializeField] public IntParameter[] intParameters_OnEnter;
        [Header("On Exit Parameters")] [SerializeField] public BoolParameter[] boolParameters_OnExit;
        [SerializeField] public FloatParameter[] floatParameters_OnExit;
        [SerializeField] public IntParameter[] intParameters_OnExit;

        [Header("OnEnter Events")] public string[] onEnterEvents;
        [Header("OnExit Events")] public string[] onExitEvents;

        public bool breakOnEnter;
        public bool breakOnExit;
        public bool breakOnFixFrame;
        public bool useFixFrame;
        public bool isDebugging;

        private bool firstEnterCalled;
        // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (isDebugging) Debug.Log(stateInfo.fullPathHash.ToString() + " OnStateEnter");
            if (isSubStateMachine) return;
            //Debug.Log("DEBUG");
            foreach (BoolParameter param in boolParameters_OnEnter)
            {
                animator.SetBool(param.name, param.setValue);
            }
            foreach (FloatParameter param in floatParameters_OnEnter)
            {
                animator.SetFloat(param.name, param.setValue);
            }
            foreach (IntParameter param in intParameters_OnEnter)
            {
                animator.SetInteger(param.name, param.setValue);
            }

            foreach (string s in onEnterEvents)
            {
                animator.gameObject.SendMessage(s, SendMessageOptions.DontRequireReceiver);
            }

            firstEnterCalled = true;
            if (breakOnEnter) Debug.Break();
        }

        // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (isDebugging) Debug.Log(stateInfo.fullPathHash.ToString() + " OnStateUpdate");
            if (!useFixFrame) return;
            if (!firstEnterCalled)
            {
                if (isDebugging) Debug.Log("Called StateEnter from Update");
                if (breakOnFixFrame) Debug.Break();
                OnStateEnter(animator, stateInfo, layerIndex);
            }
        }

        // OnStateExit is called before OnStateExit is called on any state inside this state machine
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (isDebugging) Debug.Log(stateInfo.fullPathHash.ToString() + " OnStateExit");
            if (isSubStateMachine) return;
            foreach (BoolParameter param in boolParameters_OnExit)
            {
                animator.SetBool(param.name, param.setValue);
            }
            foreach (FloatParameter param in floatParameters_OnExit)
            {
                animator.SetFloat(param.name, param.setValue);
            }
            foreach (IntParameter param in intParameters_OnExit)
            {
                animator.SetInteger(param.name, param.setValue);
            }

            foreach (string s in onExitEvents)
            {
                animator.gameObject.SendMessage(s, SendMessageOptions.DontRequireReceiver);
            }
            firstEnterCalled = false;
            if (breakOnExit) Debug.Break();
        }


        // OnStateMove is called before OnStateMove is called on any state inside this state machine
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateIK is called before OnStateIK is called on any state inside this state machine
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateMachineEnter is called when entering a statemachine via its Entry Node
        override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            if (isDebugging) Debug.Log(stateMachinePathHash + " OnStateMachineEnter");
            if (!isSubStateMachine) return;
            //Debug.Log("DEBUG");
            foreach (BoolParameter param in boolParameters_OnEnter)
            {
                animator.SetBool(param.name, param.setValue);
            }
            foreach (FloatParameter param in floatParameters_OnEnter)
            {
                animator.SetFloat(param.name, param.setValue);
            }
            foreach (IntParameter param in intParameters_OnEnter)
            {
                animator.SetInteger(param.name, param.setValue);
            }

            foreach (string s in onEnterEvents)
            {
                animator.gameObject.SendMessage(s, SendMessageOptions.DontRequireReceiver);
            }
            firstEnterCalled = true;
            if (breakOnEnter) Debug.Break();
        }

        // OnStateMachineExit is called when exiting a statemachine via its Exit Node
        override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            if (isDebugging) Debug.Log(stateMachinePathHash + " OnStateMachineExit");
            if (!isSubStateMachine) return;
            foreach (BoolParameter param in boolParameters_OnExit)
            {
                animator.SetBool(param.name, param.setValue);
            }
            foreach (FloatParameter param in floatParameters_OnExit)
            {
                animator.SetFloat(param.name, param.setValue);
            }
            foreach (IntParameter param in intParameters_OnExit)
            {
                animator.SetInteger(param.name, param.setValue);
            }

            foreach (string s in onExitEvents)
            {
                animator.gameObject.SendMessage(s, SendMessageOptions.DontRequireReceiver);
            }
            firstEnterCalled = false;
            if (breakOnExit) Debug.Break();
        }


        private bool ContainsParam(Animator animator, string paramName)
        {
            foreach (AnimatorControllerParameter param in animator.parameters)
            {
                if (param.name == paramName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}