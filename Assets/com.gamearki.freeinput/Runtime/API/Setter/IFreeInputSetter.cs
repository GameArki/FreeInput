using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.API.Setter
{

    public interface IFreeInputSetter
    {

        void Tick();
        void BindWithKeyCode(ushort id, KeyCode keyCode, KeyCodeStatus keyCodeStatus);

    }

}