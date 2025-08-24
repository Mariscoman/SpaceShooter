using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour {
    [SerializeField] private UIDocument _document;
    private Button _button;

    private void Awake() {
        _button = _document.rootVisualElement.Q("StartButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnStartGameClick);
    }

    private void OnDisable() {
        _button.UnregisterCallback<ClickEvent>(OnStartGameClick);
    }

    private void OnStartGameClick(ClickEvent evt) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
