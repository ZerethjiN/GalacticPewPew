using System.Collections.Generic;
using SFML.System;
using System;

namespace AlizeeEngine {
    public class World {

        internal ListEntity Entities { get; set; }

        private List<LateCommand> lateBuffer;
        private List<Type> typeBuffer;
        private Systems systems;
        private bool open;
        private Clock clock;
        private bool refresh;
        private bool refreshAll;

        public World() {
            Entities = new ListEntity();
            refresh = false;
            systems = new Systems(this);
            lateBuffer = new List<LateCommand>();
            typeBuffer = new List<Type>();
            open = true;
            clock = new Clock();
            refreshAll = false;
        }

        // GameLoop du jeu.
        public void Run() {
            while (open) {
                Time.deltaTime = clock.ElapsedTime.AsSeconds();
                Time.frameCount = 1 / Time.deltaTime;
                clock.Restart();

                //#if FRAME
                    //Time.FrameCounter();
                //#endif

                systems.OnUpdate();

                if (refresh)
                    UpgradeWorld();
            }
        }

        // Ajout d'une nouvelle entite.
        public World AddEnt(Entity ent) {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.AddEnt,
                    Ent = ent
                }
            );
            refresh = true;
            return this;
        }

        // Ajout d'un nouveau composant.
        public World AddCmp<T>(Object cmp, Entity ent) {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.AddCmp,
                    CmpType = typeof(T),
                    Cmp = cmp,
                    Ent = ent
                }
            );
            refresh = true;
            return this;
        }

        // retrait d'une entite
        public void DropEnt(Entity ent) {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.DropEnt,
                    Ent = ent
                }
            );
            refresh = true;
        }

        // Retrait d'un composant
        public void DropCmp<T>(Entity ent) {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.DropCmp,
                    CmpType = typeof(T),
                    Ent = ent
                }
            );
            refresh = true;
        }

        // Replacement d'un composant
        public void ReplaceCmp<T0, T1>(Object cmp, Entity ent) {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.DropCmp,
                    CmpType = typeof(T0),
                    Ent = ent
                }
            );
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.AddCmp,
                    CmpType = typeof(T1),
                    Cmp = cmp,
                    Ent = ent
                }
            );
            refresh = true;
        }

        // fermeture du programme
        public void CloseProgram() {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.CloseProgram
                }
            );
            refresh = true;
        }

        // Ajout de system
        public void AddSystem(ClodoBehaviour system) {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.AddSystem,
                    Sys = system
                }
            );
            refresh = true;
        }

        // Suppression des systemes
        public void ClearSystems() {
            lateBuffer.Add(
                new LateCommand {
                    Type = LateCommandType.ClearSystems
                }
            );
            refresh = true;
        }

        // Mise a jour du World en fonction des commandes recuperees.
        private void UpgradeWorld() {
            #if UPGRADE
                System.Console.WriteLine("-- World Upgrade --");
            #endif

            typeBuffer.Clear();

            lateBuffer.ForEach( cmd => {
                switch (cmd.Type) {
                    case LateCommandType.AddEnt:
                        Entities.Add(cmd.Ent);
                        cmd.Ent.AllKeys( key => {
                            typeBuffer.Add(key);
                        });
                        break;

                    case LateCommandType.AddCmp:
                        cmd.Ent.Add(cmd.CmpType, cmd.Cmp);
                        typeBuffer.Add(cmd.CmpType);
                        break;

                    case LateCommandType.DropEnt:
                        Entities.Remove(cmd.Ent);
                        cmd.Ent.AllKeys( key => {
                            typeBuffer.Add(key);
                        });
                        break;

                    case LateCommandType.DropCmp:
                        cmd.Ent.Remove(cmd.CmpType);
                        typeBuffer.Add(cmd.CmpType);
                        break;

                    case LateCommandType.CloseProgram:
                        open = false;
                        break;

                    case LateCommandType.ClearSystems:
                        systems.ClearSystems();
                        break;

                    case LateCommandType.AddSystem:
                        systems.AddSystem(cmd.Sys);
                        cmd.Sys.OnCreate();
                        refreshAll = true;
                        break;
                }
            });

            if (refreshAll) {
                systems.RefreshSystem();
                refreshAll = false;
            } else {
                systems.RefreshSystem(typeBuffer);
            }
            lateBuffer.Clear();
            refresh = false;
        }

    }
}