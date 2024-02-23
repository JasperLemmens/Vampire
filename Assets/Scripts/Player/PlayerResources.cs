using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    [SerializeField] private float gatheringSpeed;
    [SerializeField] private float gatherIngRange = 1;

    private float gatherTimestamp;
    private List<ResourceNode> resourceNodesInRange = new();

    public int Stone;
    public int Wood;
    public int Iron;
    public int Bone;

    private void AddResource(Resources resource)
    {
        switch (resource)
        {
            case Resources.Iron:
                Iron++;
                break;
            case Resources.Wood:
                Wood++;
                break;
            case Resources.Stone:
                Stone++;
                break;
            case Resources.Bone:
                Bone++;
                break;
        }
    }

    private void Update()
    {
        GetResourceNodesInRange();

        if (CantGather())
            return;

        foreach(var resourceNode in resourceNodesInRange)
        {
            resourceNode.TryToGather();
            AddResource(resourceNode.Resource);
        }

        gatherTimestamp = Time.time;
    }

    private void GetResourceNodesInRange()
    {
        resourceNodesInRange.Clear();

        var resourceNodeCollidersInRanges = Physics2D.OverlapCircleAll(transform.position, gatherIngRange).Where(collider => collider.TryGetComponent(out ResourceNode resourceNode));

        foreach (var collider in resourceNodeCollidersInRanges)
            resourceNodesInRange.Add(collider.GetComponent<ResourceNode>());
    }

    private bool CantGather() => !resourceNodesInRange.Any() || Time.time < gatherTimestamp + gatheringSpeed;
}

public enum Resources
{
    Iron,
    Wood,
    Stone,
    Bone
}