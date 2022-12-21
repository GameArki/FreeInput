
using System.Collections.Generic;
using FreeInput.Generic;

namespace FreeInput.Facades {

    public class FreeInputFacades {

        //     eventID          |        keycode       
        //  0000 0000 0000 0000 | 0000 0000 0000 0000  
        public Dictionary<uint, KeyCodeModel> eventDic;

        public FreeInputFacades() {
            eventDic = new Dictionary<uint, KeyCodeModel>();
        }

        public void Inject() { }

    }

}