using AlizeeEngine;

class MineMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Deplacement des tourelles */
        Entities.ForEach( (Ennemy enn, Mine mine, Position pos) => {
            if (pos.X <= mine.StaticX)
                pos.X += enn.Speed * Time.deltaTime;
        });

    }

}