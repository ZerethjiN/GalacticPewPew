using AlizeeEngine;

class AnimationSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Animation anim, Texture tex) => {
            if (!anim.Lock) {
                anim.CurrentTime += Time.deltaTime;

                if (anim.CurrentTime > anim.TimeByFrame) {

                    switch (anim.Type) {
                        case AnimationType.Modulaire: Modulaire(anim, tex); break;
                        case AnimationType.Oscillaire: Oscillaire(anim, tex); break;
                    }

                    anim.CurrentTime = 0;
                }
            }
        });

    }

    private void Modulaire(Animation anim, Texture tex) {
        if (anim.CurrentFrame < anim.NbFrame) {
            tex.X += anim.NextFramePosition;
            anim.CurrentFrame++;
        } else {
            tex.X -= anim.NextFramePosition * anim.NbFrame;
            anim.CurrentFrame = 0;
        }
    }

    private void Oscillaire(Animation anim, Texture tex) {
        if (anim.IsRight) {
            if (anim.CurrentFrame < anim.NbFrame) {
                tex.X += anim.NextFramePosition;
                anim.CurrentFrame++;
            } else {
                anim.CurrentFrame--;
                anim.IsRight = false;
            }
        } else {
            if (anim.CurrentFrame >= 0) {
                tex.X -= anim.NextFramePosition;
                anim.CurrentFrame--;
            } else {
                anim.CurrentFrame++;
                anim.IsRight = true;
            }
        }
    }

}