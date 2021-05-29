using AlizeeEngine;

class FurtifShootSystem: ClodoBehaviour {

    private Entity newEnt;

    public override void OnUpdate() {

        /* Tir des Furtifs */
        Entities.ForEach( (Furtif furtif, Position pos, Texture tex) => {
            if (pos.X < 512) {
                furtif.ShootTimer +=  Time.deltaTime;

                if (furtif.ShootTimer > furtif.ShootCooldown) {
                    tex.X = 16;

                    AddMissile(pos);

                    furtif.ShootTimer = 0;
                }

                else if (furtif.ShootTimer > 0.5 && furtif.ShootTimer < 1 && tex.X == 16) {
                    tex.X = 32;
                }

                else if (furtif.ShootTimer > 1 && tex.X == 32) {
                    tex.X = 0;
                }

                else if (furtif.ShootTimer > furtif.ShootCooldown - 0.5 && tex.X == 0) {
                    tex.X = 32;
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