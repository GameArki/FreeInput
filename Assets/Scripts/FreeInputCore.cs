using System;
using System.Collections.Generic;
using UnityEngine;

namespace FreeInput
{

    public class FreeInputCore
    {

        //     eventID          |        keycode       
        //  0000 0000 0000 0000 | 0000 0000 0000 0000  
        Dictionary<uint, Action> eventDic_keyDown;
        Dictionary<uint, Action> eventDic_keyStay;
        Dictionary<uint, Action> eventDic_keyUp;

        public FreeInputCore()
        {
            eventDic_keyDown = new Dictionary<uint, Action>();
            eventDic_keyStay = new Dictionary<uint, Action>();
            eventDic_keyUp = new Dictionary<uint, Action>();
        }

        public void InvokeEvent_KeyDown(ushort eventID, KeyCode keyCode)
        {
            if (!Input.GetKeyDown(keyCode))
            {
                return;
            }
            var key = CombineKey(eventID, keyCode);
            eventDic_keyDown[key].Invoke();
        }

        public void InvokeAllEvents_KeyDown(ReadOnlySpan<ushort> eventIDs, ReadOnlySpan<KeyCode> keyCodes)
        {
            for (int i = 0; i < eventIDs.Length; i++)
            {
                var keyCode = keyCodes[i];
                if (!Input.GetKeyDown(keyCode))
                {
                    return;
                }
                var eid = eventIDs[i];
                var key = CombineKey(eid, keyCode);
                eventDic_keyDown[key].Invoke();
            }
        }

        public void InvokeEvent_KeyStay(ushort eventID, KeyCode keyCode)
        {
            if (!Input.GetKey(keyCode))
            {
                return;
            }
            var key = CombineKey(eventID, keyCode);
            eventDic_keyStay[key].Invoke();
        }

        public void InvokeAllEvents_KeyStay(ReadOnlySpan<ushort> eventIDs, ReadOnlySpan<KeyCode> keyCodes)
        {
            for (int i = 0; i < eventIDs.Length; i++)
            {
                var keyCode = keyCodes[i];
                if (!Input.GetKeyDown(keyCode))
                {
                    return;
                }
                var eid = eventIDs[i];
                var key = CombineKey(eid, keyCode);
                eventDic_keyStay[key].Invoke();
            }
        }

        public void InvokeEvent_KeyUp(ushort eventID, KeyCode keyCode)
        {
            if (!Input.GetKeyUp(keyCode))
            {
                return;
            }
            var key = CombineKey(eventID, keyCode);
            eventDic_keyUp[key].Invoke();
        }

        public void InvokeAllEvents_KeyUp(ReadOnlySpan<ushort> eventIDs, ReadOnlySpan<KeyCode> keyCodes)
        {
            for (int i = 0; i < eventIDs.Length; i++)
            {
                var keyCode = keyCodes[i];
                if (!Input.GetKeyUp(keyCode))
                {
                    return;
                }
                var eid = eventIDs[i];
                var key = CombineKey(eid, keyCode);
                eventDic_keyUp[key].Invoke();
            }
        }

        public void AddEvent_KeyDown(ushort eventID, KeyCode keyCode, Action action)
        {
            var key = CombineKey(eventID, keyCode);
            eventDic_keyDown.Add(key, action);
        }

        public void AddEvent_KeyStay(ushort eventID, KeyCode keyCode, Action action)
        {
            var key = CombineKey(eventID, keyCode);
            eventDic_keyStay.Add(key, action);
        }

        public void AddEvent_KeyUp(ushort eventID, KeyCode keyCode, Action action)
        {
            var key = CombineKey(eventID, keyCode);
            eventDic_keyUp.Add(key, action);
        }

        uint CombineKey(ushort eventID, KeyCode keycode)
        {
            uint key = (uint)keycode;
            key |= (uint)eventID << 16;
            return key;
        }

    }

}