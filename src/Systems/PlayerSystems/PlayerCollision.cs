using AlizeeEngine;

class PlayerCollisionSystem: ClodoBehaviour {

    private bool isTouche;
    private bool lateState;
    private bool suppresion;

    public override void OnUpdate() {
        isTouche = false;

        Entities.ForEach( (Player ply, Collider colPly, Position posPly) => {
            /* Pour tous ennemies */
            Entities.Filter<Ennemy>().ForEach( (Collider colEnn, Position posEnn) => {
                if (!isTouche && colEnn.IsColliderOn)
                    if (posEnn.X <= 256 && posEnn.X > 0) {
                        if (Utils.Intersect(posPly, colPly, posEnn, colEnn)) {
                            isTouche = true;
                        }
                    }
            });

            /* Pour tous missiles ennemies */
            Entities.Filter<MissileEnnemy>().ForEach( (Collider colMis, Position posMis) => {
                if (!isTouche && colMis.IsColliderOn)
                    if (posMis.X <= 256 && posMis.X > 0){
                        if (Utils.Intersect(posPly, colPly, posMis, colMis)) {
                            isTouche = true;
                        }
                    }
            });
            
            /* */
            Entities.Filter<Border>().ForEach( (Collider colBor, Position posBor) => {
                if (!isTouche && colBor.IsColliderOn) {
                    if (Utils.Intersect(posPly, colPly, posBor, colBor)) {
                        isTouche = true;
                    }
                }
            });

            /* Pour toutes barrieres */
            Entities.Filter<Barriere>().ForEach( (Collider colBor, Position posBor) => {
                if (!isTouche && colBor.IsColliderOn) {
                    if (Utils.Intersect(posPly, colPly, posBor, colBor)) {
                        isTouche = true;
                    }
                }
            });

            if (ply.IsDestroy)
                isTouche = true;
        });

        if (isTouche) {
            lateState = true;

            Entities.ForEach( (Bouclier bouclier) => {
                if (bouclier.Life > 0) {
                    lateState = false;
                }

                if (!bouclier.isTouche) {
                    bouclier.Life--;
                    bouclier.isTouche = true;
                }
            });

            if (lateState) {
                Entities.ForEach( (Player ply, Texture texPly, Animation anim) => {
                    ply.IsDestroy = true;
                    ply.DestructionTimer += Time.deltaTime;

                    if (ply.DestructionTimer > 0 && ply.DestructionTimer <= 0.2) {
                        anim.Lock = true;
                        texPly.Y = 240;
                        texPly.X = 0;
                    }

                    if (ply.DestructionTimer > 0.2 && ply.DestructionTimer <= 0.4) {
                        texPly.Y = 240;
                        texPly.X = 48;
                    }

                    if (ply.DestructionTimer > 0.4) {
                        suppresion = true;
                    }
                });

                if (suppresion) {
                    SuppressionDuJeu();
                    suppresion = false;
                }
            }
        }

    }

    private void SuppressionDuJeu() {
        string sceneName = "menu";

        Entities.ForEach( ent => {
            if (!(ent.Contains<Window>() || ent.Contains<Input>() || ent.Contains<Selector>() || ent.Contains<Score>()))
                World.DropEnt(ent);
            if (ent.Contains<CurrentScene>())
                sceneName = ent.Get<CurrentScene>().SceneName;
        });

        World.ClearSystems();

        Loader.loadScene(World, sceneName);
    }

}