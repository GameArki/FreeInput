using UnityEngine;
using FreeInput.Facades;

namespace FreeInput.API.Getter {

    public class FreeInputGetter : IFreeInputGetter {

        FreeInputCore core;

        FreeInputFacades facades;

        public FreeInputGetter() { }

        public void Inject(FreeInputFacades facades) {
            this.facades = facades;
        }

        bool IFreeInputGetter.GetEvent(ushort eventID) {
            var dic = facades.eventDic;
            var e = dic.Keys.GetEnumerator();
            while (e.MoveNext()) {
                var key = e.Current;
                var evID = (ushort)(key >> 16);
                if (evID == eventID) {
                    var keyCodeModel = dic[key];
                    if (keyCodeModel.isTrue) {
                        return true;
                    }
                }
            }

            return false;
        }

    }

}