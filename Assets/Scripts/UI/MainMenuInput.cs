using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   

public class MainMenuInput : MonoBehaviour
{
    [Header("MainMenu")]
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private string GameScene;

    private InputAction _pointAction;
    private InputAction _clickAction;

    private Button[] buttons;
    private int _selectedButtonIndex = 0;

    private void Awake()
    {
        var _menuAction = inputActions.FindActionMap("UI");
        _pointAction = _menuAction.FindAction("Point");
        _clickAction = _menuAction.FindAction("Click");

        buttons = new Button[] { _startButton, _exitButton };

        _pointAction.performed += OnPoint;
        _clickAction.performed += OnClick;
    }
    private void OnEnable()
    {
        _pointAction.Enable();
        _clickAction.Enable();
    }
    private void OnDisable()
    {
        _pointAction.Disable();
        _clickAction.Disable();
    }
    private void OnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();

        PointerEventData _pointerEventData = new PointerEventData(EventSystem.current)
        {position = mousePosition};

        var _raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(_pointerEventData, _raycastResults);

        if (_raycastResults.Count > 0)
        {
            GameObject _hoveredObject = _raycastResults[0].gameObject;
            Button _hoveredButton = _hoveredObject.GetComponent<Button>();

            if(_hoveredButton != null)
            {
                _hoveredButton.Select();
                _selectedButtonIndex = System.Array.IndexOf(buttons, _hoveredButton);
            }
        }
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = _pointAction.ReadValue<Vector2>();

        PointerEventData _pointerEventData = new PointerEventData(EventSystem.current)
        {position = mousePosition};

        var _raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(_pointerEventData,_raycastResults);

        if (_raycastResults.Count > 0)
        {
            GameObject _clicedObject = _raycastResults[0].gameObject;
            Button _clickedButton = _clicedObject.GetComponent<Button>();

            if (_clickedButton != null)
            {
                _clickedButton.onClick.Invoke();
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
