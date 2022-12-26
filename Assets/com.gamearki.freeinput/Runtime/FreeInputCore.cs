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
            var statusDic = facades.bindStatusDic;
            var bindCodeDic = facades.bindCodeDic;
            var triggerDic = facades.triggerDic;
            var e = bindCodeDic.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                var bindID = e.Current;
                var status = statusDic[bindID];
                var codeList = bindCodeDic[bindID];
                triggerDic[bindID] = false;

                for (int i = 0; i < codeList.Count; i++)
                {
                    var keyCode = codeList[i];
                    var isKeyDown = Input.GetKeyDown(keyCode);
                    var isKeyPressing = Input.GetKey(keyCode);
                    var isKeyUp = Input.GetKeyUp(keyCode);

                    if (status == KeyCodeStatus.All && (isKeyDown || isKeyPressing || isKeyUp))
                    {
                        triggerDic[bindID] = true;
                        break;
                    }
                    if (status == KeyCodeStatus.Down && isKeyDown)
                    {
                        triggerDic[bindID] = true;
                        break;
                    }
                    if (status == KeyCodeStatus.Pressing && isKeyPressing)
                    {
                        triggerDic[bindID] = true;
                        break;
                    }
                    if (status == KeyCodeStatus.Up && isKeyUp)
                    {
                        triggerDic[bindID] = true;
                        break;
                    }
                }

            }
        }

    }

}