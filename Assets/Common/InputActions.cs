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
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""eebf2414-a5b3-4aa3-94cf-da5a299b04fc"",
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
                    ""path"": ""<Keyboard>/upArrow"",
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
                    ""path"": ""<Keyboard>/downArrow"",
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
                    ""path"": ""<Keyboard>/leftArrow"",
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
                    ""path"": ""<Keyboard>/rightArrow"",
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
                    ""path"": ""<Keyboard>/z"",
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
                    ""path"": ""<XInputController>/select"",
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
                    ""path"": ""<Gamepad>/rightShoulder"",
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
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Freeze"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9333e798-2d4b-4794-b018-b37831162633"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Freeze"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdfad1e0-4446-4d28-ba94-6656138419c3"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25656e98-b7fa-4faf-a798-31994a3154d9"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4f545af-3568-45cb-bcb7-47ca02f1c16b"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Restart"",
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
                    ""type"": ""Value"",
                    ""id"": ""568a9cb8-2386-4a55-85c9-90626c02cc4c"",
                    ""expectedControlType"": ""Vector2"",
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
                    ""type"": ""Value"",
                    ""id"": ""158c7864-f178-42cd-b447-fe89852723bd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""16f4504c-81c7-4862-9be6-b18f6b6a7f5a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""182d2c3c-5ced-4220-82f7-c933c0e26c31"",
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
                    ""id"": ""e0552265-af32-4f35-b307-3c01db972ac6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5a9ec73-36a4-4471-aa72-ab3d3af7537d"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e798bedc-4dd2-4ef5-a64a-0e5128b3c5c4"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cab5f4be-4cfc-4738-ab70-8862af78152b"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea87f1b3-a51e-4a34-8faa-1d6922dc7e4c"",
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
                    ""id"": ""146bab48-007b-4e7a-ae86-04ad260e38f9"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70f24bcf-5928-4ca9-9a11-406f2a19a036"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""430a55e0-ccb5-4a2b-a341-259af51143fc"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""f70e73d0-f456-4c6d-b3ae-bba7727a6bba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""76afe7bd-8d46-446d-9ddc-21f95707e302"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""9fa1af71-18ec-47cb-bd27-ca837d315004"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ce618e5c-50ff-4886-a0f5-b0fb7e82921d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a3f267e1-b2ec-41dd-a340-ddffa1c7d746"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0bf0b1f3-bfae-45c2-a4bf-a78b56a65deb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""Value"",
                    ""id"": ""8fddd774-656b-4c8e-8fc9-65d3829a6db3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Value"",
                    ""id"": ""88dbbaa5-6aca-4cd9-923d-5a4c45004a01"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ab58ec0-3be3-4c15-aba6-9ff03138c4e2"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c22bf5c1-7cbc-44ea-ac02-fb6407499103"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5c6eb456-d08e-4814-a218-053136be45a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Stick"",
                    ""id"": ""13d9302c-82da-484b-8196-83a721b0e941"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""58f6bd0a-fcca-4220-8501-b48445f5bbd1"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""066f979f-cfd9-4c68-bfed-d6b6431346ba"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""55769223-b5a9-4c78-9b7a-52fa5a155148"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5e2a67f5-87ec-4f5a-a37e-a5251cbee4aa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d1456116-2cab-4238-8bfa-9eb81c5fec0b"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""e651a862-de50-4122-b7ae-c1dd23decb0f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""77f1b04b-c9c0-4f56-8a70-37f54b749a56"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""00daf884-8c3b-4845-b7f6-0c2a99547920"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""08710822-bad2-40d7-ae46-8453ca14f679"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2c50adfc-63b1-400d-b50e-8cd6c54fbd85"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""15af4a25-6d50-486d-a0be-ec7b12906e34"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""683cd5c8-e221-4ea3-b92e-d0dbb6c78bc1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72fb6e53-e659-44b9-aa19-42c8d971dde9"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c98041d9-b5ee-47b5-92cc-94d38f51ae65"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Keyboard"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fc9999c-cbfa-4570-88e4-544383b08f44"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Keyboard"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6457e84-8d4d-4c22-aba1-9bf721b96672"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Keyboard"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""035ffbab-44e4-4f61-b65b-58c7f1ee722c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Keyboard"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""029fec30-d71d-4750-a97b-3f5c03e5575e"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88ace328-443d-490e-be4e-0d1b8aedd9ca"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c2fc9ec-105b-4c6a-b84b-462a3a2efd00"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""TrackedDeviceSelect"",
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
                },
                {
                    ""devicePath"": ""<Mouse>"",
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
        m_PatricioBossFight_Restart = m_PatricioBossFight.GetAction("Restart");
        // MittensBossFight
        m_MittensBossFight = asset.GetActionMap("MittensBossFight");
        m_MittensBossFight_Move = m_MittensBossFight.GetAction("Move");
        m_MittensBossFight_Shoot = m_MittensBossFight.GetAction("Shoot");
        m_MittensBossFight_Dash = m_MittensBossFight.GetAction("Dash");
        m_MittensBossFight_Reload = m_MittensBossFight.GetAction("Reload");
        m_MittensBossFight_SwitchWeapons = m_MittensBossFight.GetAction("SwitchWeapons");
        m_MittensBossFight_Aim = m_MittensBossFight.GetAction("Aim");
        m_MittensBossFight_Restart = m_MittensBossFight.GetAction("Restart");
        m_MittensBossFight_Start = m_MittensBossFight.GetAction("Start");
        // UI
        m_UI = asset.GetActionMap("UI");
        m_UI_Navigate = m_UI.GetAction("Navigate");
        m_UI_Submit = m_UI.GetAction("Submit");
        m_UI_Cancel = m_UI.GetAction("Cancel");
        m_UI_Point = m_UI.GetAction("Point");
        m_UI_Click = m_UI.GetAction("Click");
        m_UI_ScrollWheel = m_UI.GetAction("ScrollWheel");
        m_UI_MiddleClick = m_UI.GetAction("MiddleClick");
        m_UI_RightClick = m_UI.GetAction("RightClick");
        m_UI_TrackedDevicePosition = m_UI.GetAction("TrackedDevicePosition");
        m_UI_TrackedDeviceOrientation = m_UI.GetAction("TrackedDeviceOrientation");
        m_UI_TrackedDeviceSelect = m_UI.GetAction("TrackedDeviceSelect");
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
    private readonly InputAction m_PatricioBossFight_Restart;
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
        public InputAction @Restart => m_Wrapper.m_PatricioBossFight_Restart;
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
                Restart.started -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnRestart;
                Restart.performed -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnRestart;
                Restart.canceled -= m_Wrapper.m_PatricioBossFightActionsCallbackInterface.OnRestart;
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
                Restart.started += instance.OnRestart;
                Restart.performed += instance.OnRestart;
                Restart.canceled += instance.OnRestart;
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
    private readonly InputAction m_MittensBossFight_Restart;
    private readonly InputAction m_MittensBossFight_Start;
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
        public InputAction @Restart => m_Wrapper.m_MittensBossFight_Restart;
        public InputAction @Start => m_Wrapper.m_MittensBossFight_Start;
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
                Restart.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnRestart;
                Restart.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnRestart;
                Restart.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnRestart;
                Start.started -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnStart;
                Start.performed -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnStart;
                Start.canceled -= m_Wrapper.m_MittensBossFightActionsCallbackInterface.OnStart;
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
                Restart.started += instance.OnRestart;
                Restart.performed += instance.OnRestart;
                Restart.canceled += instance.OnRestart;
                Start.started += instance.OnStart;
                Start.performed += instance.OnStart;
                Start.canceled += instance.OnStart;
            }
        }
    }
    public MittensBossFightActions @MittensBossFight => new MittensBossFightActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    private readonly InputAction m_UI_TrackedDeviceSelect;
    public struct UIActions
    {
        private InputActions m_Wrapper;
        public UIActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputAction @TrackedDeviceSelect => m_Wrapper.m_UI_TrackedDeviceSelect;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                Navigate.started += instance.OnNavigate;
                Navigate.performed += instance.OnNavigate;
                Navigate.canceled += instance.OnNavigate;
                Submit.started += instance.OnSubmit;
                Submit.performed += instance.OnSubmit;
                Submit.canceled += instance.OnSubmit;
                Cancel.started += instance.OnCancel;
                Cancel.performed += instance.OnCancel;
                Cancel.canceled += instance.OnCancel;
                Point.started += instance.OnPoint;
                Point.performed += instance.OnPoint;
                Point.canceled += instance.OnPoint;
                Click.started += instance.OnClick;
                Click.performed += instance.OnClick;
                Click.canceled += instance.OnClick;
                ScrollWheel.started += instance.OnScrollWheel;
                ScrollWheel.performed += instance.OnScrollWheel;
                ScrollWheel.canceled += instance.OnScrollWheel;
                MiddleClick.started += instance.OnMiddleClick;
                MiddleClick.performed += instance.OnMiddleClick;
                MiddleClick.canceled += instance.OnMiddleClick;
                RightClick.started += instance.OnRightClick;
                RightClick.performed += instance.OnRightClick;
                RightClick.canceled += instance.OnRightClick;
                TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled += instance.OnTrackedDeviceSelect;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnRestart(InputAction.CallbackContext context);
    }
    public interface IMittensBossFightActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitchWeapons(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnTrackedDeviceSelect(InputAction.CallbackContext context);
    }
}
