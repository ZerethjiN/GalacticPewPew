/*
using System.Collections.Generic;
using System;

namespace AlizeeEngine {
    public class Archetype {
        public Type Type;
        public List<Entity> entities;
        public List<Archetype> edges;

        public Archetype(Type type) {
            Type = type;
            entities = new List<Entity>();
        }
    }

    public class ArchetypeCollections {
        public List<Archetype> archetypes;

        public ArchetypeCollections() {
            archetypes = new List<Archetype>();
        }

        public void Add(Entity entity) {
            bool isTypeFound = false;
            bool isTotallyFound = true;
            Archetype archFound = null;

            entity.AllKeys( key => {
                isTypeFound = false;

                if (archFound == null) {
                    foreach (Archetype archetype in archetypes) {

                        if (archetype.Type == key) {
                            archFound = archetype;
                            isTypeFound = true;
                            break;
                        }

                    }
                }

                else {
                    foreach (Archetype archetype in archFound.edges) {
                        if (archetype.Type == key) {
                            archFound = archetype;
                            isTypeFound = true;
                            break;
                        }
                    }
                }

                if (!isTypeFound)
                    isTotallyFound = false;

            });
        }
    }
}
*/