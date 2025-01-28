using UnityEngine;

[ExecuteInEditMode]
public class CameraShakeEvent : MonoBehaviour
{
    public Material drunkMaterial; // Reference to the drunk shader material
    private bool isDrunkEffectActive = false; // Flag to check if effect is active

    // This function will be called from the Animation Event to start the drunk effect
    public void StartDrunkEffect()
    {
        isDrunkEffectActive = true; // Activate the drunk effect
    }

    // Apply the drunk effect in the OnRenderImage callback
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (isDrunkEffectActive && drunkMaterial != null)
        {
            // Apply the drunk material shader effect
            Graphics.Blit(source, destination, drunkMaterial);
        }
        else
        {
            // If the effect is not active, just pass through the image without modification
            Graphics.Blit(source, destination);
        }
    }
}
