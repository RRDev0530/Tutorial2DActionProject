using UnityEngine;

public class ParrallaxBackgrounds : MonoBehaviour
{
    [SerializeField]private ParrallaxLayer[] backGroundLayers;

    private Camera maincamera;
    private Vector2 lastPosition;

    private void Awake()
    {
        maincamera = Camera.main;
        lastPosition = maincamera.transform.position;
        CalculatteImageLength();

    }


    private void Update()
    {
        float currentCameraLeftEdgeX = maincamera.transform.position.x - maincamera.orthographicSize * maincamera.aspect;
        float currentCameraRightEdgeX = maincamera.transform.position.x + maincamera.orthographicSize * maincamera.aspect;

        Vector2 deltaMovement = (Vector2)maincamera.transform.position - lastPosition;
        foreach (ParrallaxLayer layer in backGroundLayers)
        {
            layer.MoveLayer(deltaMovement);
            layer.LoopBackground(currentCameraLeftEdgeX , currentCameraRightEdgeX);
        }
        lastPosition = maincamera.transform.position;
    }

    private void CalculatteImageLength()
    {
        foreach (ParrallaxLayer layer in backGroundLayers)
        {
            layer.CalculateImageWidth();
        }
    }
}
