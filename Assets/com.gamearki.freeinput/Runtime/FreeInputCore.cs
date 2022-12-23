using UnityEngine;
using FreeInput.Facades;
using FreeInput.Generic;
using FreeInput.API.Setter;
using FreeInput.API.Getter;

namespace FreeInput
{

    public class FreeInputCore
    {

        FreeInputFacades facades;

        FreeInputSetter setter;
        public IFreeInputSetter Setter => setter;

        FreeInputGetter getter;
        public IFreeInputGetter Getter => getter;

        public FreeInputCore()
        {
            facades = new FreeInputFacades();
            setter = new FreeInputSetter();
            getter = new FreeInputGetter();
            setter.Inject(facades);
            getter.Inject(facades);
        }

        public void Tick()
        {
            var eventDic = facades.bindDic;
            var keys = eventDic.Keys;
            var e = keys.GetEnumerator();
            while (e.MoveNext())
            {
                var key = e.Current;
                var keyCodeModel = eventDic[key];
                var keyCode = (KeyCode)(ushort)key;
                var status = keyCodeModel.status;
                var isKeyDown = Input.GetKeyDown(keyCode);
                var isKeyPressing = Input.GetKey(keyCode);
                var isKeyUp = Input.GetKeyUp(keyCode);
                if (status == KeyCodeStatus.All && (isKeyDown || isKeyPressing || isKeyUp))
                {
                    keyCodeModel.hasTriggered = true;
                    continue;
                }
                if (status == KeyCodeStatus.Down && isKeyDown)
                {
                    keyCodeModel.hasTriggered = true;
                    continue;
                }
                if (status == KeyCodeStatus.Pressing && isKeyPressing)
                {
                    keyCodeModel.hasTriggered = true;
                    continue;
                }
                if (status == KeyCodeStatus.Up && isKeyUp)
                {
                    keyCodeModel.hasTriggered = true;
                    continue;
                }

                keyCodeModel.hasTriggered = false;
            }
        }

    }

}