using AlizeeEngine;

class FurtifMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Deplacement des furtif */
        Entities.ForEach( (Ennemy enn, Furtif furtif, Position pos) => {
            if (pos.X <= furtif.StaticX)
                pos.X += enn.Speed * Time.deltaTime;
            
            if (furtif.isUp) {
                pos.Y -= enn.Speed * Time.deltaTime;
                if (pos.Y < 16)
                    furtif.isUp = false;
            } else {
                pos.Y += enn.Speed * Time.deltaTime;
                if (pos.Y > 160)
                    furtif.isUp = true;
            }
        });

    }

}