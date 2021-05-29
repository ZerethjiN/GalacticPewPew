using System.Collections.Generic;
using System;

namespace AlizeeEngine {

    public struct QueryDesc {
        public bool Filter;
        public bool Without;
        public Type Type;
    }

    public class Query {

        internal World world;

        private List<ListEntity> entities = new List<ListEntity>();
        private List<List<QueryDesc>> queriesDesc = new List<List<QueryDesc>>();
        private int currentQuery = 0;

        public ListEntity this[int i] {
            get => entities[i];
        }

        public Query AddQuery() {
            currentQuery = queriesDesc.Count;
            queriesDesc.Add(new List<QueryDesc>());
            return this;
        }

        public Query Filter<T>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T), Filter = true, Without = false });
            return this;
        }

        public Query Filter<T1, T2>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Filter = true, Without = false });
            return this;
        }

        public Query Filter<T1, T2, T3>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Filter = true, Without = false });
            return this;
        }

        public Query Filter<T1, T2, T3, T4>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T4), Filter = true, Without = false });
            return this;
        }

        public Query Filter<T1, T2, T3, T4, T5>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T4), Filter = true, Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T5), Filter = true, Without = false });
            return this;
        }

        public Query With<T>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T), Without = false });
            return this;
        }

        public Query With<T1, T2>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = false });
            return this;
        }

        public Query With<T1, T2, T3>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Without = false });
            return this;
        }

        public Query With<T1, T2, T3, T4>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Without = false});
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T4), Without = false});
            return this;
        }

        public Query With<T1, T2, T3, T4, T5>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T4), Without = false });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T5), Without = false });
            return this;
        }

        public Query Without<T>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T), Without = true });
            return this;
        }

        public Query Without<T1, T2>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = true });
            return this;
        }

        public Query Without<T1, T2, T3>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Without = true });
            return this;
        }

        public Query Without<T1, T2, T3, T4>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T4), Without = true });
            return this;
        }

        public Query Without<T1, T2, T3, T4, T5>() {
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T1), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T2), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T3), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T4), Without = true });
            queriesDesc[currentQuery].Add(new QueryDesc { Type = typeof(T5), Without = true });
            return this;
        }

        internal void GetQuery() {
            bool entityAffect;
            ListEntity currentEntities;

            entities.Clear();

            queriesDesc.ForEach(queries => {
                currentEntities = new ListEntity();
                entities.Add(currentEntities);

                world.Entities.ForEach(ent => {
                    entityAffect = true;

                    queries.ForEach(query => {
                        if (!ent.Contains(query.Type) && !query.Without)
                            entityAffect = false;
                        else if (ent.Contains(query.Type) && query.Without)
                            entityAffect = false;
                    });

                    if (entityAffect)
                        currentEntities.Add(ent);
                });

            });
        }

        internal void GetQuery(List<Type> types) {
            bool entityAffect;
            ListEntity currentEntities;

            bool sameQuery = false;

            foreach(Type type in types) {
                foreach(List<QueryDesc> queries in queriesDesc) {
                    foreach(QueryDesc query in queries) {
                        if (query.Type == type) {
                            sameQuery = true;
                            break;
                        }
                    }
                    if (sameQuery)
                        break;
                }
                if (sameQuery)
                    break;
            }

            if (!sameQuery)
                return;

            entities.Clear();

            queriesDesc.ForEach(queries => {
                currentEntities = new ListEntity();
                entities.Add(currentEntities);

                world.Entities.ForEach(ent => {
                    entityAffect = true;

                    queries.ForEach(query => {
                        if (!ent.Contains(query.Type) && !query.Without)
                            entityAffect = false;
                        else if (ent.Contains(query.Type) && query.Without)
                            entityAffect = false;
                    });

                    if (entityAffect)
                        currentEntities.Add(ent);
                });

            });
        }

    }
}