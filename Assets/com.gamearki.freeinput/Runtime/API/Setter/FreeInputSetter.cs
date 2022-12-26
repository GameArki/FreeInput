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

        void IFreeInputSetter.BindKeyCode(ushort bindID, KeyCode keyCode)
        {
            var domain = facades.MainDomain;
            domain.BindKeyCode(bindID, keyCode);
        }

        void IFreeInputSetter.BindStatus(ushort bindID, KeyCodeStatus status)
        {
            var domain = facades.MainDomain;
            domain.BindStatus(bindID, status);
        }

        void IFreeInputSetter.Unbind(ushort bindID, KeyCode keyCode)
        {
            var domain = facades.MainDomain;
            domain.Unbind(bindID, keyCode);
        }

        void IFreeInputSetter.UnbindAll()
        {
            var domain = facades.MainDomain;
            domain.UnbindAll();
        }

        void IFreeInputSetter.RebindKeyCode(ushort bindID, KeyCode oldKeyCode, KeyCode newKeyCode)
        {
            var domain = facades.MainDomain;
            domain.RebindKeyCode(bindID, oldKeyCode, newKeyCode);
        }

        void IFreeInputSetter.RebindStatus(ushort bindID, KeyCodeStatus status)
        {
            throw new System.NotImplementedException();
        }
    }

}