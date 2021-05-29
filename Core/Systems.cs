using System.Collections.Generic;
using System;

namespace AlizeeEngine {
    public class Systems {

        private List<ClodoBehaviour> systemCollection;
        private World world;

        internal Systems(World world) {
            this.world = world;
            systemCollection = new List<ClodoBehaviour>();
        }

        // Ajoute un systeme a la collection.
        internal void AddSystem(ClodoBehaviour system) {
            systemCollection.Add(system);
            system.Query.world = world;
            system.World = world;
        }

        internal void ClearSystems() {
            systemCollection.Clear();
        }

        // Initialise toutes les queries.
        internal void OnCreate() {
            foreach (ClodoBehaviour querySystem in systemCollection) {
                querySystem.OnCreate();
            }
        }

        // Rafraichie tous les Systemes.
        internal void RefreshSystem() {
            foreach (ClodoBehaviour querySystem in systemCollection) {
                querySystem.Query.GetQuery();
            }
        }

        internal void RefreshSystem(List<Type> types) {
            foreach (ClodoBehaviour querySystem in systemCollection) {
                querySystem.Query.GetQuery(types);
            }
        }

        // Met a jour tous les Systemes.
        internal void OnUpdate() {
            foreach (ClodoBehaviour updateSystem in systemCollection) {
                updateSystem.OnUpdate();
            }
        }

    }
}