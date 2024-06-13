using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBase.Core
{
    public static class WindowIdGenerator
    {
        private static int nextId;
        public static int GenerateId() => nextId++;
    }

    public interface IWindow
    {
        int Id { get; }
        Rect Rect { get; }
        string Title { get; }
        bool IsVisible { get; }
        void Draw(int id);
        void ToggleVisibility();
    }

    public static class WindowInput
    {
        public static InputAction DeleteKey { get; private set; }

        static WindowInput()
        {
            DeleteKey = new InputAction("DeleteKey");
            DeleteKey.AddBinding("<Keyboard>/delete");
            DeleteKey.Enable();
        }
    }

    public static class HotkeyManager
    {
        private static readonly Dictionary<KeyCode, System.Action> LegacyHotkeys = new Dictionary<KeyCode, System.Action>();
        private static readonly Dictionary<InputAction, System.Action> InputActionCallbacks = new Dictionary<InputAction, System.Action>();

        public static void RegisterHotkey(KeyCode keyCode, System.Action action)
        {
            LegacyHotkeys[keyCode] = action;
        }

        public static void UnregisterHotkey(KeyCode keyCode)
        {
            LegacyHotkeys.Remove(keyCode);
        }

        public static void RegisterHotkey(InputAction action, System.Action callback)
        {
            InputActionCallbacks[action] = callback;
            action.Enable();
        }

        public static void UnregisterHotkey(InputAction action)
        {
            InputActionCallbacks.Remove(action);
            action.Disable();
        }

        public static void ProcessHotkeys()
        {
            foreach (var kvp in InputActionCallbacks)
            {
                if (kvp.Key.triggered)
                {
                    kvp.Value?.Invoke();
                }
            }

            foreach (var kvp in LegacyHotkeys)
            {
                if (Input.GetKey(kvp.Key))
                {
                    kvp.Value?.Invoke();
                }
            }
        }
    }
}