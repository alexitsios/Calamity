using System;
using UnityEngine.UI;

namespace UnityEngine.InputSystem.Samples.RebindUI
{
    /// <summary>
    /// Hooks into <see cref="RebindActionUI.updateBindingUIEvent"/> which is triggered when UI display
    /// of a binding should be refreshed. It then checks whether we have an icon for the current binding
    /// and if so, replaces the default text display with an icon.
    /// </summary>
    public class KeyboardIconsDisplay : MonoBehaviour
    {
        [SerializeField] private RebindActionUI[] actionRebinds;

        public MouseIcons mouse;
        public KeyboardIcons keyboard;

        protected void OnEnable()
        {
            // Hook into all updateBindingUIEvents on all RebindActionUI components in our hierarchy.
            foreach (var component in actionRebinds)
            {
                component.updateBindingUIEvent.AddListener(OnUpdateBindingDisplay);
                component.UpdateBindingDisplay();
            }
        }

        protected void OnUpdateBindingDisplay(RebindActionUI component, string bindingDisplayString, string deviceLayoutName, string controlPath)
        {
            if (string.IsNullOrEmpty(deviceLayoutName) || string.IsNullOrEmpty(controlPath))
                return;

            var icon = default(Sprite);
            if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Keyboard"))
                icon = keyboard.GetSprite(controlPath);
            else if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Mouse"))
                icon = mouse.GetSprite(controlPath);

            var textComponent = component.bindingText;
            var imageComponent = component.bindingImage;

            if (icon != null)
            {
                textComponent.gameObject.SetActive(false);
                imageComponent.sprite = icon;
                imageComponent.gameObject.SetActive(true);
            }
            else
            {
                textComponent.gameObject.SetActive(true);
                imageComponent.gameObject.SetActive(false);
            }
        }

        [Serializable]
        public struct MouseIcons
        {
            public Sprite rightMouse;
            public Sprite leftMouse;
            public Sprite middleMouse;

            public Sprite GetSprite(string controlPath)
            {
                // From the input system, we get the path of the control on device. So we can just
                // map from that to the sprites we have for gamepads.
                switch (controlPath)
                {
                    case "leftButton": return leftMouse;
                    case "rightButton": return rightMouse;
                    case "middleButton": return middleMouse;
                }
                return null;
            }
        }

        [Serializable]
        public struct KeyboardIcons
        {
            public Sprite[] a_z;
            public Sprite[] numbers;

            [Space]

            public Sprite escape;
            public Sprite space;
            public Sprite tab;
            public Sprite shift;
            public Sprite control;
            public Sprite capsLock;

            public Sprite GetSprite(string controlPath)
            {
                // From the input system, we get the path of the control on device. So we can just
                // map from that to the sprites we have for gamepads.
                switch (controlPath)
                {
                    case "a": return a_z[0];
                    case "b": return a_z[1];
                    case "c": return a_z[2];
                    case "d": return a_z[3];
                    case "e": return a_z[4];
                    case "f": return a_z[5];
                    case "g": return a_z[6];
                    case "h": return a_z[7];
                    case "i": return a_z[8];
                    case "j": return a_z[9];
                    case "k": return a_z[10];
                    case "l": return a_z[11];
                    case "m": return a_z[12];
                    case "n": return a_z[13];
                    case "o": return a_z[14];
                    case "p": return a_z[15];
                    case "q": return a_z[16];
                    case "r": return a_z[17];
                    case "s": return a_z[18];
                    case "t": return a_z[19];
                    case "u": return a_z[20];
                    case "v": return a_z[21];
                    case "w": return a_z[22];
                    case "x": return a_z[23];
                    case "y": return a_z[24];
                    case "z": return a_z[25];

                    case "0": return numbers[0];
                    case "1": return numbers[1];
                    case "2": return numbers[2];
                    case "3": return numbers[3];
                    case "4": return numbers[4];
                    case "5": return numbers[5];
                    case "6": return numbers[6];
                    case "7": return numbers[7];
                    case "8": return numbers[8];
                    case "9": return numbers[9];

                    case "escape": return escape;
                    case "space": return space;
                    case "tab": return tab;
                    case "shift": return shift;
                    case "control": return control;
                    case "capsLock": return capsLock;
                }
                return null;
            }
        }
    }
}

