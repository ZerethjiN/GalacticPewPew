using AlizeeEngine;

class MoonShootSystem: ClodoBehaviour {

    private Entity newEnt;

    public override void OnUpdate() {

        /* Tir des lunes */
        Entities.ForEach( (Moon moon, Position pos, Texture tex, Animation anim) => {
            if (pos.X < 256) {
                moon.ShootTimer +=  Time.deltaTime;

                if (moon.ShootTimer > moon.ShootCooldown) {
                    tex.X = 144;
                    anim.Lock = true;

                    AddMissile(pos);
                    moon.ShootTimer = 0;
                }

                else if (moon.ShootTimer > 0.25 && tex.X == 144) {
                    tex.X = anim.CurrentFrame * anim.NextFramePosition + anim.NextFramePosition;
                    anim.Lock = false;
                }
            }
        });

    }

    private void AddMissile(Position pos) {
        newEnt = new Entity();
        World.AddEnt(newEnt);
        World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = (float) 0.5, CurrentTime = 0, FromMoon = true }, newEnt);
        World.AddCmp<Position>(new Position { X = pos.X - 192, Y = pos.Y + 16 }, newEnt);
        World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 192, Height = 16, IsColliderOn = true }, newEnt);
        World.AddCmp<Texture>(new Texture("Missile", 0, 16, 192, 16), newEnt);
        World.AddCmp<Vector2>(new Vector2 { X = 0, Y = 0 }, newEnt);
        World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, newEnt);
    }

}