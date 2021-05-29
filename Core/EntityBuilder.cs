using System.Collections.Generic;
using System;

namespace AlizeeEngine {
    public class EntityBuilder {

        private World World;
        private List<Object> components;
        private Entity entity;

        public EntityBuilder(World world) {
            this.World = world;
            this.components = new List<Object>();
        }

        public EntityBuilder CreateEntity() {
            entity = new Entity();
            components.Clear();
            return this;
        }

        public EntityBuilder With(Object component) {
            components.Add(component);
            return this;
        }

        public Entity Build() {
            World.Entities.Add(entity);
            for (int i = 0; i < components.Count; i++)
                entity.Add(components[i].GetType(), components[i]);
            return entity;
        }

    }
}