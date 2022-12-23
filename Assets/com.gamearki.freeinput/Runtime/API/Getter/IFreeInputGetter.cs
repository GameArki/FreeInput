using UnityEngine;

namespace FreeInput.API.Getter {

    public interface IFreeInputGetter {

        bool GetEvent(ushort eventID);

    }

}