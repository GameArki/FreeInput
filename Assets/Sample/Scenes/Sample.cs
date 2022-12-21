using UnityEngine;

namespace FreeInput.Test
{

    public class Sample : MonoBehaviour
    {

        FreeInputCore core;

        void Awake()
        {
            core = new FreeInputCore();
            core.AddEvent_KeyDown(0, KeyCode.Space, () =>
            {
                Debug.Log($"BindEvent 0  Down  Space ");
            });
            core.AddEvent_KeyStay(1, KeyCode.Space, () =>
            {
                Debug.Log($"BindEvent 1  Stay  Space ");
            });
            core.AddEvent_KeyUp(2, KeyCode.Space, () =>
            {
                Debug.Log($"BindEvent 2  Up  Space ");
            });
        }

        void Update()
        {
            core.InvokeEvent_KeyDown(0, KeyCode.Space);
            core.InvokeEvent_KeyStay(1, KeyCode.Space);
            core.InvokeEvent_KeyUp(2, KeyCode.Space);
        }

    }

}