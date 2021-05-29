using AlizeeEngine;

class TourelleMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Deplacement des tourelles */
        Entities.ForEach( (Ennemy enn, Tourelle tourelle, Position pos) => {
            if (pos.X <= tourelle.StaticX)
                pos.X += enn.Speed * Time.deltaTime;
        });

    }

}