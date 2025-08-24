using UnityEngine;

public class BackgroundScaler : MonoBehaviour {

    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private Camera mainCamera;

    void Start() {
        mainCamera = Camera.main;
        ScaleToScreenSize();
    }

    private void ScaleToScreenSize() {

        Bounds spriteBounds = spriteRenderer.bounds;
        float spriteWidth = spriteBounds.size.x;
        float spriteHeight = spriteBounds.size.y;

        float screenHeight = mainCamera.orthographicSize * 2f;
        float screenWidth = screenHeight * mainCamera.aspect;

        float scaleX = screenWidth / spriteWidth;
        float scaleY = screenHeight / spriteHeight;
        
        float uniformScale = Mathf.Min(scaleX, scaleY);

        transform.localScale = new Vector3(uniformScale, uniformScale, transform.localScale.z);
    }
}