using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.API.Setter
{

    public interface IFreeInputSetter
    {

        void TickInput();
        void BindWithKeyCode(ushort id, KeyCode keyCode, KeyCodeStatus keyCodeStatus);
        void UnbindWithKeyCode(ushort id, KeyCode keyCode);
        void Unbind(ushort id);
        void UnbindAll();

    }

}