using AlizeeEngine;

class Boss1MovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Deplacement du boss */
        Entities.Without<Boss1Mine>().ForEach( (Ennemy enn, Boss1 boss, Position pos) => {
            if (pos.X <= 256) {
                if (pos.X <= boss.StaticX)
                    pos.X += enn.Speed * Time.deltaTime;
                
                if (!boss.IsOpen) {
                    if (boss.isUp) {
                        pos.Y -= enn.Speed * Time.deltaTime;
                        if (pos.Y - boss.maxY < 0)
                            boss.isUp = false;
                    } else {
                        pos.Y += enn.Speed * Time.deltaTime;
                        if (pos.Y + boss.minY > 160)
                            boss.isUp = true;
                    }
                }
            }
        });

        /* Separation du boss */
        Entities.ForEach( (Ennemy enn, Boss1 boss, Boss1Top bossTop, Position pos, Collider col) => {
            if (pos.X <= 256) {
                bossTop.OpeningTimer += Time.deltaTime;

                if (!bossTop.IsOpen) {
                    if (bossTop.OpeningTimer >= bossTop.OpeningCooldown) {
                        pos.Y -= 16;
                        bossTop.IsOpen = true;
                        boss.IsOpen = true;
                        bossTop.OpeningTimer = 0;
                        col.Height = 32;
                    }
                }
                
                else {
                    if (bossTop.OpeningTimer >= bossTop.ClosingCoolDown) {
                        pos.Y += 16;
                        bossTop.IsOpen = false;
                        boss.IsOpen = false;
                        bossTop.OpeningTimer = 0;
                        col.Height = 40;
                    }
                }
            }
        });
        Entities.ForEach( (Ennemy enn, Boss1 boss, Boss1Bottom bossBottom, Position pos, Collider col) => {
            if (pos.X <= 256) {
                bossBottom.OpeningTimer += Time.deltaTime;

                if (!bossBottom.IsOpen) {
                    if (bossBottom.OpeningTimer >= bossBottom.OpeningCooldown) {
                        pos.Y += 16;
                        bossBottom.IsOpen = true;
                        boss.IsOpen = true;
                        bossBottom.OpeningTimer = 0;
                        col.Height = 32;
                        col.Y = 8;
                    }
                }
                
                else {
                    if (bossBottom.OpeningTimer >= bossBottom.ClosingCoolDown) {
                        pos.Y -= 16;
                        bossBottom.IsOpen = false;
                        boss.IsOpen = false;
                        bossBottom.OpeningTimer = 0;
                        col.Height = 40;
                        col.Y = 0;
                    }
                }
            }
        });
        Entities.ForEach( (Ennemy enn, Boss1 boss, Boss1Coeur bossCoeur, Position pos, Texture tex) => {
            if (pos.X - 28 <= 256) {
                bossCoeur.OpeningTimer += Time.deltaTime;

                if (!bossCoeur.IsOpen) {
                    if (bossCoeur.OpeningTimer >= bossCoeur.OpeningCooldown) {
                        bossCoeur.IsOpen = true;
                        boss.IsOpen = true;
                        bossCoeur.OpeningTimer = 0;
                    }
                }
                
                else {
                    if (bossCoeur.OpeningTimer >= bossCoeur.ClosingCoolDown) {
                        bossCoeur.IsOpen = false;
                        boss.IsOpen = false;
                        bossCoeur.OpeningTimer = 0;
                    }
                }

                if (enn.HP == 15) {
                    Entities.ForEach( (Boss1Mine mine) => {
                        mine.Active = true;
                    });
                }
                
                if (bossCoeur.IsToucher) {
                    tex.Y = 48;
                    bossCoeur.ToucherTimer += Time.deltaTime;

                    if (bossCoeur.ToucherTimer >= bossCoeur.ToucherCooldown) {
                        bossCoeur.IsToucher = false;
                        bossCoeur.ToucherTimer = 0;
                    }
                } else {
                    tex.Y = 64;
                }
            }
        });

        /* Deplacement de la mine */
        Entities.ForEach( (Ennemy enn, Boss1 boss, Boss1Mine mine, Position pos, Vector2 vec) => {
            if (pos.X + 15 <= 256) {
                if (mine.Active) {
                    pos.X += vec.X * enn.Speed * Time.deltaTime;
                    pos.Y += vec.Y * enn.Speed * Time.deltaTime;

                    if (pos.X < mine.minX)
                        vec.X = 2;
                    else if (pos.X > mine.maxX)
                        vec.X = -1;

                    if (pos.Y < mine.minY)
                        vec.Y = 1;
                    else if (pos.Y > mine.maxY)
                        vec.Y = -1;
                } else {
                    mine.OpeningTimer += Time.deltaTime;

                    if (!mine.IsOpen) {
                        if (mine.OpeningTimer >= mine.OpeningCooldown) {
                            pos.Y -= 16;
                            mine.IsOpen = true;
                            boss.IsOpen = true;
                            mine.OpeningTimer = 0;
                        }
                    }
                    
                    else {
                        if (mine.OpeningTimer >= mine.ClosingCoolDown) {
                            pos.Y += 16;
                            mine.IsOpen = false;
                            boss.IsOpen = false;
                            mine.OpeningTimer = 0;
                        }
                    }

                    if (pos.X <= boss.StaticX)
                        pos.X += enn.Speed * Time.deltaTime;
                
                    if (!boss.IsOpen) {
                        if (boss.isUp) {
                            pos.Y -= enn.Speed * Time.deltaTime;
                            if (pos.Y - boss.maxY < 0)
                                boss.isUp = false;
                        } else {
                            pos.Y += enn.Speed * Time.deltaTime;
                            if (pos.Y + boss.minY > 160)
                                boss.isUp = true;
                        }
                    }
                }
            }
        });
    }

}