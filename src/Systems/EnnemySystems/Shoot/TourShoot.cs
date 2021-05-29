using AlizeeEngine;

class TourShootSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Tir des tours */
        Entities.ForEach( (Tour tour, Position pos, Texture tex, Animation anim) => {
            if (pos.X > -256 && pos.X < 512) {
                tour.ShootTimer += Time.deltaTime;

                if (tour.ShootTimer > tour.ShootCooldown) {
                    tex.X = 32;
                    anim.Lock = true;

                    if (tour.FromTop)
                        AddMissileToursFromTop(pos);
                    else
                        AddMissileToursFromBottom(pos);
                    tour.ShootTimer = 0;
                }

                else if (tour.ShootTimer > 0.25 && tex.X == 32) {
                    tex.X = anim.CurrentFrame * anim.NextFramePosition + anim.NextFramePosition;
                    anim.Lock = false;
                }
            }
        });

    }

    private void AddMissileToursFromBottom(Position pos) {
        Entity entity;
        for (int i = 0; i < 3; i++) {
            entity = new Entity();
            World.AddEnt(entity);
            World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = (float) 0.5, CurrentTime = 0 }, entity);
            World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, entity);
            World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, entity);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, entity);

            if (i == 0) {
                World.AddCmp<Texture>(new Texture("Missile", x: 48), entity);
                World.AddCmp<Vector2>(new Vector2 { X = -1, Y = -1 }, entity);
            }

            else if (i == 1) {
                World.AddCmp<Texture>(new Texture("Missile", x: 64), entity);
                World.AddCmp<Vector2>(new Vector2 { X = 0, Y = -1 }, entity);
            }

            else if (i == 2) {
                World.AddCmp<Texture>(new Texture("Missile", x: 32), entity);
                World.AddCmp<Vector2>(new Vector2 { X = 1, Y = -1 }, entity);
            }
        }
    }

    private void AddMissileToursFromTop(Position pos) {
        Entity entity;
        for (int i = 0; i < 3; i++) {
            entity = new Entity();
            World.AddEnt(entity);
            World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = (float) 0.5, CurrentTime = 0 }, entity);
            World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, entity);
            World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, entity);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, entity);

            if (i == 0) {
                World.AddCmp<Texture>(new Texture("Missile", x: 32), entity);
                World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 1 }, entity);
            }

            else if (i == 1) {
                World.AddCmp<Texture>(new Texture("Missile", x: 64), entity);
                World.AddCmp<Vector2>(new Vector2 { X = 0, Y = 1 }, entity);
            }

            else if (i == 2) {
                World.AddCmp<Texture>(new Texture("Missile", x: 48), entity);
                World.AddCmp<Vector2>(new Vector2 { X = 1, Y = 1 }, entity);
            }
        }
    }

}