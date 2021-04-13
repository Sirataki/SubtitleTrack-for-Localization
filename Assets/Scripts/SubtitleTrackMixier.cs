using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.Playables;
using UnityEngine.ResourceManagement.AsyncOperations;

using TMPro;

public class SubtitleTrackMixier : PlayableBehaviour
{
	public LocalizedStringTable table;

	protected AsyncOperationHandle<StringTable> m_LoadingHadle;

	public override void OnBehaviourPlay(Playable playable, FrameData info) {
		m_LoadingHadle = UnityEngine.Localization.Settings.LocalizationSettings.StringDatabase.GetTableAsync(table.TableReference);
	}

	public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
		TextMeshProUGUI text = playerData as TextMeshProUGUI;
		string currentText = "";

		if (text == false) { return; }

		int inputCount = playable.GetInputCount();
		for (int i = 0; i < inputCount; ++i) {
			float weight = playable.GetInputWeight(i);

			if (weight > 0f) {
				ScriptPlayable<SubtitleBehaviour> inputPlayable = (ScriptPlayable<SubtitleBehaviour>)playable.GetInput(i);
				SubtitleBehaviour input = inputPlayable.GetBehaviour();

#if UNITY_EDITOR
				if (UnityEditor.EditorApplication.isPlaying && m_LoadingHadle.IsValid() && m_LoadingHadle.IsDone) {
					currentText = m_LoadingHadle.Result.GetEntry(input.key).LocalizedValue;
				}
				else {
					currentText = input.key;
				}
#else
				if (m_LoadingHadle.IsValid() && m_LoadingHadle.IsDone) {
					currentText = m_LoadingHadle.Result.GetEntry(input.key).LocalizedValue;
				}
#endif
			}
		}

		text.text = currentText;
	}
}