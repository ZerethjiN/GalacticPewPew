using System.Collections.Generic;
using System;

namespace AlizeeEngine {
    public class ListEntity {

        public List<Entity> entities { get; internal set; }

        private List<Type> filterTypeList;
        private List<Type> withoutTypeList;

        private bool allIsNotHere;

        internal ListEntity() {
            entities = new List<Entity>();
            filterTypeList = new List<Type>();
            withoutTypeList = new List<Type>();
        }

        public int Count {
            get => entities.Count;
        }

        internal void Add(Entity entity) {
            entities.Add(entity);
        }

        internal void RemoveAll() {
            entities.Clear();
        }

        internal void Remove(Entity entity) {
            entities.Remove(entity);
        }

        public void ForEach(Action<Entity> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere)
                    action(entity);
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0>(Action<Entity, T0> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>()) {
                    entity.Get(out T0 t0);
                    action(entity, t0);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1>(Action<Entity, T0, T1> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>()) {
                    entity.Get(out T0 t0, out T1 t1);
                    action(entity, t0, t1);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1, T2>(Action<Entity, T0, T1, T2> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>() && entity.Contains<T2>()) {
                    entity.Get(out T0 t0, out T1 t1, out T2 t2);
                    action(entity, t0, t1, t2);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1, T2, T3>(Action<Entity, T0, T1, T2, T3> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>() && entity.Contains<T2>() && entity.Contains<T3>()) {
                    entity.Get(out T0 t0, out T1 t1, out T2 t2, out T3 t3);
                    action(entity, t0, t1, t2, t3);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1, T2, T3, T4>(Action<Entity, T0, T1, T2, T3, T4> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>() && entity.Contains<T2>() && entity.Contains<T3>() && entity.Contains<T4>()) {
                    entity.Get(out T0 t0, out T1 t1, out T2 t2, out T3 t3, out T4 t4);
                    action(entity, t0, t1, t2, t3, t4);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0>(Action<T0> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>()) {
                    entity.Get(out T0 t0);
                    action(t0);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1>(Action<T0, T1> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>()) {
                    entity.Get(out T0 t0, out T1 t1);
                    action(t0, t1);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1, T2>(Action<T0, T1, T2> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>() && entity.Contains<T2>()) {
                    entity.Get(out T0 t0, out T1 t1, out T2 t2);
                    action(t0, t1, t2);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1, T2, T3>(Action<T0, T1, T2, T3> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>() && entity.Contains<T2>() && entity.Contains<T3>()) {
                    entity.Get(out T0 t0, out T1 t1, out T2 t2, out T3 t3);
                    action(t0, t1, t2, t3);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public void ForEach<T0, T1, T2, T3, T4>(Action<T0, T1, T2, T3, T4> action) {
            foreach (Entity entity in entities) {
                allIsNotHere = false;
                foreach (Type type in filterTypeList) {
                    if (!entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                foreach (Type type in withoutTypeList) {
                    if (entity.Contains(type)) {
                        allIsNotHere = true;
                    }
                }
                if (!allIsNotHere && entity.Contains<T0>() && entity.Contains<T1>() && entity.Contains<T2>() && entity.Contains<T3>() && entity.Contains<T4>()) {
                    entity.Get(out T0 t0, out T1 t1, out T2 t2, out T3 t3, out T4 t4);
                    action(t0, t1, t2, t3, t4);
                }
            }
            filterTypeList.Clear();
            withoutTypeList.Clear();
        }

        public ListEntity Filter<T0>() {
            filterTypeList.Add(typeof(T0));
            return this;
        }

        public ListEntity Filter<T0, T1>() {
            filterTypeList.Add(typeof(T0));
            filterTypeList.Add(typeof(T1));
            return this;
        }

        public ListEntity Filter<T0, T1, T2>() {
            filterTypeList.Add(typeof(T0));
            filterTypeList.Add(typeof(T1));
            filterTypeList.Add(typeof(T2));
            return this;
        }

        public ListEntity Filter<T0, T1, T2, T3>() {
            filterTypeList.Add(typeof(T0));
            filterTypeList.Add(typeof(T1));
            filterTypeList.Add(typeof(T2));
            filterTypeList.Add(typeof(T3));
            return this;
        }

        public ListEntity Filter<T0, T1, T2, T3, T4>() {
            filterTypeList.Add(typeof(T0));
            filterTypeList.Add(typeof(T1));
            filterTypeList.Add(typeof(T2));
            filterTypeList.Add(typeof(T3));
            filterTypeList.Add(typeof(T4));
            return this;
        }

        public ListEntity Without<T0>() {
            withoutTypeList.Add(typeof(T0));
            return this;
        }

        public ListEntity Without<T0, T1>() {
            withoutTypeList.Add(typeof(T0));
            withoutTypeList.Add(typeof(T1));
            return this;
        }

        public ListEntity Without<T0, T1, T2>() {
            withoutTypeList.Add(typeof(T0));
            withoutTypeList.Add(typeof(T1));
            withoutTypeList.Add(typeof(T2));
            return this;
        }

        public ListEntity Without<T0, T1, T2, T3>() {
            withoutTypeList.Add(typeof(T0));
            withoutTypeList.Add(typeof(T1));
            withoutTypeList.Add(typeof(T2));
            withoutTypeList.Add(typeof(T3));
            return this;
        }

        public ListEntity Without<T0, T1, T2, T3, T4>() {
            withoutTypeList.Add(typeof(T0));
            withoutTypeList.Add(typeof(T1));
            withoutTypeList.Add(typeof(T2));
            withoutTypeList.Add(typeof(T3));
            withoutTypeList.Add(typeof(T4));
            return this;
        }

        public int TotalOf<T>() {
            int total = 0;
            foreach (Entity entity in entities) {
                if (entity.Contains<T>())
                    total++;
            }
            return total;
        }

    }
}