using AlizeeEngine;

class MeteoreMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Deplacement des meteores */
        Entities.ForEach( (Position pos, Ennemy ennemy, Meteore meteore) => {
            if (pos.X < 256)
                if (meteore.FromTop) 
                    pos.Y += ennemy.Speed * Time.deltaTime;
                else
                    pos.Y -= ennemy.Speed * Time.deltaTime;
        });

    }

}