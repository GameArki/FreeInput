
using System.Collections.Generic;
using UnityEngine;
using FreeInput.Domain;
using FreeInput.Generic;

namespace FreeInput.Facades
{

    public class FreeInputFacades
    {

        public Dictionary<ushort, KeyCodeStatus> bindStatusDic;
        public Dictionary<ushort, List<KeyCode>> bindCodeDic;
        public Dictionary<ushort, bool> triggerDic;

        public MainDomain MainDomain { get; private set; }

        public FreeInputFacades()
        {
            bindStatusDic = new Dictionary<ushort, KeyCodeStatus>();
            bindCodeDic = new Dictionary<ushort, List<KeyCode>>();
            triggerDic = new Dictionary<ushort, bool>();
            MainDomain = new MainDomain();
            MainDomain.Inject(this);
        }

    }

}