
namespace FreeInput.Generic
{

    public enum KeyCodeStatus : byte
    {

        Down = 0b00000001,
        Pressing = 0b00000010,
        Up = 0b00000100,
        DownAndPressing = Down | Pressing,
        DownAndUp = Down | Up,
        PressingAndUp = Pressing | Up,
        All = Down | Pressing | Up,

    }

    public static class KeyCodeStatusExtensions
    {

        public static bool Contains(this KeyCodeStatus status1, KeyCodeStatus status2)
        {
            return (status1 & status2) == status2;
        }

    }

}