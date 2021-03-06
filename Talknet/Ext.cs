using System.Collections.Generic;

namespace Talknet {
    internal static class Ext {
        internal static IEnumerable<T> Take<T>(this IEnumerable<T> src, int from, int count) {
            var en = src.GetEnumerator();

            for (var i = 0; i < from; ++i) {
                if (en.MoveNext()) continue;

                en.Dispose();
                yield break;
            }

            for (var i = 0; i < count; ++i) {
                if (!en.MoveNext()) {
                    en.Dispose();
                    yield break;
                }

                yield return en.Current;
            }
        }

        internal static IEnumerable<T> AllExceptLastOne<T>(this IEnumerable<T> src) {
            var en = src.GetEnumerator();

            T cachea, cacheb;
            if (en.MoveNext()) cachea = en.Current; else { en.Dispose(); yield break; }
            if (en.MoveNext()) cacheb = en.Current; else { en.Dispose(); yield break; }

            while (en.MoveNext()) {
                yield return cachea;
                cachea = cacheb;
                cacheb = en.Current;
            }

            en.Dispose();
            yield return cachea;
        }

        internal static bool IsValidInteger(string v, out int x) {
            x = 0;
            if (int.TryParse(v, out int y)) {
                if (y != 0 && v[0] == '0') return false;
                x = y;
                return true;
            }

            return false;
        }

        internal static string JoinBy(this IEnumerable<string> arr, string separator) => string.Join(separator, arr);
    }
}
