// GENERATED AUTOMATICALLY FROM 'Assets/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""3a24c27f-9b41-4c89-b9f5-a7690835a036"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""c9e55bc2-e040-4166-895d-a936e485e250"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fdfa516c-86d6-44f9-9022-d8a4eaca9cb7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Use"",
            ""id"": ""1d3ab15f-4ea4-4015-8384-f08a2b3d6c39"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""1191448a-f80f-41b8-89c0-7bbd5873aed1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""01e747f7-ac7c-4dca-8307-5c4b0c0f9d90"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Newaction = m_Move.FindAction("New action", throwIfNotFound: true);
        // Use
        m_Use = asset.FindActionMap("Use", throwIfNotFound: true);
        m_Use_Newaction = m_Use.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
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

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Newaction;
    public struct MoveActions
    {
        private @Input m_Wrapper;
        public MoveActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Move_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);

    // Use
    private readonly InputActionMap m_Use;
    private IUseActions m_UseActionsCallbackInterface;
    private readonly InputAction m_Use_Newaction;
    public struct UseActions
    {
        private @Input m_Wrapper;
        public UseActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Use_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Use; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UseActions set) { return set.Get(); }
        public void SetCallbacks(IUseActions instance)
        {
            if (m_Wrapper.m_UseActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UseActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UseActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UseActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UseActions @Use => new UseActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IMoveActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IUseActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
