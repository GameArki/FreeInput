using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.Test
{

    public class Sample : MonoBehaviour
    {

        FreeInputCore core;
        ushort moveEventID = 0;

        void Awake()
        {
            core = new FreeInputCore();
            core.ISetter.BindWithKeyCode(moveEventID, KeyCode.W, KeyCodeStatus.All);
            core.ISetter.BindWithKeyCode(moveEventID, KeyCode.UpArrow, KeyCodeStatus.All);
            core.ISetter.BindWithKeyCode(moveEventID, KeyCode.Keypad8, KeyCodeStatus.All);
        }

        void Update()
        {
            core.ISetter.TickInput();
            if (core.IGetter.HasTriggered(moveEventID)) Debug.Log($"前进");
        }

        void OnGUI()
        {

        }

    }

}