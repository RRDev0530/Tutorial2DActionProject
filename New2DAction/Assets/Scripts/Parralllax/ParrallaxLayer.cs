using System;
using UnityEngine;

[System.Serializable]
public class ParrallaxLayer
{
    [SerializeField]private Transform layer;
    [SerializeField]private float ParallaxFactor;
    [SerializeField]private float LoopBackgroudoffset;
    public float fullWidth { get; private set; }
    public float HalfLayerWidgth { get; private set; }

    public void CalculateImageWidth()
    {
        fullWidth = layer.GetComponent<SpriteRenderer>().bounds.size.x;
        HalfLayerWidgth = fullWidth / 2f;
    }

    public void MoveLayer(Vector2 deltaMovement)
    {
       layer.position += (Vector3)(deltaMovement * ParallaxFactor);
    }

    public void LoopBackground(float cameraLeftEdge , float cameraRightEdge)
    {
        float backGroundLeftEdge = layer.position.x - HalfLayerWidgth;
        float backGroundRightEdge = layer.position.x + HalfLayerWidgth;

        if (backGroundLeftEdge + LoopBackgroudoffset > cameraRightEdge)
        {
            layer.position += Vector3.left * fullWidth;
        }
        
        else if (backGroundRightEdge - LoopBackgroudoffset < cameraLeftEdge)
            layer.position += Vector3.right * fullWidth;

    }


}
