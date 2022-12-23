using UnityEngine;
using FreeInput.Facades;
using FreeInput.Generic;

namespace FreeInput.API.Setter
{

    public class FreeInputSetter : IFreeInputSetter
    {

        FreeInputFacades facades;

        public void Inject(FreeInputFacades facades)
        {
            this.facades = facades;
        }

        void IFreeInputSetter.TickInput()
        {
            var domain = facades.MainDomain;
            domain.TickInput();
        }

        void IFreeInputSetter.BindWithKeyCode(ushort eventID, KeyCode keyCode, KeyCodeStatus keyCodeStatus)
        {
            var domain = facades.MainDomain;
            domain.BindWithKeyCode(eventID, keyCode, keyCodeStatus);
        }

    }

}