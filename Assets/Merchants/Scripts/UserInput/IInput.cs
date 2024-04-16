using UnityEngine;

namespace Merchants.UserInput
{
    public interface IInput
    {
        Vector3 MovementAxis { get; }
        bool InteractPressed();
    }
}