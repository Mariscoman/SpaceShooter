using UnityEngine;
using UnityEngine.InputSystem.HID;

public class GameManager : MonoBehaviour {

    private static GameManager _Instance;
    public static GameManager Instance {
        get {
            if (_Instance == null) {
                _Instance = FindFirstObjectByType<GameManager>();
                if (_Instance == null) {
                    instanciarGameManager();
                }
            }
            return _Instance;
        }
        private set => Instance = value;
    }

    private static void instanciarGameManager() {
        GameObject gameManager = new GameObject("GameManager (Auto-Created)");
        _Instance = gameManager.AddComponent<GameManager>();

        DontDestroyOnLoad(gameManager);
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
