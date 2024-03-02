using UnityEngine;

public class AspectRatioEnforcer : MonoBehaviour
{
    public float targetAspect = 9f / 19.5f; // Set your desired aspect ratio.

    void Start()
    {
        AdjustAspectRatio();
    }

    void AdjustAspectRatio()
    {
        // Determine the game window's current aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;
        // Calculate the scale height that would make the window aspect match the target aspect
        float scaleHeight = windowAspect / targetAspect;
        // Get the camera component
        Camera camera = GetComponent<Camera>();

        // If the calculated scale height is less than 1, the screen is too wide and must be adjusted
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else // If the screen is too tall, it needs to be adjusted as well
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}
