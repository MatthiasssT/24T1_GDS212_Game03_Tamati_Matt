using UnityEngine;

public class FanFX : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100f; // Rotation speed for the fan

    [SerializeField]
    private GameObject lightingObject; // Reference to the lighting object

    //private bool isLightOn = true; // Flag to track the state of the light

    private void Start()
    {
        // Rotate the fan object on the z-axis based on the specified rotation speed
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // Ensure the light is initially turned on
        if (lightingObject != null)
        {
            Light lightComponent = lightingObject.GetComponent<Light>();
            if (lightComponent != null)
            {
                lightComponent.enabled = true;
            }
            else
            {
                Debug.LogWarning("Lighting object does not contain a Light component.");
            }
        }
        else
        {
            Debug.LogWarning("Lighting object is not assigned.");
        }

        // Start flickering the light every 3 minutes and 33 seconds
        InvokeRepeating("ToggleLight", 213f, 213f); // Start after 3 minutes and 33 seconds, then repeat every 3 minutes and 33 seconds
    }

    private void Update()
    {
        // Rotate the fan object on the z-axis based on the specified rotation speed
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void ToggleLight()
    {
        // Check if the lighting object is assigned
        if (lightingObject != null)
        {
            // Toggle the light component on and off for the flickering effect
            Light lightComponent = lightingObject.GetComponent<Light>();
            if (lightComponent != null)
            {
                // Toggle the state of the light
                lightComponent.enabled = !lightComponent.enabled;
            }
            else
            {
                Debug.LogWarning("Lighting object does not contain a Light component.");
            }
        }
        else
        {
            Debug.LogWarning("Lighting object is not assigned.");
        }
    }
}
