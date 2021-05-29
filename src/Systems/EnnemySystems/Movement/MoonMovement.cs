using AlizeeEngine;

class MoonMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Deplacement des lunes */
        Entities.ForEach( (Ennemy enn, Moon moon, Position pos) => {
            if (pos.X <= moon.StaticX)
                pos.X += enn.Speed * Time.deltaTime;
            
            if (moon.isUp) {
                pos.Y -= enn.Speed * Time.deltaTime;
                if (pos.Y < 16)
                    moon.isUp = false;
            } else {
                pos.Y += enn.Speed * Time.deltaTime;
                if (pos.Y > 160)
                    moon.isUp = true;
            }
        });

    }

}