using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DeviceBasedUI : MonoBehaviour
{
    UnityEngine.InputSystem.PlayerInput _controls;
    public InputDevice currentInputDevice;
    public enum InputDevice { Keyboard_Mouse, Gamepad }



    public TMP_Text promptToModify;

    public TMP_SpriteAsset keyboardIcons;
    public TMP_SpriteAsset gamepadIcons;

    //Define Enum
	

  



  



    // Start is called before the first frame update
    void Start()
    {
        _controls = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        _controls.onControlsChanged += OnControlsChanged;

        promptToModify.spriteAsset = keyboardIcons;
        promptToModify.SetText("Press <sprite name=\"Keyboard_a\"> to Interact.");

    }

    private void OnControlsChanged(UnityEngine.InputSystem.PlayerInput obj)
    {
        if (obj.currentControlScheme == "Gamepad")
        {
            if (currentInputDevice != InputDevice.Gamepad)
            {
                currentInputDevice = InputDevice.Gamepad;
                

                promptToModify.spriteAsset = gamepadIcons;
                promptToModify.SetText("Press <sprite name=\"Gamepad_south\"> to Interact.");

                // Send Event
                // EventHandler.ExecuteEvent("DeviceChanged", currentControlDevice);
            }
        }
        else
        {
            if (currentInputDevice != InputDevice.Keyboard_Mouse)
            {
                currentInputDevice = InputDevice.Keyboard_Mouse;

                promptToModify.spriteAsset = keyboardIcons;
                promptToModify.SetText("Press <sprite name=\"Keyboard_a\"> to Interact.");

                // Send Event
                // EventHandler.ExecuteEvent("DeviceChanged", currentControlDevice);
            }
        }
    }    
}
