using System.Text;

namespace BackofficeTools
{
    public static class StringBuilderHelper
    {
        public static StringBuilder TrimEnd(this StringBuilder sb)
        {
            if (sb == null || sb.Length == 0) return sb;

            int i = sb.Length - 1;

            for (; i >= 0; i--)
                if (!char.IsWhiteSpace(sb[i]))
                    break;

            if (i < sb.Length - 1)
                sb.Length = i + 1;

            return sb;
        }

        public static StringBuilder TrimEnd(this StringBuilder sb, char chr)
        {
            if (sb == null || sb.Length == 0) return sb;

            int i = sb.Length - 1;

            for (; i >= 0; i--)
                if (chr == sb[i])
                    break;

            if (i < sb.Length - 1)
                sb.Length = i + 1;

            return sb;
        }
    }
}
