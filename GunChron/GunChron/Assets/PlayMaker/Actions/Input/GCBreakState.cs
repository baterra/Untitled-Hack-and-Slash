
// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

// this is a version of HutongGames' get key down action script
// edited to also check the player's stag bar (guarding bar) before 
// sending an event

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Sends an Event when a Key is pressed.")]
    public class GCBreakState : FsmStateAction
    {
        [RequiredField]
        public KeyCode key;
        public FsmEvent sendEvent;
        public Entity breakEntity; // the entity to check break state

        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void Reset()
        {
            sendEvent = null;
            key = KeyCode.None;
            storeResult = null;
        }

        public override void OnUpdate()
        {
            bool keyDown = Input.GetKeyDown(key);

            if (keyDown && !breakEntity.isBreak) // if the key is pressed and character is not in break state
                Fsm.Event(sendEvent); // send state machine event

            storeResult.Value = keyDown;
        }
    }
}