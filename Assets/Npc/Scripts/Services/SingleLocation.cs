using UnityEngine;

namespace Npc.Services
{
    public class SingleLocation : ILocation
    {
        private readonly Vector3 _workingPlace;
        private readonly Vector3 _restingPlace;

        public SingleLocation(Vector3 workingPlace, Vector3 restingPlace)
        {
            _workingPlace = workingPlace;
            _restingPlace = restingPlace;
        }
        
        public Vector3 NearestWorkingPlace(Vector3 fromPosition) => 
            _workingPlace;

        public Vector3 NearestRestingPlace(Vector3 fromPosition) => 
            _restingPlace;
    }
}