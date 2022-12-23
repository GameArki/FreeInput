
using System.Collections.Generic;
using FreeInput.Domain;
using FreeInput.Generic;

namespace FreeInput.Facades
{

    public class FreeInputFacades
    {

        //     bindID          |        keycode       
        //  0000 0000 0000 0000 | 0000 0000 0000 0000  
        public Dictionary<uint, KeyCodeModel> bindDic;

        public MainDomain MainDomain { get; private set; }

        public FreeInputFacades()
        {
            bindDic = new Dictionary<uint, KeyCodeModel>();
            MainDomain = new MainDomain();
            MainDomain.Inject(this);
        }

        public void Inject() { }

    }

}