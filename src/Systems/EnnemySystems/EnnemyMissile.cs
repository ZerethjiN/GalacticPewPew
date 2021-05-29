using AlizeeEngine;

class EnnemyMissileSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Missile de l'ennemi */
        Entities.ForEach( (Entity ent, MissileEnnemy mis, Position pos, Vector2 vec) => {
            mis.CurrentTime += Time.deltaTime;

            if (mis.CurrentTime >= mis.MaxTime)
                World.DropEnt(ent);

            pos.X += vec.X * mis.Speed * Time.deltaTime;
            pos.Y += vec.Y * mis.Speed * Time.deltaTime;

            if (mis.FromMoon) {

                Entities.Filter<Moon>().ForEach( (Position posMoon) => {
                    pos.Y = posMoon.Y + 16;
                });

            }

            if (mis.FromBoss1) {

                Entities.Filter<Boss1Coeur>().ForEach( (Position posBoss1) => {
                    pos.Y = posBoss1.Y;
                });

            }
        });

    }

}