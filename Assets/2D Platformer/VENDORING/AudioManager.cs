using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip jump;
    public AudioClip Spike;
    public AudioClip buttonPress;
    public AudioClip thud;
    public AudioClip LadderClimb;

    private void Start() 
    {
        Invoke(nameof(DelayBackground), 2f);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void DelayBackground() 
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
