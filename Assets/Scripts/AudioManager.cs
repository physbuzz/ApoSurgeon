using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Dictionary<ToolType, AudioClip> AudioToolTable;
    public  AudioClip[] AudioClips;
    AudioSource audioSource;

    public AudioClip PainAudioLong;
    public AudioClip PainAudioShort;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onToolAppliedOnFace += OnToolAppliedOnFace;
        GameManager.instance.onPainLevelChanged += OnPainLevelChanged;
        audioSource = GetComponent<AudioSource>();
    }

    void OnToolAppliedOnFace(ToolType toolType, FacePart FacePart)
    {
        if (AudioClips.Length < (int)ToolType.None)
        {
            return;
        }

        audioSource.PlayOneShot(AudioClips[(int)toolType]);

    }

    void OnPainLevelChanged(float value)
    {
        //if (GameManager.instance.humor.Blood <= 0.5f)
        //{
        //    audioSource.Play();
        //}
        //else
        {
            audioSource.PlayOneShot(PainAudioShort);
        }

    }
}
