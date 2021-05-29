using AlizeeEngine;

class ScrapMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Entity ent, Position pos, Scrap scrap) => {
            /* Deplacement des scraps */
            pos.X -= scrap.Speed * Time.deltaTime;

            /* Suppression des scraps si en dehors de l'ecran */
            if (pos.X < -16)
                World.DropEnt(ent);
        });

    }

}