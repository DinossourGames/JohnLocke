// GENERATED AUTOMATICALLY FROM 'Assets/Common/InputActions.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection
{
    private InputActionAsset asset;
    public InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PatricioBossFight"",
            ""id"": ""9450f14f-03f0-4f98-902f-29e84bd5cdad"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1c8549c5-fc20-4ecb-bad5-6b1f7c9f9d8b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""685a804a-1502-4e90-b994-d2d2b7f6f2e4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""11628f49-de06-41d6-9738-415dc06ffd4b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""f6217697-20fe-445f-a62b-c01912ee0026"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Invulnerability"",
                    ""type"": ""Button"",
                    ""id"": ""07ae1451-257e-4afe-ba32-8352315e2362"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stare"",
                    ""type"": ""Button"",
                    ""id"": ""4c4106a7-6767-4564-8152-eb82b2f339dd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""78fb56c4-081c-4b9f-9805-0e7a2f03538d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Freeze"",
                    ""type"": ""Button"",
                    ""id"": ""fef95e2a-b084-4ba7-aacd-7815b82f14ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""35888a4c-21e8-4143-a3a7-baefc5ae46a0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3bd3e9d-2f7e-495f-8e43-1f57549e48a7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0a0ff9c0-0c19-47df-b44e-00ef7edb8520"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7b7f5f57-88cb-40ff-a55b-c060f8a03fe3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a88b309d-c9e3-4fe8-a052-df954e04717f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4ed455d5-241e-44ae-b56d-384b965b3d57"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd9bf6a2-858b-4062-909d-7d176acaa167"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dccbe4c-4a40-4674-b641-37c0ea6462de"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""643f530c-71d6-43a9-af15-c8862e43af95"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5c9f8f0-063c-41fc-b327-096e455f81a3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73a5e856-88bd-4ff8-bca6-947e55cd961a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9c7c233-1cde-4e77-a874-07982c20c1e6"",
                    ""path"": ""<DualShockGamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8eb2db9-779d-43d3-b9de-2d64d16c5dd3"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c65882e5-aeb8-442d-97f5-c1b37fb39b83"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32cb899b-63ee-4ca8-8cb7-af152dcdbfa8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Invulnerability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd4ff64f-85b2-48d7-b683-1e81eb4b5715"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Invulnerability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dee71e9-6695-45dd-8945-22738d5f0f07"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Stare"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcb39f95-0894-43a7-8f36-c27ab33065bf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Stare"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a166a00-c7fd-4447-9e36-f5dbbe12bd19"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01cc6ddb-b165-4cb5-94f9-fdc8821c64cf"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87fd7dd9-b6ce-4b9c-847a-bbbaa80521d4"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Freeze"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e89cd98-4737-4cea-bdc3-9083d64320d3"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Freeze"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MittensBossFight"",
            ""id"": ""de5c8eb9-cadf-448e-884d-2c482889df24"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""568a9cb8-2386-4a55-85c9-90626c02cc4c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c814f345-8e36-49a8-8ac8-0675b9be5205"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""9341c749-1299-4518-ab1c-d83c16fdf8ec"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""d959c598-c5cb-47b4-8d72-c12553e3e220"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapons"",
                    ""type"": ""Button"",
                    ""id"": ""c3e8ae2f-43ee-496f-8a79-55f3367cce4c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""158c7864-f178-42cd-b447-fe89852723bd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8798c4a7-c4d1-41ec-82a6-3a054563aad3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e9641610-2de2-4ce9-950f-87ecb84991fe"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""15b3c6ea-dd10-418a-b4a2-12bb316d305e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""702595e5-afb3-4b4c-abf1-8419b9536cf3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c46a7cd0-fcb4-4179-ab5a-5088445d0c4e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e0d814b-381b-4e85-b8dd-0f6e5306c69f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a71b290-1dee-4101-b190-8c9573dd8262"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cf10501-5281-428b-a450-088b5eb2f4c8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbd1524c-d72c-46c3-9075-aec4b1aa4752"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a97435c0-2436-4d20-8b3d-ef278a2ad67f"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1915e22-3754-4aa1-bb47-f8cc8ec53647"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b8a3917-0cfd-470d-bb69-e3b0b75ae4c8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94afe6d0-4751-47bf-a38a-e8fadf0316de"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""SwitchWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0089886c-b39c-4560-808c-e8b4fcd724a3"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5d5e214-83d6-40eb-a9ea-7b9d166a8361"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0552265-af32-4f35-b307-3c01db972ac6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""basedOn"": """",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""basedOn"": """",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PatricioBossFight
        m_PatricioBossFight = asset.GetActionMap("PatricioBossFight");
        m_PatricioBossFight_Move = m_PatricioBossFight.GetAction("Move");
        m_PatricioBossFight_Jump = m_PatricioBossFight.GetAction("Jump");
        m_PatricioBossFight_Shoot = m_PatricioBossFight.GetAction("Shoot");
        m_PatricioBossFight_Start = m_PatricioBossFight.GetAction("Start");
        m_PatricioBossFight_Invulnerability = m_PatricioBossFight.GetAction("Invulnerability");
        m_PatricioBossFight_Stare = m_PatricioBossFight.GetAction("Stare");
        m_PatricioBossFight_Special = m_PatricioBossFight.GetAction("Special");
        m_PatricioBossFight_Freeze = m_PatricioBossFight.GetAction("Freeze");
        // MittensBossFight
        m_MittensBossFight = asset.GetActionMap("MittensBossFight");
        m_MittensBossFight_Move = m_MittensBossFight.GetAction("Move");
        m_MittensBossFight_Shoot = m_MittensBossFight.GetAction("Shoot");
        m_MittensBossFight_Dash = m_MittensBossFight.GetAction("Dash");
        m_MittensBossFight_Reload = m_MittensBossFight.GetAction("Reload");
        m_MittensBossFight_SwitchWeapons = m_MittensBossFight.GetAction("SwitchWeapons");
        m_MittensBossFight_Aim = m_MittensBossFight.GetAction("Aim");
    }

    ~InputActions()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PatricioBossFight
    private readonly InputActionMap m_PatricioBossFight;
    private IPatricioBossFightActions m_PatricioBossFightActionsCallbackInterface;
    private readonly InputAction m_PatricioBossFight_Move;
    private readonly InputAction m_PatricioBossFight_Jump;
    private readonly InputAction m_PatricioBossFight_Shoot;
    private readonly InputAction m_PatricioBossFight_Start;
    private readonly InputAction m_PatricioBossFight_Invulnerability;
    private readonly InputAction m_PatricioBossFight_Stare;
    private readonly InputAction m_PatricioBossFight_Special;
    private readonly InputAction m_PatricioBossFight_Freeze;
    public struct PatricioBossFightActions
    {
        private InputActions m_Wrapper;
        public PatricioBossFightActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PatricioBossFight_Move;
        public InputAction @Jump => m_Wrapper.m_PatricioBossFight_Jump;
        public InputAction @Shoot => m_Wrapper.m_PatricioBossFight_Shoot;
        public InputAction @Start => m_Wrapper.m_PatricioBossFight_Start;
        public InputAction @Invulnerability => m_Wrapper.m_PatricioBossFight_Invulnerability;
        public InputAction @Stare => m_Wrapper.m_PatricioBossFight_Stare;
        public InputAction @Special => m_Wrapper.m_PatricioBossFight_Special;
        public InputAction @Freeze => m_Wrapper.m_PatricioBossFight_Freeze;
        public InputActionMap Get() { return m_Wrapper.m_PatricioBossFight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PatricioBossFightActions set) { return set.Get(); }
        public void SetCallbacks(IPatricioBossFightActions instance)
        {
            if (m_Wrapper.m_PatricioBossFightActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnMove;
                Jump.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnJump;
                Shoot.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnShoot;
                Start.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnStart;
                Start.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnStart;
                Start.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnStart;
                Invulnerability.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnInvulnerability;
                Invulnerability.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnInvulnerability;
                Invulnerability.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnInvulnerability;
                Stare.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnStare;
                Stare.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnStare;
                Stare.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnStare;
                Special.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnSpecial;
                Special.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnSpecial;
                Special.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnSpecial;
                Freeze.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnFreeze;
                Freeze.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnFreeze;
                Freeze.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnFreeze;
            }
            m_Wrapper.m_PatricioBossFightActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                Start.started += instance.OnStart;
                Start.performed += instance.OnStart;
                Start.canceled += instance.OnStart;
                Invulnerability.started += instance.OnInvulnerability;
                Invulnerability.performed += instance.OnInvulnerability;
                Invulnerability.canceled += instance.OnInvulnerability;
                Stare.started += instance.OnStare;
                Stare.performed += instance.OnStare;
                Stare.canceled += instance.OnStare;
                Special.started += instance.OnSpecial;
                Special.performed += instance.OnSpecial;
                Special.canceled += instance.OnSpecial;
                Freeze.started += instance.OnFreeze;
                Freeze.performed += instance.OnFreeze;
                Freeze.canceled += instance.OnFreeze;
            }
        }
    }
    public PatricioBossFightActions @PatricioBossFight => new PatricioBossFightActions(this);

    // MittensBossFight
    private readonly InputActionMap m_MittensBossFight;
    private IMittensBossFightActions m_MittensBossFightActionsCallbackInterface;
    private readonly InputAction m_MittensBossFight_Move;
    private readonly InputAction m_MittensBossFight_Shoot;
    private readonly InputAction m_MittensBossFight_Dash;
    private readonly InputAction m_MittensBossFight_Reload;
    private readonly InputAction m_MittensBossFight_SwitchWeapons;
    private readonly InputAction m_MittensBossFight_Aim;
    public struct MittensBossFightActions
    {
        private InputActions m_Wrapper;
        public MittensBossFightActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MittensBossFight_Move;
        public InputAction @Shoot => m_Wrapper.m_MittensBossFight_Shoot;
        public InputAction @Dash => m_Wrapper.m_MittensBossFight_Dash;
        public InputAction @Reload => m_Wrapper.m_MittensBossFight_Reload;
        public InputAction @SwitchWeapons => m_Wrapper.m_MittensBossFight_SwitchWeapons;
        public InputAction @Aim => m_Wrapper.m_MittensBossFight_Aim;
        public InputActionMap Get() { return m_Wrapper.m_MittensBossFight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MittensBossFightActions set) { return set.Get(); }
        public void SetCallbacks(IMittensBossFightActions instance)
        {
            if (m_Wrapper.m_MittensBossFightActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnMove;
                Shoot.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnShoot;
                Shoot.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnShoot;
                Shoot.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnShoot;
                Dash.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnDash;
                Dash.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnDash;
                Dash.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnDash;
                Reload.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnReload;
                Reload.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnReload;
                Reload.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnReload;
                SwitchWeapons.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnSwitchWeapons;
                SwitchWeapons.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnSwitchWeapons;
                SwitchWeapons.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnSwitchWeapons;
                Aim.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnAim;
                Aim.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnAim;
                Aim.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_MittensBossFightActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Shoot.started += instance.OnShoot;
                Shoot.performed += instance.OnShoot;
                Shoot.canceled += instance.OnShoot;
                Dash.started += instance.OnDash;
                Dash.performed += instance.OnDash;
                Dash.canceled += instance.OnDash;
                Reload.started += instance.OnReload;
                Reload.performed += instance.OnReload;
                Reload.canceled += instance.OnReload;
                SwitchWeapons.started += instance.OnSwitchWeapons;
                SwitchWeapons.performed += instance.OnSwitchWeapons;
                SwitchWeapons.canceled += instance.OnSwitchWeapons;
                Aim.started += instance.OnAim;
                Aim.performed += instance.OnAim;
                Aim.canceled += instance.OnAim;
            }
        }
    }
    public MittensBossFightActions @MittensBossFight => new MittensBossFightActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.GetControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.GetControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPatricioBossFightActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnInvulnerability(InputAction.CallbackContext context);
        void OnStare(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
        void OnFreeze(InputAction.CallbackContext context);
    }
    public interface IMittensBossFightActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitchWeapons(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
}
