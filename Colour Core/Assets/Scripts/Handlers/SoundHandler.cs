using ColourCore.Serializables;
using UnityEngine;
using System.Collections.Generic;
namespace ColourCore
{
    namespace Handlers
    {
        public class SoundHandler : MonoBehaviour
        {
            #region Singleton
            public static SoundHandler singleton;
            private void Awake()
            {
                if (singleton == null)
                {
                    singleton = this;
                }
            }
            #endregion
            public List<Sound> soundEffects = new List<Sound>();
            private AudioSource source;
            private void Start()
            {
                source = GetComponent<AudioSource>();
            }
            public Sound GetSoundEffect(string _name)
            {
                Sound _sound = null;
                for (int i = 0; i < soundEffects.Count; i++)
                {
                    if (soundEffects[i].soundName == _name)
                    {
                        _sound = soundEffects[i];
                    }
                }
                return _sound;
            }
            public void PlaySound(string _name)
            {
                source.PlayOneShot(GetSoundEffect(_name).clip);
            }
        }
    }
}
