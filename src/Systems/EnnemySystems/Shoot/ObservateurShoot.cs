using AlizeeEngine;

class ObservateurShootSystem: ClodoBehaviour {

    private Entity newEnt;

    public override void OnUpdate() {
    
        /* Tir des observateurs */
        Entities.ForEach( (Observateur obs, Position pos) => {
            if (pos.X < 256) {
                obs.ShootTimer += Time.deltaTime;

                if (obs.ShootTimer > obs.ShootCooldown) {
                    AddMissile(pos);
                    obs.ShootTimer = 0;
                }
            }
        });
    }

    private void AddMissile(Position pos) {
        newEnt = new Entity();
        World.AddEnt(newEnt);
        World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = (float) 0.5, CurrentTime = 0 }, newEnt);
        World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, newEnt);
        World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, newEnt);
        World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, newEnt);
        World.AddCmp<Texture>(new Texture("Missile", 16, 0, 16, 16), newEnt);
        World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 0 }, newEnt);
    }

}