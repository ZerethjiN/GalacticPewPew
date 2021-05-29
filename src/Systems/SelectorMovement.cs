using AlizeeEngine;

class SelectorMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Selector sel, Position pos) => {
            switch (sel.Selection) {
                case Selection.TirMultiple:
                    if (!sel.TirMultiple) {

                        Entities.ForEach( (ScrapScoring score) => {
                            if (score.Scraps >= 2) {
                                score.Scraps -= 2;
                                sel.TirMultiple = true;
                            }
                        });

                    }
                    break;
                
                case Selection.Acceleration:
                    if (!sel.Acceleration) {

                        Entities.ForEach( (ScrapScoring score) => {
                            if (score.Scraps >= 2) {
                                sel.Acceleration = true;
                                score.Scraps -= 2;
                            }
                        });

                    }
                    break;
                
                case Selection.Bouclier:
                    if (!sel.Bouclier) {

                        Entities.ForEach( (ScrapScoring score) => {
                            if (score.Scraps >= 2) {
                                score.Scraps -= 2;
                                sel.Bouclier = true;
                            }
                        });

                    }
                    break;
            }
        });

    }

}