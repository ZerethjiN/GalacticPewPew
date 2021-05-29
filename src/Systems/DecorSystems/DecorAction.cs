using AlizeeEngine;

class DecorAction: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Barriere bar, Texture tex, Collider col) => {
            bar.ActivationTimer += Time.deltaTime;

            if (bar.ActivationTimer > bar.ActivationCooldown) {
                if (tex.X == 0) {
                    tex.X = 16;
                    col.IsColliderOn = false;
                } else if (tex.X == 16) {
                    tex.X = 0;
                    col.IsColliderOn = true;
                }

                bar.ActivationTimer = 0;
            }
        });

    }

}