using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.Test
{

    public class Sample : MonoBehaviour
    {

        FreeInputCore core;
        ushort moveBindID = 0;

        void Awake()
        {
            core = new FreeInputCore();

        }

        void Update()
        {
            core.Tick();
            if (core.Getter.HasKeyTriggered(moveBindID)) Debug.Log($"前进");
        }

        void OnGUI()
        {
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            if (GUILayout.Button("绑定 W")) core.Setter.BindWithKeyCode(moveBindID, KeyCode.W);
            if (GUILayout.Button("绑定 UpArrow")) core.Setter.BindWithKeyCode(moveBindID, KeyCode.UpArrow);
            if (GUILayout.Button("绑定 Keypad8")) core.Setter.BindWithKeyCode(moveBindID, KeyCode.Keypad8);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("解除绑定 W")) core.Setter.UnbindWithKeyCode(moveBindID, KeyCode.W);
            if (GUILayout.Button("解除绑定 UpArrow")) core.Setter.UnbindWithKeyCode(moveBindID, KeyCode.UpArrow);
            if (GUILayout.Button("解除绑定 Keypad8")) core.Setter.UnbindWithKeyCode(moveBindID, KeyCode.Keypad8);
            if (GUILayout.Button("解除所有绑定")) core.Setter.Unbind(moveBindID);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("换绑 W ---> U  ")) core.Setter.RebindWithKeyCode(moveBindID, KeyCode.W, KeyCode.U);
            if (GUILayout.Button("换绑 U ---> W  ")) core.Setter.RebindWithKeyCode(moveBindID, KeyCode.U, KeyCode.W);
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }

    }

}