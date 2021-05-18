using UnityEngine;
using UnityEngine.EventSystems;

public class InputUtils
{
    public static string BUTTON_JUMP = "Jump";
    public static string BUTTON_SPRINT = "Sprint";
    public static string BUTTON_OPEN_GAMEMENU = "OpenGameMenu";
    public static string BUTTON_CANCEL = "Cancel";
    public static string BUTTON_HOLD_CAMERA = "HoldCamera";
    public static string BUTTON_HOLD_CAMERA2 = "HoldCamera2";

    public static bool GetButton(string buttonName)
    {
        return !EventSystem.current.IsPointerOverGameObject() && Input.GetButton(buttonName);
    }

    public static bool GetButtonDown(string buttonName)
    {
        return !EventSystem.current.IsPointerOverGameObject() && Input.GetButtonDown(buttonName);
    }
}
