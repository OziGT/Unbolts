using UnityEngine;
using System.Collections;

public class OffsettAndTilingOutput : MonoBehaviour
{

    public Vector2 tiling, offset;
    Renderer renderer;
	void Start ()
    {
        renderer = GetComponent<Renderer>();
	}
	
	
	void Update ()
    {
        renderer.material.mainTextureOffset = offset;
        renderer.material.mainTextureScale = tiling;
	}
}
