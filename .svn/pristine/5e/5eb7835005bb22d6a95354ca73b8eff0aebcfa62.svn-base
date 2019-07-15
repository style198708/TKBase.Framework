namespace TKBase.Framework.Extension
{
    public static class BoolExtension
    {
        public static bool ToBoolean(this int? s)
        {
            return s == null ? false : ToBoolean(s.Value);
        }
        public static bool ToBoolean(this int s)
        {
            return s == 1 ? true : false;
        }

        public static bool And(this bool flag, bool and)
        {
            return flag && and;
        }
        public static bool Or(this bool flag, bool or)
        {
            return flag || or;
        }
        public static bool IntOr(this bool flag, int? or)
        {
            return flag || !or.HasValue;
        }
        public static bool DecimalOr(this bool flag, decimal? or)
        {
            return flag || !or.HasValue;
        }
        public static bool StringOr(this bool flag, string or)
        {
            return flag || string.IsNullOrEmpty(or);
        }
     
    }
}
