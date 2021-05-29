using AlizeeEngine;

class PlayerMissileSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Missile du joueur */
        Entities.ForEach( (Entity ent, MissilePlayer mis, Position pos) => {
            mis.CurrentTime += Time.deltaTime;

            if (mis.CurrentTime >= mis.MaxTime || pos.X + 16 >= 256)
                World.DropEnt(ent);

            pos.X += mis.Speed * Time.deltaTime;
        });

    }

}