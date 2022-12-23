
using System.Collections.Generic;
using FreeInput.Domain;
using FreeInput.Generic;

namespace FreeInput.Facades
{

    public class FreeInputFacades
    {

        //     eventID          |        keycode       
        //  0000 0000 0000 0000 | 0000 0000 0000 0000  
        public Dictionary<uint, KeyCodeModel> eventDic;

        public MainDomain MainDomain { get; private set; }

        public FreeInputFacades()
        {
            eventDic = new Dictionary<uint, KeyCodeModel>();
            MainDomain = new MainDomain();
            MainDomain.Inject(this);
        }

        public void Inject() { }

    }

}