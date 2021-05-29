using AlizeeEngine;

class DynamicHudSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (HUD hud, Texture tex) => {

            if (hud.Background) {

                Entities.ForEach( (ScrapScoring score) => {    
                    if (hud.Cost <= score.Scraps)
                        tex.X = 64;
                    else
                        tex.X = 160;
                });

                Entities.ForEach( (Selector sel) => {
                    if (sel.Bouclier && hud.Bouclier)
                        tex.X = 112;

                    if (sel.Acceleration && hud.Acceleration)
                        tex.X = 112;

                    if (sel.TirMultiple && hud.TirMultiple)
                        tex.X = 112;
                });

            }

        });

    }

}