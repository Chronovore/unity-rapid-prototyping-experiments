using System.Linq;
using Data.GameResources;
using UnityEngine;

namespace Resources
{
    public class ResourceSystemBehaviour : MonoBehaviour
    {

        public GameObject resourceBarContainer;
        public ResourceDisplayElement resourceDisplayElementPrefab;

        public ResourceData[] resourceDataList;

        private void Start()
        {
            UpdateResources();
        }

        public void UpdateResources()
        {
            foreach (var child in resourceBarContainer.transform.Cast<Transform>().ToList())
            {
#if UNITY_EDITOR
                DestroyImmediate(child.gameObject);
#else
                Destroy(child.gameObject);
#endif
            }

            foreach (var resource in resourceDataList)
            {
                var newResourceItem = Instantiate(resourceDisplayElementPrefab, resourceBarContainer.transform);
                newResourceItem.transform.position = Vector3.zero;
                newResourceItem.GetComponent<ResourceDisplayElement>().SetData(resource);
            }
        }
    }
}
