using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.Test
{

    public class Sample : MonoBehaviour
    {

        FreeInputCore core;
        ushort moveBindID = 0;
        public Transform role;

        void Awake()
        {
            core = new FreeInputCore();
        }

        void Update()
        {
            core.Tick();
            if (core.Getter.IsTriggered(moveBindID))
            {
                Debug.Log($"前进");
                role.transform.position += Vector3.forward * UnityEngine.Time.deltaTime;
            }
        }

        void OnGUI()
        {
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            if (GUILayout.Button("绑定 前进事件为 '按住' 触发")) core.Setter.BindStatus(moveBindID, KeyCodeStatus.Pressing);
            if (GUILayout.Button("绑定 前进事件为 '按下' 触发")) core.Setter.BindStatus(moveBindID, KeyCodeStatus.Down);
            if (GUILayout.Button("绑定 W")) core.Setter.BindKeyCode(moveBindID, KeyCode.W);
            if (GUILayout.Button("绑定 UpArrow")) core.Setter.BindKeyCode(moveBindID, KeyCode.UpArrow);
            if (GUILayout.Button("绑定 Keypad8")) core.Setter.BindKeyCode(moveBindID, KeyCode.Keypad8);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("解除绑定 W")) core.Setter.Unbind(moveBindID, KeyCode.W);
            if (GUILayout.Button("解除绑定 UpArrow")) core.Setter.Unbind(moveBindID, KeyCode.UpArrow);
            if (GUILayout.Button("解除绑定 Keypad8")) core.Setter.Unbind(moveBindID, KeyCode.Keypad8);
            if (GUILayout.Button("解除所有绑定")) core.Setter.UnbindAll();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("换绑 W ---> U  ")) core.Setter.RebindKeyCode(moveBindID, KeyCode.W, KeyCode.U);
            if (GUILayout.Button("换绑 U ---> W  ")) core.Setter.RebindKeyCode(moveBindID, KeyCode.U, KeyCode.W);
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }

    }

}