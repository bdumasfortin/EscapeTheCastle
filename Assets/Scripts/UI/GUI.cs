using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

    void Update()
    {
        if (Input.GetButtonDown(InputUtils.BUTTON_CANCEL))
            ToggleGameMenu();
    }

    private void ToggleGameMenu()
    {
        _gameMenu.SetActive(!_gameMenu.activeSelf);
    }
}
