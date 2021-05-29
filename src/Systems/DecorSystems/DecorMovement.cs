using AlizeeEngine;

class DecorMovement: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.Without<TileMap>().ForEach( (Entity ent, Decor decor, Position pos) => {
            pos.X -= decor.Speed * Time.deltaTime;

            /* Suppresion des ennemis si en dehors de l'ecran */
            if (pos.X < -16)
                World.DropEnt(ent);
        });

        Entities.Filter<TileMap>().ForEach( (Entity ent, Decor decor, Position pos) => {
            pos.X -= decor.Speed * Time.deltaTime;
        });

    }

}