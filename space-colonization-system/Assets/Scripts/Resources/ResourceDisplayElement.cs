using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplayElement : MonoBehaviour
{
    public ResourceData data;
    public RawImage iconElement;

    public void SetData(ResourceData resource)
    {
        data = resource;
        iconElement.texture = resource.icon.texture;
    }
}
