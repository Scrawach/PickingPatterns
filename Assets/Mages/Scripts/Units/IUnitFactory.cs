using UnityEngine;

namespace Mages.Units
{
    public interface IUnitFactory
    {
        IMage CreateMage(Vector3 position);
        IPaladin CreatePaladin(Vector3 position);
    }
}