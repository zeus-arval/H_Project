using System;

namespace Backend.Aids.Methods {
    public static class Safe {
        private static readonly object key = new object();
        public static T Run<T>(Func<T> function, T valueOnExeption,
            bool useLock = false) => useLock
                ? lockedRun(function, valueOnExeption)
                : run(function, valueOnExeption);
        public static T Run<T>(Func<T> function, Func<string, T> valueOnExeption,
            bool useLock = false) => useLock
                ? lockedRun(function, valueOnExeption)
                : run(function, valueOnExeption);
        public static void Run(Action action, bool useLock = false) {
            if (useLock) lockedRun(action);
            else run(action);
        }
        private static T lockedRun<T>(Func<T> function, T valueOnExeption) {
            lock (key) { return run(function, valueOnExeption); }
        }
        private static T lockedRun<T>(Func<T> function, Func<string, T> valueOnExeption) {
            lock (key) { return run(function, valueOnExeption); }
        }
        private static void lockedRun(Action action) {
            lock (key) { run(action); }
        }
        private static T run<T>(Func<T> function, T valueOnExeption) {
            try { return function(); } catch (Exception) {

                return valueOnExeption;
            }
        }
        private static T run<T>(Func<T> function, Func<string, T> valueOnExeption) {
            try { return function(); } catch (Exception e) {

                return valueOnExeption is null ? default : valueOnExeption(e.Message);
            }
        }
        private static void run(Action action) {
            try { action(); } catch (Exception) { }
        }
    }
}