using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Scrolling : MonoBehaviour
{

    public float speed;
    private float pos;
    // Update is called once per frame
    void Update()
    {
        pos =+ speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (pos, 0);
        
    }
}
