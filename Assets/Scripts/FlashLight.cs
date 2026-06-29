using Unity.Netcode;
using UnityEngine;

public class FlashLight : NetworkBehaviour
{
    public NetworkVariable<bool> isLightOn = new NetworkVariable<bool>(
        false,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner
    );

    [SerializeField] private GameObject light; 

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        isLightOn.OnValueChanged += OnLightChangeState;
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        isLightOn.OnValueChanged -= OnLightChangeState;
    }

    private void OnLightChangeState(bool previousValue, bool newValue)
    {
        light.SetActive(newValue);
    }

    public void TurnOnLight()
    {
        isLightOn.Value = true;
    }

    public void TurnOffLight()
    {
        isLightOn.Value = false;
    }

    public void ToggleLight()
    {
        isLightOn.Value = !isLightOn.Value;
    }
}
