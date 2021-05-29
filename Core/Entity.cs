using System.Collections.Generic;
using System;

namespace AlizeeEngine {
    public class Entity {

        private Dictionary<Type, Object> components;
        private Dictionary<Type, Object>.KeyCollection keys;

        internal Entity() {
            this.components = new Dictionary<Type, Object>();
        }

        internal void Add(Type type, Object component) {
            if (!components.ContainsKey(type))
                components.Add(type, component);
        }

        internal void AllKeys(Action<Type> action) {
            keys = components.Keys;
            foreach (Type key in keys) {
                action(key);
            }
        }

        internal bool Contains<T>() {
            return components.ContainsKey(typeof(T));
        }

        internal bool Contains(Type type) {
            return components.ContainsKey(type);
        }

        internal T Get<T>() {
            return (T) components[typeof(T)];
        }

        public Object Get(Type type) {
            return components[type];
        }

        internal void RemoveAll() {
            components.Clear();
        }

        internal void Remove(Type type) {
            if (components.ContainsKey(type))
                components.Remove(type);
        }

        internal void Get<T0>(out T0 component) {
            component = (T0) components[typeof(T0)];
        }

        internal void Get<T0, T1>(out T0 component0, out T1 component1) {
            component0 = (T0) components[typeof(T0)];
            component1 = (T1) components[typeof(T1)];
        }

        internal void Get<T0, T1, T2>(out T0 component0, out T1 component1, out T2 component2) {
            component0 = (T0) components[typeof(T0)];
            component1 = (T1) components[typeof(T1)];
            component2 = (T2) components[typeof(T2)];
        }

        internal void Get<T0, T1, T2, T3>(out T0 component0, out T1 component1, out T2 component2, out T3 component3) {
            component0 = (T0) components[typeof(T0)];
            component1 = (T1) components[typeof(T1)];
            component2 = (T2) components[typeof(T2)];
            component3 = (T3) components[typeof(T3)];
        }

        internal void Get<T0, T1, T2, T3, T4>(out T0 component0, out T1 component1, out T2 component2, out T3 component3, out T4 component4) {
            component0 = (T0) components[typeof(T0)];
            component1 = (T1) components[typeof(T1)];
            component2 = (T2) components[typeof(T2)];
            component3 = (T3) components[typeof(T3)];
            component4 = (T4) components[typeof(T4)];
        }

    }
}