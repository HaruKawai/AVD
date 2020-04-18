using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineControl : MonoBehaviour
{
    public List<PlayableDirector> playableDirectors;
    public PlayableDirector playableDriectorChest;
    public TimelineAsset timelineChest;
    public List<TimelineAsset> timelines;


    public void Play()
    {
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            playableDirector.Play();
        }
    }

    public void PlayChest()
    {
        playableDriectorChest.Play();
    }

    public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedAsset;

        if (timelines.Count <= index)
        {
            selectedAsset = timelines[timelines.Count - 1];
        }
        else
        {
            selectedAsset = timelines[index];
        }

        playableDirectors[0].Play(selectedAsset);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("disco trigger tag: "+ other.tag);
        /*
        if (other.CompareTag("Disco"))
        {
            GetComponent<Animator>().SetTrigger("dance");
            GetComponent<TimelineControl>().Play();
            other.GetComponentInParent<Animator>().SetTrigger("action");// in this case the animator is in the parent
        }
        else if (other.CompareTag("Flag"))
        {
            other.GetComponent<Animator>().SetBool("active", false);
        }
        else 
        */if (other.CompareTag("Chest"))
        {
            GetComponent<Animator>().SetTrigger("takeItem");
            other.GetComponent<Animator>().SetTrigger("Open");
            GetComponent<TimelineControl>().PlayChest();
            other.GetComponent<ParticleSystem>().Play();
        }
    }

}
