using UnityEngine;

[CreateAssetMenu(fileName = "Resource Data", menuName = "Game Data/Resource", order = 1)]
public class ResourceData : ScriptableObject
{
    // future: internationalization
    public string resourceName = string.Empty;
    public Sprite icon;
}
