using FreeInput.Generic;

namespace FreeInput.API.Getter
{

    public interface IFreeInputGetter
    {

        bool IsTriggered(ushort bindID);

    }

}