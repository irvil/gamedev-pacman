using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    public AudioSource source; // Will be self

    public AudioClip introClip;
    // Clips to loop
    public AudioClip ghostNormalClip;

    // Start is called before the first frame update
    void Start()
    {
        source.loop = true;
        StartCoroutine(playStartingAudio());
    }

    // Update is called once per frame
    IEnumerator playStartingAudio()
    {
        source.clip = introClip;
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.clip = ghostNormalClip;
        source.Play();
    }
}
