using UnityEngine;
using FreeInput.Facades;
using FreeInput.Generic;

namespace FreeInput.API.Setter {

    public class FreeInputSetter : IFreeInputSetter {

        FreeInputFacades facades;

        public void Inject(FreeInputFacades facades) {
            this.facades = facades;
        }

        void IFreeInputSetter.TickEvent() {
            var eventDic = facades.eventDic;
            var keys = eventDic.Keys;
            var e = keys.GetEnumerator();
            while (e.MoveNext()) {
                var key = e.Current;
                var keyCodeModel = eventDic[key];
                var keyCode = (KeyCode)(ushort)key;
                if (keyCodeModel.keyCodeStatus == KeyCodeStatus.KeyDown) {
                    keyCodeModel.isTrue = Input.GetKeyDown(keyCode);
                } else if (keyCodeModel.keyCodeStatus == KeyCodeStatus.KeyPressing) {
                    keyCodeModel.isTrue = Input.GetKey(keyCode);
                } else if (keyCodeModel.keyCodeStatus == KeyCodeStatus.KeyUp) {
                    keyCodeModel.isTrue = Input.GetKeyUp(keyCode);
                }
            }
        }

        void IFreeInputSetter.BindEvent_KeyDown(ushort eventID, KeyCode keyCode) {
            var key = CombineKey(eventID, keyCode);
            KeyCodeModel keyCodeModel = new KeyCodeModel();
            keyCodeModel.keyCodeStatus = KeyCodeStatus.KeyDown;
            keyCodeModel.isTrue = false;
            var eventDic = facades.eventDic;
            eventDic.Add(key, keyCodeModel);
        }

        void IFreeInputSetter.BindEvent_KeyPressing(ushort eventID, KeyCode keyCode) {
            var key = CombineKey(eventID, keyCode);
            KeyCodeModel keyCodeModel = new KeyCodeModel();
            keyCodeModel.keyCodeStatus = KeyCodeStatus.KeyPressing;
            keyCodeModel.isTrue = false;
            var eventDic = facades.eventDic;
            eventDic.Add(key, keyCodeModel);
        }

        void IFreeInputSetter.BindEvent_KeyUp(ushort eventID, KeyCode keyCode) {
            var key = CombineKey(eventID, keyCode);
            KeyCodeModel keyCodeModel = new KeyCodeModel();
            keyCodeModel.keyCodeStatus = KeyCodeStatus.KeyUp;
            keyCodeModel.isTrue = false;
            var eventDic = facades.eventDic;
            eventDic.Add(key, keyCodeModel);
        }

        uint CombineKey(ushort eventID, KeyCode keycode) {
            uint key = (uint)keycode;
            key |= (uint)eventID << 16;
            return key;
        }

    }

}