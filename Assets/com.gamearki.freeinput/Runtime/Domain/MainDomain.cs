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

        public bool HasTriggered(ushort id)
        {
            var dic = facades.bindDic;
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
            var eventDic = facades.bindDic;
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

        public void BindWithKeyCode(ushort bindID, KeyCode keyCode, KeyCodeStatus keyCodeStatus)
        {
            var key = CombineKey(bindID, keyCode);
            var bindDic = facades.bindDic;
            if (!bindDic.TryGetValue(key, out var keyCodeModel))
            {
                keyCodeModel = new KeyCodeModel();
                bindDic.Add(key, keyCodeModel);
            }

            keyCodeModel.keyCodeStatus = keyCodeStatus;
            keyCodeModel.isTrue = false;
        }

        public void UnbindWithKeyCode(ushort id, KeyCode keyCode)
        {
            var key = CombineKey(id, keyCode);
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

        public bool ContainsBind(ushort id, KeyCode keyCode)
        {
            var key = CombineKey(id, keyCode);
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