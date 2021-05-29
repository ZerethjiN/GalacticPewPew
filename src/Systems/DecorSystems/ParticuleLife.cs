using AlizeeEngine;

class ParticuleLifeSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Entity ent, Particule part, Texture tex) => {
            part.CurrentTime += Time.deltaTime;

            if (part.CurrentTime > part.MidTime && tex.X != part.newTexturePosition)
                tex.X = part.newTexturePosition;

            else if (part.CurrentTime > part.MaxTime)
                World.DropEnt(ent);
        });

    }

}