using UnityEngine;

public class VinylRecord : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public AudioClip AudioClip => audioClip;
}