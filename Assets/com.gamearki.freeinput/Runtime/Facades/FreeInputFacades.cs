
using System.Collections.Generic;
using UnityEngine;
using FreeInput.Domain;

namespace FreeInput.Facades
{

    public class FreeInputFacades
    {

        public Dictionary<ushort, List<KeyCode>> bindCodeDic;

        public MainDomain MainDomain { get; private set; }

        public FreeInputFacades()
        {
            bindCodeDic = new Dictionary<ushort, List<KeyCode>>();
            MainDomain = new MainDomain();
            MainDomain.Inject(this);
        }

    }

}