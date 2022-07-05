using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor (typeof(SoundController))]
public class SoundControllerEditor : Editor
{
    private List<AudioClip> _clips;

    [System.Obsolete]
    public override void OnInspectorGUI()
    {
        var mySoundController = (SoundController)target;
        _clips = mySoundController._clips;
        EditorGUILayout.BeginVertical();
        if(_clips.Count==0)
        {
            for(var i=0; i<=SoundController.SOUND_COUNT; i++)
            {
                _clips.Add(null);
            }
        }
        for (var i = 0; i <= SoundController.SOUND_COUNT; i++)
        {
            EditorGUILayout.BeginHorizontal();
            _clips[i] = EditorGUILayout.ObjectField(((AudioSounds)i).ToString(), _clips[i], typeof(AudioClip)) as AudioClip;
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
        EditorUtility.SetDirty(mySoundController);
        //DrawDefaultInspector();
    }
}
