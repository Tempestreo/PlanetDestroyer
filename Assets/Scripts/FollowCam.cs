using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] float parallax = 2f;
    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = transform.position.y /transform.localScale.x / parallax;
        offset.y = transform.position.x / transform.localScale.y / parallax;
        mat.mainTextureOffset = offset;
    }
}
