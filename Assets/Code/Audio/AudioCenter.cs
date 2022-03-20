using System;
using UnityEngine;

namespace Code
{
    public class AudioCenter : MonoBehaviour
    {
        [SerializeField] private AudioDB audioDB;  
        [Header("Audio Players")]
        [SerializeField] private AudioPlayer sfxPlayer;
        [SerializeField] private AudioPlayer musicPlayer;
        [SerializeField] private AudioPlayer environmentPlayer;
        [SerializeField] private AudioPlayer catSounds;

        public static AudioCenter Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            catSounds.PlayClip(audioDB.GetClip(EAudioClips.CatPure));
        }

        public void PlaySound(EAudioClips clipName)
        {
            sfxPlayer.PlayClip(audioDB.GetClip(clipName));
        }
    }
}