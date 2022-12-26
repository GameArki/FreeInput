using System;
using System.Collections.Generic;
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

        public void BindKeyCode(ushort bindID, KeyCode keyCode)
        {
            var key = CombineKey(bindID, keyCode);
            var dic = facades.bindCodeDic;
            if (!dic.TryGetValue(bindID, out var list))
            {
                list = new List<KeyCode>();
                dic.Add(bindID, list);
            }
            list.Add(keyCode);
        }

        public void BindStatus(ushort bindID, KeyCodeStatus status)
        {
            facades.bindStatusDic.Add(bindID, status);
        }

        public void RebindKeyCode(ushort bindID, KeyCode oldKeyCode, KeyCode newKeyCode)
        {
            var dic = facades.bindCodeDic;
            if (!dic.TryGetValue(bindID, out var list))
            {
                return;
            }

            list.Remove(oldKeyCode);
            list.Add(newKeyCode);
        }

        public void Unbind(ushort bindID, KeyCode keyCode)
        {
            var dic = facades.bindCodeDic;
            if (!dic.TryGetValue(bindID, out var list))
            {
                return;
            }
            list.Remove(keyCode);
        }

        public void UnbindAll()
        {
            facades.bindStatusDic.Clear();
            facades.bindCodeDic.Clear();
            facades.triggerDic.Clear();
        }

        public bool IsTriggered(ushort bindID)
        {
            var dic = facades.triggerDic;
            if (!dic.TryGetValue(bindID, out var isTriggered))
            {
                return false;
            }
            return isTriggered;
        }

        uint CombineKey(ushort bindID, KeyCode keyCode)
        {
            uint key = (uint)keyCode;
            key |= (uint)bindID << 16;
            return key;
        }

    }

}