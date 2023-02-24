using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour {
	public float scrollSpeed1 =1;
	public bool Invert;
	public Renderer rend;

    void FixedUpdate ()
    {
		if (Invert == false)
        {
			rend.material.mainTextureOffset = new Vector2 (Time.time * scrollSpeed1 * Time.deltaTime, 0f);
		} else
        {
			rend.material.mainTextureOffset = new Vector2 (0f,Time.time * scrollSpeed1 * Time.deltaTime);
		}
	}
}
