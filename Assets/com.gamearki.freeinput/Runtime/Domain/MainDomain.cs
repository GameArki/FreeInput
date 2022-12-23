using UnityEngine;
using FreeInput.Facades;
using FreeInput.Generic;

namespace FreeInput.Domain
{

    public class MainDomain
    {

        FreeInputFacades facades;

        public MainDomain() { }

        public void Inject(FreeInputFacades facades)
        {
            this.facades = facades;
        }

        public bool HasTriggered(ushort id)
        {
            var dic = facades.eventDic;
            var e = dic.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                var key = e.Current;
                var evID = (ushort)(key >> 16);
                if (evID == id)
                {
                    var keyCodeModel = dic[key];
                    if (keyCodeModel.isTrue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void TickInput()
        {
            var eventDic = facades.eventDic;
            var keys = eventDic.Keys;
            var e = keys.GetEnumerator();
            while (e.MoveNext())
            {
                var key = e.Current;
                var keyCodeModel = eventDic[key];
                var keyCode = (KeyCode)(ushort)key;
                if (keyCodeModel.keyCodeStatus.Contains(KeyCodeStatus.Down) && Input.GetKeyDown(keyCode))
                {
                    keyCodeModel.isTrue = true;
                    return;
                }

                if (keyCodeModel.keyCodeStatus.Contains(KeyCodeStatus.Pressing) && Input.GetKey(keyCode))
                {
                    keyCodeModel.isTrue = true;
                    return;
                }

                if (keyCodeModel.keyCodeStatus.Contains(KeyCodeStatus.Up) && Input.GetKeyUp(keyCode))
                {
                    keyCodeModel.isTrue = true;
                    return;
                }

                keyCodeModel.isTrue = false;
            }
        }

        public void BindWithKeyCode(ushort eventID, KeyCode keyCode, KeyCodeStatus keyCodeStatus)
        {
            var key = CombineKey(eventID, keyCode);
            KeyCodeModel keyCodeModel = new KeyCodeModel();
            keyCodeModel.keyCodeStatus = keyCodeStatus;
            keyCodeModel.isTrue = false;
            var eventDic = facades.eventDic;
            eventDic.Add(key, keyCodeModel);
        }

        uint CombineKey(ushort eventID, KeyCode keycode)
        {
            uint key = (uint)keycode;
            key |= (uint)eventID << 16;
            return key;
        }

    }

}