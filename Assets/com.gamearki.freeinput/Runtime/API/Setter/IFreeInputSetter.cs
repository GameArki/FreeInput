using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.API.Setter
{

    public interface IFreeInputSetter
    {

        void TickEvent();
        void BindEvent_Key(ushort eventID, KeyCode keyCode, KeyCodeStatus keyCodeStatus);

    }

}