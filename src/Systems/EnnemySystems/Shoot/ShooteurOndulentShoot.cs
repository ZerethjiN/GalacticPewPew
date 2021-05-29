using AlizeeEngine;

class ShooteurOndulentShootSystem: ClodoBehaviour {

    private Entity newEnt;

    public override void OnUpdate() {

        /* Tir des shooteurs */
        Entities.ForEach( (ShooteurOndulent shooteur, Position pos) => {
            if (pos.X > 0 && pos.X < 512) {
                shooteur.ShootTimer += Time.deltaTime;

                if (shooteur.ShootTimer > shooteur.ShootCooldown) {
                    AddMissileShooteur(pos);
                    shooteur.ShootTimer = 0;
                }
            }
        });

    }

    private void AddMissileShooteur(Position pos) {
        newEnt = new Entity();
        World.AddEnt(newEnt);
        World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = 0.5f, CurrentTime = 0 }, newEnt);
        World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, newEnt);
        World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, newEnt);
        World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, newEnt);
        World.AddCmp<Texture>(new Texture("Missile", 16, 0, 16, 16), newEnt);
        World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 0 }, newEnt);
    }

}