using UnityEngine;

namespace FreeInput.API.Getter {

    public interface IFreeInputGetter {

        bool GetDown(ushort bindID);
        bool GetPressing(ushort bindID);
        bool GetUp(ushort bindID);
        KeyCode GetCurrentDownKeyCode();
        KeyCode GetCurrentPressingKeyCode();
        KeyCode GetCurrentUpKeyCode();

    }

}