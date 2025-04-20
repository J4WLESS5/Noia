using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBG : MonoBehaviour
{
    public float loopSpeed;
    public Renderer BgRenderer;
    // Update is called once per frame
    void Update()
    {
        BgRenderer.material.mainTextureOffset += new Vector2(0f, loopSpeed * Time.deltaTime);
    }
}
