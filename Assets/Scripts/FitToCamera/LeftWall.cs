using UnityEngine;

public class LeftWall : MonoBehaviour
{
    void Start()
    {
        Camera camera = Camera.main;

        if (camera != null && camera.orthographic)
        {
            float cameraHalfHeight = camera.orthographicSize;
            float cameraHalfWidth = cameraHalfHeight * camera.aspect;

            transform.position = new Vector3(cameraHalfWidth, 0f, 0f);

            BoxCollider2D col = GetComponent<BoxCollider2D>();
            if (col != null)
            {
                float cameraHeight = cameraHalfHeight * 2;
                float colHeight = col.size.x;

                transform.localScale = new Vector3(1f, cameraHeight / colHeight, 1f);
            }
        }
    }


}
