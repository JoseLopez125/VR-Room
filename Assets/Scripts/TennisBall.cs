using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class TennisBall : MonoBehaviour
{
    [Tooltip("The audio clip to play when the ball bounces.")]
    [SerializeField] private AudioClip bounceClip;

    [Tooltip("Multiplier to scale the velocity into a 0 to 1 volume range.")]
    [SerializeField] private float volumeMultiplier = 0.1f;

    [Tooltip("The minimum speed required to play a bounce sound. Prevents sound spam when rolling or resting.")]
    [SerializeField] private float minSpeedThreshold = 0.5f;

    private AudioSource audioSource;
    private Rigidbody rb;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (bounceClip == null) return;

        float speed = rb.linearVelocity.magnitude;

        // Only play a sound if the ball is moving fast enough
        if (speed > minSpeedThreshold)
        {
            float volume = Mathf.Clamp01(speed * volumeMultiplier);
            audioSource.PlayOneShot(bounceClip, volume);
        }
    }
}