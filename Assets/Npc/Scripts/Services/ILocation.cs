using UnityEngine;

namespace Npc.Services
{
    public interface ILocation
    {
        Vector3 NearestWorkingPlace(Vector3 fromPosition);
        Vector3 NearestRestingPlace(Vector3 fromPosition);
    }
}