using UnityEngine;

namespace RogueLike.CharacterEffects
{
    public abstract class TimedEffect
    {
        protected float timeDuration;
        protected int stacks;
        protected bool isActive;
        protected bool isFinished;
        public bool IsActive => isActive;
        public bool IsFinished => isFinished;

        public CharacterEffectSO characterEffectSO;
        protected readonly GameObject parentObject;

        public TimedEffect(CharacterEffectSO characterEffectSO, GameObject parentObject)
        {
            this.characterEffectSO = characterEffectSO;
            this.parentObject = parentObject;
        }

        public void TickEffect(float time)
        {
            timeDuration -= time;

            if (timeDuration <= 0)
            {
                EndCharacterEffect();

                isFinished = true;
            }
        }

        public void Activate()
        {
            if (characterEffectSO.IsStackable || timeDuration <= 0)
            {
                ApplyCharacterEffect();
                stacks++;
            }
            
            if (characterEffectSO.IsStackableDuration || timeDuration <= 0)
            {
                timeDuration += characterEffectSO.TimeDuration;
            }
        }

        protected abstract void ApplyCharacterEffect();
        public abstract void EndCharacterEffect();
    }
}