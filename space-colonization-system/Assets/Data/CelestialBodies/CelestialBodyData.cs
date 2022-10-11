using System.Collections.Generic;
using Data.GameResources;
using UnityEngine;

namespace Data.CelestialBodies
{
    [CreateAssetMenu(fileName = "Celestial Body Data", menuName = "Game Data/Celestial Body", order = 2)]
    public class CelestialBodyData : ScriptableObject
    {
        // future: internationalization
        public string bodyName;
        public List<ResourceAbundance> resourceAbundances = new();
        public Material atmosphere;
        public float geosphereScale;
        public float atmosphereScale;
        public Material geosphere;
        public float rotationalPeriodInDays;
    }
}