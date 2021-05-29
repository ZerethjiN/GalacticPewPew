using AlizeeEngine;

class EnnemyMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Deplacement des ennemies */
        Entities.ForEach( (Entity ent, Position pos, Ennemy ennemy, Texture tex) => {    
            pos.X -= ennemy.Speed * Time.deltaTime;

            /* Suppresion des ennemis si en dehors de l'ecran */
            if (pos.X + tex.Width < 0)
                World.DropEnt(ent);
        });

    }

}