using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    public RawImage image; 
    public float x; 
    public float y; 

    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(x,y)* Time.unscaledDeltaTime,image.uvRect.size); //unscaled para el pause
    }
}
