using AlizeeEngine;

class ShooteurOndulentMovementSystem: ClodoBehaviour {

    private float normY;

    public override void OnUpdate() {

        /* Deplacement des fonceurs ondulents */
        Entities.Filter<ShooteurOndulent>().ForEach( (Position posEnn, Ennemy ennemy, Texture tex) => {
            normY = 0;

            if (posEnn.X < 256) {

                Entities.Filter<Player>().ForEach( (Position posPly) => {
                    if (posPly.Y - 8 > posEnn.Y)
                        normY = 0.25f;
                    else if (posPly.Y + 8 < posEnn.Y)
                        normY = -0.25f;
                    else
                        normY = 0;
                });

            }

            posEnn.Y += normY * 100 * Time.deltaTime;
        });

    }

}