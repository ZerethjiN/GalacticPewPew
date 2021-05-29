using AlizeeEngine;

class FonceurOndulentMovementSystem: ClodoBehaviour {

    private float normY;

    public override void OnUpdate() {

        /* Deplacement des fonceurs ondulents */
        Entities.Filter<FonceurOndulent>().ForEach( (Position posEnn, Ennemy ennemy, Texture tex) => {
            normY = 0;

            if (posEnn.X < 256) {
                Entities.Filter<Player>().ForEach( (Position posPly) => {
                    if (posPly.Y - 8 > posEnn.Y) {
                        normY = 0.25f;
                        tex.Y = 96;
                    }

                    else if (posPly.Y + 8 < posEnn.Y) {
                        normY = -0.25f;
                        tex.Y = 48;
                    }

                    else {
                        normY = 0;
                        tex.Y = 0;
                    }
                });
            }

            posEnn.Y += normY * 100 * Time.deltaTime;
        });

    }

}