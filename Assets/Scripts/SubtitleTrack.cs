using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Playables;
using UnityEngine.Timeline;

using TMPro;

[TrackBindingType(typeof(TextMeshProUGUI))]
[TrackClipType(typeof(SubtitleClip))]
public class SubtitleTrack : TrackAsset
{
	public LocalizedStringTable table;

	public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
		var playable = ScriptPlayable<SubtitleTrackMixier>.Create(graph, inputCount);
		playable.GetBehaviour().table = table;

		return playable;
	}
}