using UnityEngine;

namespace FreeInput.API.Setter {

    public interface IFreeInputSetter {

        void TickEvent();
        void BindEvent_KeyDown(ushort eventID, KeyCode keyCode);
        void BindEvent_KeyPressing(ushort eventID, KeyCode keyCode);
        void BindEvent_KeyUp(ushort eventID, KeyCode keyCode);

    }

}