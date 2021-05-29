using AlizeeEngine;

class EnnemyCollisionSystem: ClodoBehaviour {

    private bool toucherMaisPasDetruit;
    private bool reload;
    private string NextLevel;

    public override void OnUpdate() {

        Entities.ForEach( (Score score) => {
            Entities.ForEach( (Entity entMis, MissilePlayer mis, Collider colMis, Position posMis) => {

                Entities.Without<Tour, Boss1Coeur>().ForEach( (Entity entEnn, Ennemy enn, Collider colEnn, Position posEnn) => {
                    if (posEnn.X <= 256 && posEnn.X > 0)
                        performCollision(enn, mis, colEnn, posEnn, colMis, posMis, score, entEnn, entMis);
                });

                Entities.Filter<Tour>().ForEach( (Entity entEnn, Ennemy enn, Collider colEnn, Position posEnn, Texture texEnn) => {
                    if (posEnn.X <= 256 && posEnn.X > 0)
                        performCollision(enn, mis, colEnn, posEnn, colMis, posMis, score, texEnn, entEnn, entMis);
                });

                Entities.ForEach( (Entity entEnn, Ennemy enn, Collider colEnn, Position posEnn, Boss1Coeur coeur) => {
                    if (posEnn.X <= 256 && posEnn.X > 0)
                        performCollisionBoss1(enn, mis, colEnn, posEnn, colMis, posMis, score, entEnn, entMis, coeur);
                });

                Entities.ForEach( (Entity entEnn, Ennemy enn, Collider colEnn, Position posEnn, MidBoss midBoss) => {
                    if (posEnn.X <= 256 && posEnn.X > 0)
                        performCollisionMidBoss(enn, mis, colEnn, posEnn, colMis, posMis, score, entEnn, entMis, midBoss);
                });

            });
        });

        if (reload) {
            Loader.loadScene(World, NextLevel);
            reload = false;
        }

    }

    private void performCollision(Ennemy enn, MissilePlayer mis, Collider col1, Position pos1, Collider col2, Position pos2, Score score, Entity entEnn, Entity entMis) {
        if (!Utils.Intersect(pos1, col1, pos2, col2))
            return;

        if (enn.HP == 0) {
            toucherMaisPasDetruit = false;
            score.Points += enn.Points;
        }
        else if (enn.HP > 0) {
            toucherMaisPasDetruit = true;
            enn.HP--;
        } else if (enn.HP < 0) {
            toucherMaisPasDetruit = true;
        }

        AddMissile(entEnn, entMis, pos1);
    }

    private void performCollision(Ennemy enn, MissilePlayer mis, Collider col1, Position pos1, Collider col2, Position pos2, Score score, Texture tex, Entity entEnn, Entity entMis) {
        if (!Utils.Intersect(pos1, col1, pos2, col2))
            return;

        if (enn.HP == 0) {
            toucherMaisPasDetruit = false;
            score.Points += enn.Points;
        }
        else if (enn.HP >= 0) {
            tex.X += 48;
            toucherMaisPasDetruit = true;
            enn.HP--;
        } else if (enn.HP < 0) {
            toucherMaisPasDetruit = true;
        }

        AddMissile(entEnn, entMis, pos1);
    }

    private void performCollisionBoss1(Ennemy enn, MissilePlayer mis, Collider col1, Position pos1, Collider col2, Position pos2, Score score, Entity entEnn, Entity entMis, Boss1Coeur coeur) {
        if (!Utils.Intersect(pos1, col1, pos2, col2))
            return;

        if (enn.HP == 0) {
            toucherMaisPasDetruit = false;
            score.Points += enn.Points;

            Entities.ForEach(ent => {
                if (ent.Contains<CurrentScene>())
                    World.DropEnt(ent);
            });
            reload = true;
            NextLevel = "menu";
        }
        else if (enn.HP >= 0) {
            coeur.IsToucher = true;
            toucherMaisPasDetruit = true;
            enn.HP--;
        } else if (enn.HP < 0) {
            toucherMaisPasDetruit = true;
        }

        AddMissile(entEnn, entMis, pos1);
    }

    private void performCollisionMidBoss(Ennemy enn, MissilePlayer missile, Collider col1, Position pos1, Collider col2, Position pos2, Score score, Entity entEnn, Entity entMis, MidBoss midBoss) {
        if (!Utils.Intersect(pos1, col1, pos2, col2))
            return;

        if (enn.HP > 0) {
            toucherMaisPasDetruit = true;
            enn.HP--;
        } else if (enn.HP == 0) {
            if (toucherMaisPasDetruit) {
                Entities.ForEach(ent => {
                    if (ent.Contains<CurrentScene>())
                        World.DropEnt(ent);
                });
                reload = true;
                NextLevel = midBoss.NextStage;
            }


            toucherMaisPasDetruit = false;
            score.Points += enn.Points;
        } else if (enn.HP < 0) {
            toucherMaisPasDetruit = true;
        }

        AddMissile(entEnn, entMis, pos1);
    }

    private void AddMissile(Entity entEnn, Entity entMis, Position pos) {

        if (!toucherMaisPasDetruit) {
            /* Particule d'explosion */
            Entity entity = new Entity();
            World.AddEnt(entity);
            World.AddCmp<Texture>(new Texture("Explosion", width: 32, height: 32), entity);
            World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, entity);
            World.AddCmp<Particule>(new Particule { MaxTime = 0.2f, MidTime = 0.1f, CurrentTime = 0, newTexturePosition = 32 }, entity);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1f, 1f, 0), Radius = 48, MaxRadius = 64, MinRadius = 48, Speed = 5, Increase = true }, entity);

            /* Scrap */
            entity = new Entity();
            World.AddEnt(entity);
            World.AddCmp<Texture>(new Texture("Scrap"), entity);
            World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, entity);
            World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16 }, entity);
            World.AddCmp<Scrap>(new Scrap { Speed = 50 }, entity);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(0, 0.5f, 1f), Radius = 16, MaxRadius = 32, MinRadius = 16, Speed = 5, Increase = true }, entity);

            /* Suppression de l'ennemi */
            World.DropEnt(entEnn);
        }

        /* Suppresion du missile */
        World.DropEnt(entMis);

    }

}