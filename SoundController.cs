using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    /// <summary>
    /// This Sound Controller is made to control the assigned AudioSource
    /// to Fade-in or Fade-out. 
    /// This script can be modified later on for further improvements to provide
    /// a detailed control over the audio source.
    /// </summary>

    [Header("AUDIO SOURCE CONTROL")]
    [Tooltip("Assign the audio source you want to control")]
    [SerializeField] AudioSource audioSource;

    [Header("ASSIGN THE VALUES")]
    [Tooltip("Set the minimum volume value")]
    [SerializeField] float minVolume;
    [Tooltip("Set the maximum volume value")]
    [SerializeField] float maxVolume;
    [Tooltip("How long it should take to reeach either value")]
    [SerializeField] float duration;
    [Tooltip("How long it should wait before starting the fade")]
    [SerializeField] float waitingPeriod;
    [Tooltip("Should it wait before the fade effects start?")]
    [SerializeField] bool shouldWait;


    #region Public Fade-In/Fade-Out Methods
    public void FadeInVolume() //Responsible for fading the audio in
    {
        audioSource.volume = minVolume;
        StartCoroutine(FadeInCo());
    }
    public void FadeOutVolume() //Responsible for fading the audio out
    {
        StartCoroutine(FadeInCo());
    }
    #endregion


    #region Fade-In/Fade-Out Coroutines
    private IEnumerator FadeInCo()
    {
        if (shouldWait)
        {
            yield return new WaitForSeconds(waitingPeriod);
        }

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(minVolume, maxVolume, elapsedTime/duration);
            yield return null;
        }
        audioSource.volume = maxVolume;
    }

    private IEnumerator FadeOutCo()
    {
        if (shouldWait)
        {
            yield return new WaitForSeconds(waitingPeriod);
        }

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(maxVolume, minVolume, elapsedTime / duration);
            yield return null;
        }
        audioSource.volume = minVolume;
    }
    #endregion
}
