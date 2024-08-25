using UnityEngine;

public class ResourceCollectible : MonoBehaviour
{
    public int resourceValue = 10; // Value of the resource to be collected

    public void Interact()
    {
        Debug.Log("Resource collected: " + resourceValue);
        PlayerResources.instance.AddResource(resourceValue);
        Destroy(gameObject);
    }
}
