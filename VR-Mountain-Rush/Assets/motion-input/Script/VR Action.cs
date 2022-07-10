// GENERATED AUTOMATICALLY FROM 'Assets/motion-input/Script/VR Action.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VRAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VRAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VR Action"",
    ""maps"": [
        {
            ""name"": ""hand"",
            ""id"": ""8496f290-1373-49c6-a573-e97dc37b1303"",
            ""actions"": [
                {
                    ""name"": ""gripLeft"",
                    ""type"": ""PassThrough"",
                    ""id"": ""558cd3df-d054-4a02-9bf1-120d4c540ed2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""gripRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""45a6471d-ef5f-4d11-a933-c1eeb9f145de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""veloLeft"",
                    ""type"": ""Value"",
                    ""id"": ""d58c432c-e481-4a7c-9661-6c377cedfea7"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""veloRight"",
                    ""type"": ""Value"",
                    ""id"": ""239824ad-c170-4ec6-bd3a-a665f682e340"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrigLeft"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5ef35065-1233-4c49-aca2-93ca75d2734a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrigRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""12ae077c-c16a-4c51-9cab-4743296087f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""81bfeefe-e94e-413c-9603-e086d1fc2232"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gripLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb830516-6cd7-41ad-b5d4-7c928e2e12b0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gripLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faaa7c6c-44bb-4ccf-9300-dcc497d83a7b"",
                    ""path"": ""<OculusTouchController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gripRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b3fe475-6321-415f-9a00-10cb6f0fb51f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gripRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d0101d7-cdb9-4338-bd06-e367c9f4aaf0"",
                    ""path"": ""<OculusTouchController>{LeftHand}/deviceVelocity"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""veloLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0748adc-7843-4eaa-9313-f8c89450160a"",
                    ""path"": ""<OculusTouchController>{RightHand}/deviceVelocity"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""veloRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d24c56dc-4b49-40fa-8886-918d903e2515"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrigLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44ad67bf-0e17-4565-807e-9510d37e1f2e"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrigRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // hand
        m_hand = asset.FindActionMap("hand", throwIfNotFound: true);
        m_hand_gripLeft = m_hand.FindAction("gripLeft", throwIfNotFound: true);
        m_hand_gripRight = m_hand.FindAction("gripRight", throwIfNotFound: true);
        m_hand_veloLeft = m_hand.FindAction("veloLeft", throwIfNotFound: true);
        m_hand_veloRight = m_hand.FindAction("veloRight", throwIfNotFound: true);
        m_hand_TrigLeft = m_hand.FindAction("TrigLeft", throwIfNotFound: true);
        m_hand_TrigRight = m_hand.FindAction("TrigRight", throwIfNotFound: true);
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

    // hand
    private readonly InputActionMap m_hand;
    private IHandActions m_HandActionsCallbackInterface;
    private readonly InputAction m_hand_gripLeft;
    private readonly InputAction m_hand_gripRight;
    private readonly InputAction m_hand_veloLeft;
    private readonly InputAction m_hand_veloRight;
    private readonly InputAction m_hand_TrigLeft;
    private readonly InputAction m_hand_TrigRight;
    public struct HandActions
    {
        private @VRAction m_Wrapper;
        public HandActions(@VRAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @gripLeft => m_Wrapper.m_hand_gripLeft;
        public InputAction @gripRight => m_Wrapper.m_hand_gripRight;
        public InputAction @veloLeft => m_Wrapper.m_hand_veloLeft;
        public InputAction @veloRight => m_Wrapper.m_hand_veloRight;
        public InputAction @TrigLeft => m_Wrapper.m_hand_TrigLeft;
        public InputAction @TrigRight => m_Wrapper.m_hand_TrigRight;
        public InputActionMap Get() { return m_Wrapper.m_hand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HandActions set) { return set.Get(); }
        public void SetCallbacks(IHandActions instance)
        {
            if (m_Wrapper.m_HandActionsCallbackInterface != null)
            {
                @gripLeft.started -= m_Wrapper.m_HandActionsCallbackInterface.OnGripLeft;
                @gripLeft.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnGripLeft;
                @gripLeft.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnGripLeft;
                @gripRight.started -= m_Wrapper.m_HandActionsCallbackInterface.OnGripRight;
                @gripRight.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnGripRight;
                @gripRight.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnGripRight;
                @veloLeft.started -= m_Wrapper.m_HandActionsCallbackInterface.OnVeloLeft;
                @veloLeft.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnVeloLeft;
                @veloLeft.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnVeloLeft;
                @veloRight.started -= m_Wrapper.m_HandActionsCallbackInterface.OnVeloRight;
                @veloRight.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnVeloRight;
                @veloRight.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnVeloRight;
                @TrigLeft.started -= m_Wrapper.m_HandActionsCallbackInterface.OnTrigLeft;
                @TrigLeft.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnTrigLeft;
                @TrigLeft.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnTrigLeft;
                @TrigRight.started -= m_Wrapper.m_HandActionsCallbackInterface.OnTrigRight;
                @TrigRight.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnTrigRight;
                @TrigRight.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnTrigRight;
            }
            m_Wrapper.m_HandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @gripLeft.started += instance.OnGripLeft;
                @gripLeft.performed += instance.OnGripLeft;
                @gripLeft.canceled += instance.OnGripLeft;
                @gripRight.started += instance.OnGripRight;
                @gripRight.performed += instance.OnGripRight;
                @gripRight.canceled += instance.OnGripRight;
                @veloLeft.started += instance.OnVeloLeft;
                @veloLeft.performed += instance.OnVeloLeft;
                @veloLeft.canceled += instance.OnVeloLeft;
                @veloRight.started += instance.OnVeloRight;
                @veloRight.performed += instance.OnVeloRight;
                @veloRight.canceled += instance.OnVeloRight;
                @TrigLeft.started += instance.OnTrigLeft;
                @TrigLeft.performed += instance.OnTrigLeft;
                @TrigLeft.canceled += instance.OnTrigLeft;
                @TrigRight.started += instance.OnTrigRight;
                @TrigRight.performed += instance.OnTrigRight;
                @TrigRight.canceled += instance.OnTrigRight;
            }
        }
    }
    public HandActions @hand => new HandActions(this);
    public interface IHandActions
    {
        void OnGripLeft(InputAction.CallbackContext context);
        void OnGripRight(InputAction.CallbackContext context);
        void OnVeloLeft(InputAction.CallbackContext context);
        void OnVeloRight(InputAction.CallbackContext context);
        void OnTrigLeft(InputAction.CallbackContext context);
        void OnTrigRight(InputAction.CallbackContext context);
    }
}
