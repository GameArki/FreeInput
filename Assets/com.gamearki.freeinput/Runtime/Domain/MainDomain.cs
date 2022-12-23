using UnityEngine;
using FreeInput.Facades;
using FreeInput.Generic;
using System;
using System.Linq;

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

        public void BindWithKeyCode(ushort bindID, KeyCode keyCode)
        {
            var key = CombineKey(bindID, keyCode);
            var bindDic = facades.bindDic;
            var model = new KeyCodeModel();
            model.status = KeyCodeStatus.All;
            bindDic.Add(key, model);
        }

        public void BindWithKeyCode(ushort bindID, KeyCode keyCode, KeyCodeStatus status)
        {
            var key = CombineKey(bindID, keyCode);
            var bindDic = facades.bindDic;
            var model = new KeyCodeModel();
            model.status = status;
            bindDic.Add(key, model);
        }

        public void RebindWithKeyCode(ushort bindID, KeyCode oldKeyCode, KeyCode newKeyCode)
        {
            var oldKey = CombineKey(bindID, oldKeyCode);
            var bindDic = facades.bindDic;
            bindDic.Remove(oldKey);
            var newKey = CombineKey(bindID, newKeyCode);
            bindDic.Add(newKey, new KeyCodeModel());
        }

        public void UnbindWithKeyCode(ushort bindID, KeyCode keyCode)
        {
            var key = CombineKey(bindID, keyCode);
            facades.bindDic.Remove(key);
        }

        public void Unbind(ushort bindID)
        {
            var eventDic = facades.bindDic;
            var keys = eventDic.Keys;
            var e = keys.GetEnumerator();
            Span<uint> arry = new uint[keys.Count];
            int count = 0;
            while (e.MoveNext())
            {
                var key = e.Current;
                var id = key >> 16;
                if (id == bindID)
                {
                    arry[count++] = key;
                }
            }
            for (int i = 0; i < count; i++)
            {
                var key = arry[i];
                eventDic.Remove(key);
            }
        }

        public void UnbindAll()
        {
            facades.bindDic.Clear();
        }

        public bool HasKeyTriggered(ushort bindID)
        {
            var dic = facades.bindDic;
            var e = dic.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                var key = e.Current;
                var id = key >> 16;
                if (id == bindID && dic[key].hasTriggered)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsBind(ushort bindID, KeyCode keyCode)
        {
            var key = CombineKey(bindID, keyCode);
            return facades.bindDic.ContainsKey(key);
        }

        public bool ContainsBind(ushort bindID)
        {
            var eventDic = facades.bindDic;
            var keys = eventDic.Keys;
            var e = keys.GetEnumerator();
            while (e.MoveNext())
            {
                var k = e.Current;
                var id = k >> 16;
                if (id == bindID)
                {
                    return true;
                }
            }

            return false;
        }

        uint CombineKey(ushort bindID, KeyCode keycode)
        {
            uint key = (uint)keycode;
            key |= (uint)bindID << 16;
            return key;
        }

    }

}