using UnityEngine;

public class FormationSpawn : MonoBehaviour {
    private const float _Offset = 0.2f;

    void Start() {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));


        float heightOffset = CalculatePrefabYBounds() + _Offset;
        float bounds = screenBounds.y - heightOffset;
        Vector2 position = transform.position;

        if (position.y + heightOffset > bounds) {
            Debug.Log(transform.position);
            position.y -= heightOffset;
            Debug.Log(position);
        } else if (position.y - heightOffset < -bounds) {
            Debug.Log(transform.position);
            position.y += heightOffset;
            Debug.Log(position);
        }

        transform.position = position;
    }

    private float CalculatePrefabYBounds() {
        SpriteRenderer[] sr = GetComponentsInChildren<SpriteRenderer>();
        if(sr.Length == 0) return 0;

        Bounds bounds = sr[0].bounds;
        foreach (SpriteRenderer sr2 in sr) {
            bounds.Encapsulate(sr2.bounds);
        }

        return bounds.size.y / 2;
    }
}
