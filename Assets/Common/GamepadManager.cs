using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DS4_Wrapper;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;

public enum GamepadType
{
    Ps3,
    Ps4,
    Xbox,
    XOne,
    Generic,
    Disconnected
}

public sealed class GamepadManager
{
    private static GamepadManager _instancia;

    public static GamepadManager Instance
    {
        get
        {
            if (_instancia == null)
                _instancia = new GamepadManager();

            return _instancia;
        }
    }

    private static Gamepad _gamepad;
    private static GamepadType _gamepadType;

    private GamepadManager()
    {
        UpdateGamepad();
        Initialize();
    }

    private void Initialize()
    {
       Process.Start($"{Application.dataPath}/Resources/HIDHandler.exe");
    }

    public void UpdateGamepad()
    {
        _gamepad = Gamepad.current;

        if (_gamepad == null)
        {
            _gamepadType = GamepadType.Disconnected;
            return;
        }

        if (_gamepad.GetType() == typeof(DualShock4GamepadHID))
            _gamepadType = GamepadType.Ps4;
        else if (_gamepad.GetType() == typeof(DualShock3GamepadHID))
            _gamepadType = GamepadType.Ps3;
        else if (_gamepad.GetType() == typeof(XboxOneGamepad))
            _gamepadType = GamepadType.XOne;
        else if (_gamepad.GetType() == typeof(XInputController))
            _gamepadType = GamepadType.Xbox;
        else
            _gamepadType = GamepadType.Generic;
    }

    public static void SetLighbar(Color32 color)
    {
        if (_gamepadType != GamepadType.Ps4) return;
        if (Ds4Manager.Instancia.Ping())
            Ds4Manager.Instancia.SetLights(color);
        else
        {
            var controller  = _gamepad as DualShock4GamepadHID;
            controller?.SetLightBarColor(color);
        }
    }

    public static void SetRumble(byte left, byte right)
    {
        if (_gamepadType == GamepadType.Disconnected)
            return;

        if (_gamepadType != GamepadType.Ps4) return;
        if (Ds4Manager.Instancia.Ping())
            Ds4Manager.Instancia.SetRumble(left, 0, right, 0);
        else
        {
            var controller  = _gamepad as DualShock4GamepadHID;
            controller?.SetMotorSpeeds(right != 0 ? right/255 : 0,left != 0 ? left/255 : 0);
        }
    }

    public static void SetRumble(float left, float right, float leftTrigger = -1, float rightTrigger = -1)
    {
        if (_gamepadType == GamepadType.Disconnected)
            return;

        if (_gamepadType == GamepadType.Ps4)
        {
            if (Ds4Manager.Instancia.Ping())
                Ds4Manager.Instancia.SetRumble((byte) (int) Math.Ceiling(left * 255), 0,
                    (byte) (int) Math.Ceiling(right * 255), 0);
        }
        else if (_gamepadType == GamepadType.Generic)
            _gamepad.SetMotorSpeeds(left, right);
        else if (_gamepadType == GamepadType.Xbox)
        {
            var controller = _gamepad as XInputController;
            controller?.SetMotorSpeeds(left, right);
        }
        else if (_gamepadType == GamepadType.XOne)
        {
            var controller = _gamepad as XboxOneGamepad;
            if (leftTrigger != -1f && rightTrigger != -1f)
                controller?.SetMotorSpeeds(left, right, (float) leftTrigger, (float) rightTrigger);
            else
                controller?.SetMotorSpeeds(left, right);
        }
    }
}