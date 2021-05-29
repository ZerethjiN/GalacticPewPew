using AlizeeEngine;

class PlayerShootSystem: ClodoBehaviour {

    private bool isTirMultiple;

    public override void OnUpdate() {

        Entities.ForEach( (Player player, Position pos, Texture tex, Animation anim) => {
            player.ShootTimer += Time.deltaTime;

            if (player.ShootTimer > player.ShootCooldown) {
                if (player.Shoot) {

                    Entities.ForEach( (Selector sel) => {
                        isTirMultiple = sel.TirMultiple;
                    });

                    tex.X = 96;
                    anim.Lock = true;

                    if (isTirMultiple)
                        AddTirMultiple(pos);
                    else
                        AddMissile(pos);

                    player.ShootTimer = 0;
                }
            }

            if (player.ShootTimer > 0.1 && tex.X == 96) {
                tex.X = anim.CurrentFrame * anim.NextFramePosition + anim.NextFramePosition;
                anim.Lock = false;
            }
        });

    }

    private void AddMissile(Position pos) {
        Entity entity;

        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<MissilePlayer>(new MissilePlayer { Speed = 200, MaxTime = (float) 1, CurrentTime = 0 }, entity);
        World.AddCmp<Texture>(new Texture("Missile"), entity);
        World.AddCmp<Position>(new Position { X = pos.X + 16, Y = pos.Y + 16 }, entity);
        World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, entity);
        World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(0.0f, 1.0f, 0.0f), Radius = 16, Speed = 0 }, entity);
    }

    private void AddTirMultiple(Position pos) {
        Entity entity;

        for (int i = 0; i < 3; i++) {
            entity = new Entity();
            World.AddEnt(entity);
            World.AddCmp<MissilePlayer>(new MissilePlayer { Speed = 200, MaxTime = (float) 1, CurrentTime = 0 }, entity);
            World.AddCmp<Texture>(new Texture("Missile"), entity);
            World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y + (i * 16) }, entity);
            World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, entity);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(0, 1f, 0), Radius = 16, Speed = 0 }, entity);
        }
    }

}