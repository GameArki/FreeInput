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

        void IFreeInputSetter.BindWithKeyCode(ushort id, KeyCode keyCode, KeyCodeStatus keyCodeStatus)
        {
            var domain = facades.MainDomain;
            domain.BindWithKeyCode(id, keyCode, keyCodeStatus);
        }

        void IFreeInputSetter.UnbindWithKeyCode(ushort id, KeyCode keyCode)
        {
            var domain = facades.MainDomain;
            domain.UnbindWithKeyCode(id, keyCode);
        }

        void IFreeInputSetter.Unbind(ushort id)
        {
            var domain = facades.MainDomain;
            domain.Unbind(id);
        }

        void IFreeInputSetter.UnbindAll()
        {
            var domain = facades.MainDomain;
            domain.UnbindAll();
        }
    }

}