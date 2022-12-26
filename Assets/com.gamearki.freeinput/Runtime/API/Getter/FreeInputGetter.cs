using FreeInput.Facades;

namespace FreeInput.API.Getter
{

    public class FreeInputGetter : IFreeInputGetter
    {

        FreeInputCore core;

        FreeInputFacades facades;

        public FreeInputGetter() { }

        public void Inject(FreeInputFacades facades)
        {
            this.facades = facades;
        }

        bool IFreeInputGetter.IsTriggered(ushort bindID)
        {
            var domain = facades.MainDomain;
            return domain.IsTriggered(bindID);
        }

    }

}