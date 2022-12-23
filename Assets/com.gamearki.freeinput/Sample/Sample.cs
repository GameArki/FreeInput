using UnityEngine;

namespace FreeInput.Test {

    public class Sample : MonoBehaviour {

        FreeInputCore core;
        ushort moveEventID = 0;

        void Awake() {
            core = new FreeInputCore();
            core.ISetter.BindEvent_KeyDown(moveEventID, KeyCode.Space);
            core.ISetter.BindEvent_KeyPressing(moveEventID, KeyCode.W);
            core.ISetter.BindEvent_KeyPressing(moveEventID, KeyCode.A);
            core.ISetter.BindEvent_KeyPressing(moveEventID, KeyCode.S);
            core.ISetter.BindEvent_KeyPressing(moveEventID, KeyCode.D);
        }

        void Update() {
            core.ISetter.TickEvent();
            if (core.IGetter.GetEvent(moveEventID)) Debug.Log($"GetEvent------Movement  !!!");
            if (core.IGetter.GetEvent(moveEventID, KeyCode.W)) Debug.Log($"GetEvent------Movement  W !!!");
            if (core.IGetter.GetEvent(moveEventID, KeyCode.S)) Debug.Log($"GetEvent------Movement  S !!!");
            if (core.IGetter.GetEvent(moveEventID, KeyCode.A)) Debug.Log($"GetEvent------Movement  A !!!");
            if (core.IGetter.GetEvent(moveEventID, KeyCode.D)) Debug.Log($"GetEvent------Movement  D !!!");
        }

        void OnGUI() {

        }

    }

}