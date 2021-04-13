using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using TMPro;

public class SubtitleBehaviour : PlayableBehaviour
{
	public string key;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
		TextMeshProUGUI text = playerData as TextMeshProUGUI;

		text.text = key;
	}
}