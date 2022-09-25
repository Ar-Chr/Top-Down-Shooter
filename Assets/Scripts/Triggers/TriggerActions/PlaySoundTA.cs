using UnityEngine;

    public class PlaySoundTA : TriggerAction
    {
        [SerializeField] AudioSource source;
        [SerializeField] RandomClip[] sounds;

        public override void Execute()
        {
            sounds[Random.Range(0, sounds.Length)].Play(source);
        }
    }

