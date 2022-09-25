using Backend.Aids.Methods;
using Backend.Data.Common;
using System;

namespace Backend.Domain.Common {
    public abstract class ValueObject<TData> :BaseEntity where TData : class, new() {

        protected internal readonly TData data;
        protected internal ValueObject(TData d = null) => data = d ?? new TData();
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