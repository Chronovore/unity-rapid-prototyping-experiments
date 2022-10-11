using Data.CelestialBodies;
using Time;
using UnityEngine;

public class CelestialBodyBehaviour : MonoBehaviour
{
    public CelestialBodyData data;
    public MeshRenderer geosphere;
    public MeshRenderer atmosphere;

    public void SetData(CelestialBodyData data)
    {
        this.data = data;
        geosphere.sharedMaterial = data.geosphere;
        geosphere.transform.localScale = new Vector3(data.geosphereScale, data.geosphereScale, data.geosphereScale);
        atmosphere.sharedMaterial = data.atmosphere;
        atmosphere.transform.localScale = new Vector3(data.atmosphereScale, data.atmosphereScale, data.atmosphereScale);
    }

    private void Update()
    {
        if (GameTimeBehaviour.Instance.isPaused) return;
        
        var rotationsPerSecond = data.rotationalPeriodInDays / (GameTimeBehaviour.Instance.dayDurationInSeconds * GameTimeBehaviour.Instance.gameTimeMultiplier);
        var rotationsPerFrame = rotationsPerSecond * UnityEngine.Time.deltaTime ;
        // future: rotate atmosphere separately.
        transform.Rotate(Vector3.up, rotationsPerFrame * 360);
    }
}