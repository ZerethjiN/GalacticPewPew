using AlizeeEngine;

class KamikazeMovementSystem: ClodoBehaviour {

    private float normY;

    public override void OnUpdate() {

        /* Deplacement des fonceurs ondulents */
        Entities.Filter<Kamikaze>().ForEach( (Position posEnn, Ennemy ennemy) => {
            normY = 0;

            Entities.Filter<Player>().ForEach( (Position posPly) => {
                if (posPly.Y <= 256)
                    if (posPly.Y > posEnn.Y)
                        normY = 1;
                    else if (posPly.Y < posEnn.Y)
                        normY = -1;
            });

            posEnn.Y += normY * 100 * Time.deltaTime;
        });

    }

}