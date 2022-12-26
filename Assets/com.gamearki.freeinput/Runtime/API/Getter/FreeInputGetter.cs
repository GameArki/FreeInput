using FreeInput.Facades;

namespace FreeInput.API.Getter {

    public class FreeInputGetter : IFreeInputGetter {

        FreeInputCore core;

        FreeInputFacades facades;

        public FreeInputGetter() { }

        public void Inject(FreeInputFacades facades) {
            this.facades = facades;
        }

        bool IFreeInputGetter.GetDown(ushort bindID) {
            var domain = facades.MainDomain;
            return domain.GetDown(bindID);
        }

        bool IFreeInputGetter.GetPressing(ushort bindID) {
            var domain = facades.MainDomain;
            return domain.GetPressing(bindID);
        }

        bool IFreeInputGetter.GetUp(ushort bindID) {
            var domain = facades.MainDomain;
            return domain.GetUp(bindID);
        }

    }

}