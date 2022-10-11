using System;
using System.Linq;
using Data.CelestialBodies;
using Resources;
using UnityEngine;

namespace CelestialBodies
{
    public class SolarSystemBehaviour : MonoBehaviour
    {
        // future: add proper solar system
        public CelestialBodyData planet;
        public Transform planetTarget;
        public CelestialBodyBehaviour celestialBodyPrefab;

        private void Start()
        {
            UpdateSolarSystem();
        }

        public void UpdateSolarSystem()
        {
            foreach (var child in planetTarget.transform.Cast<Transform>().ToList())
            {
#if UNITY_EDITOR
                DestroyImmediate(child.gameObject);
#else
                Destroy(child.gameObject);
#endif
            }
            
            var celestialBody = Instantiate(celestialBodyPrefab, planetTarget.transform);
            celestialBody.transform.localPosition = Vector3.zero;
            celestialBody.GetComponent<CelestialBodyBehaviour>().SetData(planet);
        }
    }
}