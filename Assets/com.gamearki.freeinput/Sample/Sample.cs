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
            core.ISetter.BindEvent_Key(moveEventID, KeyCode.W, KeyCodeStatus.All);
            core.ISetter.BindEvent_Key(moveEventID, KeyCode.UpArrow, KeyCodeStatus.All);
            core.ISetter.BindEvent_Key(moveEventID, KeyCode.Keypad8, KeyCodeStatus.All);
        }

        void Update()
        {
            core.ISetter.TickEvent();
            if (core.IGetter.GetEvent(moveEventID)) Debug.Log($"前进");
        }

        void OnGUI()
        {

        }

    }

}