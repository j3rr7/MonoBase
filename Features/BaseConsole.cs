using System.Collections;
using System.Collections.Generic;
using MonoBase.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBase.Features
{
    public class BaseConsole : MonoBehaviour, IWindow
    {
        public int Id { get; private set; }
        public Rect Rect { get; set; }
        public string Title => "Console";
        public bool IsVisible { get; private set; }

        private const int MAX_CONSOLE_LINES = 50;
        private Queue<string> _consoleLog = new Queue<string>();
        private string _inputText = "";
        private Vector2 _scrollPosition;

        public void Awake()
        {
            Id = WindowIdGenerator.GenerateId();
            Rect = new Rect(100, 100, 400, 300);
        }

        public void Start()
        {
            HotkeyManager.RegisterHotkey(WindowInput.DeleteKey, () =>
            {
                ToggleVisibility();
            });
        }

        public void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }

        public void OnGUI()
        {
            if (IsVisible)
            {
                Rect = GUI.Window(Id, Rect, Draw, Title);
            }
        }

        public void Draw(int id)
        {
            GUILayout.BeginVertical();
            {
                // Console Log Display
                _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
                GUILayout.TextArea(string.Join("\n", _consoleLog.ToArray()), GUILayout.ExpandHeight(true));
                GUILayout.EndScrollView();

                // Input Field and Button
                GUILayout.BeginHorizontal();
                {
                    _inputText = GUILayout.TextField(_inputText);
                    if (GUILayout.Button("Send", GUILayout.Width(80)))
                    {
                        HandleInput(_inputText);
                        _inputText = ""; // Clear input field
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();

            GUI.DragWindow();
        }

        public void LogMessage(string message)
        {
            _consoleLog.Enqueue(message);
            if (_consoleLog.Count > MAX_CONSOLE_LINES)
            {
                _consoleLog.Dequeue();
            }
        }

        private void HandleInput(string input)
        {
            LogMessage("> " + input); // Display the command in the console

            switch (input)
            {
                case "clear":
                    _consoleLog.Clear();
                    break;
                default:
                    LogMessage("Command not recognized: " + input);
                    break;
            }
        }
    }
}
