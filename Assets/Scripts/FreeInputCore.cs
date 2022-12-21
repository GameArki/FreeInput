using FreeInput.API.Setter;
using FreeInput.API.Getter;
using FreeInput.Facades;

namespace FreeInput {

    public class FreeInputCore {

        FreeInputFacades facades;

        FreeInputSetter setter;
        public IFreeInputSetter ISetter => setter;

        FreeInputGetter getter;
        public IFreeInputGetter IGetter => getter;

        public FreeInputCore() {
            facades = new FreeInputFacades();
            setter=new FreeInputSetter();
            getter=new FreeInputGetter();
            setter.Inject(facades);
            getter.Inject(facades);
        }

    }

}