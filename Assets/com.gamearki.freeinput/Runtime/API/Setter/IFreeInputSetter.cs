using FreeInput.Generic;
using UnityEngine;

namespace FreeInput.API.Setter
{

    public interface IFreeInputSetter
    {

        void BindStatus(ushort bindID, KeyCodeStatus status);
        void BindKeyCode(ushort bindID, KeyCode keyCode);

        void Unbind(ushort bindID, KeyCode keyCode);
        void UnbindAll();

        void RebindStatus(ushort bindID, KeyCodeStatus status);
        void RebindKeyCode(ushort bindID, KeyCode oldKeyCode, KeyCode newKeyCode);

    }

}