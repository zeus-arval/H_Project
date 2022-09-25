namespace Backend.Data.Common
{
    public abstract class BaseEntity 
    {
        public static string Unspecified => nameof(Unspecified);
        public static DateTime UnspecifiedDateTime => DateTime.MinValue;
        public static double UnspecifiedDouble => double.NaN;
        public static decimal UnspecifiedDecimal => decimal.MinValue;
        public static int UnspecifiedInteger => int.MinValue;
        public static bool UnspecifiedBoolean => false;
        public static Guid UnspecifiedGuid => Guid.Empty;
        protected internal static bool isUnspecified(string s)
                    => string.IsNullOrWhiteSpace(s) || s.Trim() == Unspecified;
    }
}