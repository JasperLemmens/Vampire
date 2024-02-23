using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    [SerializeField] private Resources resourceType;
    [SerializeField] private ParticleSystem feedback;

    public Resources Resource => resourceType;

    private int amountOfResourcesInNode;
    
    private void Start()
    {
        amountOfResourcesInNode = Random.Range(3, 5);
    }

    public void TryToGather()
    {
        amountOfResourcesInNode--;
        feedback.Play();

        if (amountOfResourcesInNode <= 0)
            Destroy(gameObject);
    }
}
