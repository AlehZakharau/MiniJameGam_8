﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.UI
{
    public interface IMediator
    {
        public void Notify(EContext ev);
    }
    public class NavigationUIMediator : MonoBehaviour
    {
        [SerializeField] private Window mainWindow;
        [SerializeField] private Window pauseWindow;
        [SerializeField] private Window creditsWindow;
        [SerializeField] private Window settingsWindow;
        [SerializeField] private Window tutorialWindow;

        private Window previousWindow;
        private Window currentWindow;

        private bool isPause;

        private void Start()
        {
            currentWindow = mainWindow;
        }

        public void Notify(EContext ev)
        {
            switch (ev)
            {
                case EContext.NewGame:
                    SceneManager.LoadScene(sceneBuildIndex: 1);
                    break;
                case EContext.Continue:
                    currentWindow.CloseWindow();
                    OpenWindow(mainWindow);
                    isPause = false;
                    PlayerInput.Instance.Actions.Payer.Enable();
                    break;
                case EContext.Pause:
                    if (!isPause)
                    {
                        OpenWindow(pauseWindow);
                        isPause = true;
                        PlayerInput.Instance.Actions.Payer.Disable();
                    }
                    else
                    {
                        OpenWindow(mainWindow);
                        isPause = false;
                        PlayerInput.Instance.Actions.Payer.Enable();
                    }

                    break;
                case EContext.Setting:
                    OpenWindow(settingsWindow);
                    break;
                case EContext.Credits:
                    OpenWindow(creditsWindow);
                    break;
                case EContext.Back:
                    OpenWindow(previousWindow);
                    break;
                case EContext.Tutorial:
                    OpenWindow(tutorialWindow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ev), ev, null);
            }
        }
        
        private void OpenWindow(Window window)
        {
            currentWindow.CloseWindow();
            previousWindow = currentWindow;
            window.OpenWindow();
            currentWindow = window;
        }
    }

    public enum EContext
    {
        NewGame,
        Continue,
        Pause,
        Setting,
        Back,
        Credits,
        Tutorial
    }
}