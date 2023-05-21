using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    private PlayableDirector playableDirector;

    public void Initialize(TimelineAsset timeline)
    {
        playableDirector = gameObject.AddComponent<PlayableDirector>();
        playableDirector.playableAsset = timeline;
        playableDirector.Play();
    }
}
