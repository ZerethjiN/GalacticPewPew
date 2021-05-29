using AlizeeEngine;

class ObservateurMovementSystem: ClodoBehaviour {

    private float normY;

    public override void OnUpdate() {
        
        /* Deplacement des observateurs */
        Entities.ForEach( (Ennemy enn, Observateur obs, Position pos) => {
            if (pos.X <= obs.StaticX)
                pos.X += enn.Speed * Time.deltaTime;

            if (pos.X < 256) {
                normY = 0;

                Entities.Filter<MissilePlayer>().ForEach( (Position posMis) => {
                    if (posMis.Y >= pos.Y && pos.Y > 64)
                        normY = -1f;
                    else if (posMis.Y < pos.Y && pos.Y < 144)
                        normY = 1f;
                    else
                        normY = 0;
                });

                pos.Y += normY * 100 * Time.deltaTime;
            }
        });

    }

}