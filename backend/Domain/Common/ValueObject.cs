using Backend.Aids.Methods;
using Backend.Data.Common;
using System;

namespace Backend.Domain.Common {
    public abstract class ValueObject<TData> :BaseEntity where TData : class, new() {

        protected internal readonly TData data;
        protected internal ValueObject(TData d = null) => data = d ?? new TData();
        public bool IsUnspecified => isUnspecified();
        private bool isUnspecified()
            => data is null || arePropertiesEqual(data, new TData());
        private static bool arePropertiesEqual(TData a, TData b) {
            foreach (var property in a.GetType().GetProperties()) {
                var name = property.Name;
                var p = b.GetType().GetProperty(name);

                if (p is null) return false;
                var expected = property.GetValue(a);
                var actual = p.GetValue(b);
                switch (expected) {
                    case null when (actual is null):
                        continue;
                    case null:
                        return false;
                }

                if (!expected.Equals(actual)) return false;
            }

            return true;
        }
        public TData Data {
            get {
                if (data is null) return null;
                var d = new TData();
                Copy.Members(data, d);
                return d;
            }
        }
    }
}