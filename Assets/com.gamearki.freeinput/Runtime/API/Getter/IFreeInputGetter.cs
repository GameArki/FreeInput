using UnityEngine;

namespace FreeInput.API.Getter {

    public interface IFreeInputGetter {

        bool GetEvent(ushort eventID);

        bool GetEvent(ushort eventID, KeyCode keyCode);

    }

}