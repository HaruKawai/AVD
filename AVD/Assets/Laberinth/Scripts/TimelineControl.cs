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
}
