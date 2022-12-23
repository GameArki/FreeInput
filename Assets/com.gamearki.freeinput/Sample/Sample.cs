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
            core.ISetter.BindWithKeyCode(moveBindID, KeyCode.W, KeyCodeStatus.All);
            core.ISetter.BindWithKeyCode(moveBindID, KeyCode.UpArrow, KeyCodeStatus.All);
            core.ISetter.BindWithKeyCode(moveBindID, KeyCode.Keypad8, KeyCodeStatus.All);
        }

        void Update()
        {
            core.ISetter.TickInput();
            if (core.IGetter.HasTriggered(moveBindID)) Debug.Log($"前进");
        }

        void OnGUI()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("解除绑定W"))
            {
                core.ISetter.UnbindWithKeyCode(moveBindID, KeyCode.W);
            }
            if (GUILayout.Button("解除绑定UpArrow"))
            {
                core.ISetter.UnbindWithKeyCode(moveBindID, KeyCode.UpArrow);
            }
            if (GUILayout.Button("解除绑定Keypad8"))
            {
                core.ISetter.UnbindWithKeyCode(moveBindID, KeyCode.Keypad8);
            }
            if (GUILayout.Button("解除所有绑定"))
            {
                core.ISetter.Unbind(moveBindID);
            }
            GUILayout.EndHorizontal();
        }

    }

}