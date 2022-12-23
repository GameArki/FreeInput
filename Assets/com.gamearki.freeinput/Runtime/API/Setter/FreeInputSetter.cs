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

        void IFreeInputSetter.BindWithKeyCode(ushort bindID, KeyCode keyCode)
        {
            var domain = facades.MainDomain;
            domain.BindWithKeyCode(bindID, keyCode);
        }

        void IFreeInputSetter.BindWithKeyCode(ushort bindID, KeyCode keyCode, KeyCodeStatus status)
        {
            var domain = facades.MainDomain;
            domain.BindWithKeyCode(bindID, keyCode, status);
        }

        void IFreeInputSetter.UnbindWithKeyCode(ushort bindID, KeyCode keyCode)
        {
            var domain = facades.MainDomain;
            domain.UnbindWithKeyCode(bindID, keyCode);
        }

        void IFreeInputSetter.Unbind(ushort bindID)
        {
            var domain = facades.MainDomain;
            domain.Unbind(bindID);
        }

        void IFreeInputSetter.UnbindAll()
        {
            var domain = facades.MainDomain;
            domain.UnbindAll();
        }

        void IFreeInputSetter.RebindWithKeyCode(ushort bindID, KeyCode oldKeyCode, KeyCode newKeyCode)
        {
            var domain = facades.MainDomain;
            domain.RebindWithKeyCode(bindID, oldKeyCode, newKeyCode);
        }
    }

}