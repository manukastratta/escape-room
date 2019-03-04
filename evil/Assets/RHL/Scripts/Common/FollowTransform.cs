using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField]
    private Transform toFollow;

    [SerializeField]
    private bool followPosition = true;

    [SerializeField]
    private bool followRotation = true;

    [SerializeField]
    private bool followScale = false;

    [SerializeField]
    private Vector3 positionOffset = Vector3.zero;

    public void SetFollowTransform(Transform follow)
    {
        toFollow = follow;
    }

    // Update is called once per frame
    void Update()
    {
        if (toFollow != null)
        {
            if (followPosition)
                transform.position = toFollow.position + positionOffset;
            if (followRotation)
                transform.rotation = toFollow.rotation;
            if (followScale)
                transform.localScale = toFollow.localScale;
        }
    }
}
