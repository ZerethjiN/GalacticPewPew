using AlizeeEngine;

class PlayerShieldSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Creation du shield */
        Entities.ForEach( (Selector sel) => {
            if (sel.Bouclier && Entities.TotalOf<Bouclier>() == 0) {
                sel.Selection = Selection.TirSimple;
                AddShield();
                sel.Bouclier = false;
            }
        });

        /* Traitement du shield */
        Entities.ForEach( (Bouclier bouclier, Position posBou) => {
            /* Deplacement du shield sur le joueur */
            Entities.Filter<Player>().ForEach( (Position posPly) => {
                posBou.X = posPly.X;
                posBou.Y = posPly.Y;
            });

            /* Frame d'invisibilite du shield */
            if (bouclier.isTouche) {
                bouclier.InvicibleTimer += Time.deltaTime;

                if (bouclier.InvicibleTimer > bouclier.InvicibleCoolDown) {
                    Entities.ForEach( (Entity ent, ShieldHUD shield) => {
                        if (shield.Id == bouclier.Life + 1) {
                            World.DropEnt(ent);
                        }
                    });
                    bouclier.isTouche = false;
                    bouclier.InvicibleTimer = 0;
                }
            }
        });

    }

    private void AddShield() {
        Entity entity;

        /* Ajout d'un Bouclier */
        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Bouclier>(new Bouclier { Life = 3, InvicibleCoolDown = 0.5f, InvicibleTimer = 0, isTouche = false }, entity);
        World.AddCmp<Position>(new Position { X = 0, Y = 0 }, entity);
        World.AddCmp<Texture>(new Texture("HUD", y: 32, width: 48, height: 48), entity);
        World.AddCmp<Light>(new Light {
            Color = new SFML.Graphics.Glsl.Vec3(0, 0.5f, 0),
            Radius = 32,
            MaxRadius = 48,
            MinRadius = 32,
            Speed = 5,
            Increase = true
        }, entity);

        /* Ajouts des points de vie du bouclier */
        for (int i = 1; i <= 3; i++) {
            entity = new Entity();
            World.AddEnt(entity);
            World.AddCmp<ShieldHUD>(new ShieldHUD { Id = i }, entity);
            World.AddCmp<Texture>(new Texture("HUD", x: 48), entity);
            World.AddCmp<Position>(new Position { X = 16 * (i - 1), Y = 0 }, entity);
            World.AddCmp<NoShader>(new NoShader(), entity);
        }
    }

}