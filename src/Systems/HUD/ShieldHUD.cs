using AlizeeEngine;

class ShieldHUDSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Entity ent, Bouclier bouclier) => {
            if (bouclier.Life == 0)
                World.DropEnt(ent);
        });

    }

}