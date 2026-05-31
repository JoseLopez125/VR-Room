using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class RecordPlayer : MonoBehaviour
{
    [Tooltip("The socket where the record is placed.")] [SerializeField]
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;

    private AudioSource audioSource;

    [Tooltip("The ConstantRotation component that spins the platter/record.")] [SerializeField]
    private ConstantRotation recordSpinner;

private void Awake()
    {
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;

            if (recordSpinner != null)
            {
                recordSpinner.enabled = false;
            }
    }

    private void OnEnable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnRecordPlaced);
            socketInteractor.selectExited.AddListener(OnRecordRemoved);
        }
    }

    private void OnDisable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnRecordPlaced);
            socketInteractor.selectExited.RemoveListener(OnRecordRemoved);
        }
    }

    private void OnRecordPlaced(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.TryGetComponent(out VinylRecord record))
        {
            audioSource.clip = record.AudioClip;
            audioSource.Play();

            if (recordSpinner != null)
            {
                recordSpinner.enabled = true;
            }
        }
    }

    private void OnRecordRemoved(SelectExitEventArgs args)
    {
        audioSource.Stop();
        audioSource.clip = null;
        
        if (recordSpinner != null)
        {
            recordSpinner.enabled = false;
        }
    }
}