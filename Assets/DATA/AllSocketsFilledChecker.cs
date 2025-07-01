using UnityEngine;

using System.Collections.Generic;

public class AllSocketsFilledChecker : MonoBehaviour
{
    [SerializeField] private List<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor> sockets;
    [SerializeField] private ParticleSystem particleEffect;
    private bool hasPlayedEffect = false;

    void Update()
    {
        if (!hasPlayedEffect && AllSocketsAreFilled())
        {
            particleEffect.Play();
            hasPlayedEffect = true;
        }
    }

    private bool AllSocketsAreFilled()
    {
        foreach (UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket in sockets)
        {
            if (!socket.hasSelection)  // Checks if something is inserted
                return false;
        }
        return true;
    }
}
