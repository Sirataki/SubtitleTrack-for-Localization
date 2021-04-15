using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
	public LocalizedString entry;

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
		var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);

		SubtitleBehaviour subtitleBehaviour = playable.GetBehaviour();
		subtitleBehaviour.key = entry.TableEntryReference;

		return playable;
	}
}