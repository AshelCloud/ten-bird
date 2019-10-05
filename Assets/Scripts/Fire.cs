using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public List<MeshFilter> animations;
    public int index = 0;
    public float animationRate = 0.2f;
    public bool playAwake = true;
    public bool loop = true;

    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();

        if(playAwake)
        {
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation()
    {
        do
        {
            index ++;
            if(index >= animations.Count) { index = 0; }
            meshFilter.mesh = animations[index].sharedMesh;
            yield return new WaitForSeconds(animationRate);
        }
        while(loop);

        yield return null;
    }
}
