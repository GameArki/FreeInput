using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.API.Setter
{

    public interface IFreeInputSetter
    {

        void BindWithKeyCode(ushort id, KeyCode keyCode);
        void BindWithKeyCode(ushort id, KeyCode keyCode, KeyCodeStatus status);
        void UnbindWithKeyCode(ushort id, KeyCode keyCode);
        void Unbind(ushort id);
        void UnbindAll();
        void RebindWithKeyCode(ushort id, KeyCode oldKeyCode, KeyCode newKeyCode);

    }

}