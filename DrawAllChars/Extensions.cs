using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Globalization;
using System.Drawing;
using System.Media;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Serialization;


#pragma warning disable 1591

public static class StringExtensions
{
    public static byte[] ToByteArray(this string hex, string chunk = ",")
    {
        return ToEnumerableByte(hex, chunk).ToArray();
    }
    public static List<byte> ToByteList(this string hex, string chunk = ",")
    {
        return ToEnumerableByte(hex, chunk).ToList();
    }
    public static IEnumerable<byte> ToEnumerableByte(this string hex, string chunk)
    {
        hex = hex.Replace(chunk, "");
#if DEBUG
        if(hex.Length % 2 != 0)
            Debug.WriteLine($"奇数文字数:{hex.Length}bytes");
        if ((IsHexNumbers(hex)==false))
            Debug.WriteLine($"不正文字列:{hex}");
#endif

        return Enumerable.Range(0, hex.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16));
    }
    public static byte[] ToByteArrayWithPad(this string hex, string chunk = ",")
    {
        if (hex.Length % 2 != 0)
            hex = "0" + hex;
        return ToEnumerableByte(hex, chunk).ToArray();
    }

    public static string Left(this string s, int count)
    {
        return s.Substring(0, count);
    }

    public static string Right(this string s, int count)
    {
        return s.Substring(s.Length - count, count);
    }
    public static string RemoveRight(this string s, int count)
    {
        return s.Remove(s.Length - count, count);
    }

    public static int ToInteger(this string s)
    {
        int integerValue = 0;
        int.TryParse(s, out integerValue);
        return integerValue;
    }
    public static Int64 ToInteger64(this string s)
    {
        Int64 integerValue = 0;
        Int64.TryParse(s, out integerValue);
        return integerValue;
    }
    public static bool IsInteger(this string s)
    {
        Regex regularExpression = new Regex("^-[0-9]+$|^[0-9]+$");
        return regularExpression.Match(s).Success;
    }
    public static float ToFloat(this string s)
    {
        float floatValue = 0;
        float.TryParse(s, out floatValue);
        return floatValue;
    }

    public static string RemoveAll(this string str, params string[] words)
    {
        string ret = str;
        words.ToList().ForEach(x => ret =ret.Replace(x,""));
        return ret;
    }
    public static bool AnyLike(this string s1, params string[] ss)
    {
        return ss.Any(x => x.IndexOf(s1) > -1);
    }

    public static string RegReplace(this string str ,string ptn,string rep,bool Ignore=true)
    {
        RegexOptions opt;
        if(Ignore)
        {
            opt= RegexOptions.IgnoreCase;
        }
        else
        {
            opt = RegexOptions.None;
        }
        return Regex.Replace(str,ptn,rep, opt);
    }
    public static int LenB(this string str)
    {
        return Encoding.GetEncoding("Shift_JIS").GetByteCount(str);
    }
    public static string LeftB(this string s, int count)
    {
        return MidB(s, 0, count);
    }
    public static string MidB(this string str, int iStart, int iByteSize)
    {
        System.Text.Encoding hEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
        byte[] btBytes = hEncoding.GetBytes(str);

        return hEncoding.GetString(btBytes, iStart , iByteSize);
    }
    public static string SubstringB(this string str, int iStart)
    {
        System.Text.Encoding hEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
        byte[] btBytes = hEncoding.GetBytes(str);

        return hEncoding.GetString(btBytes, iStart, btBytes.Length - iStart );
    }
    public static string Replace1(this string str,char oldChar, char newChar)
    {
        StringBuilder sb = new StringBuilder(str);
        sb[str.IndexOf(oldChar)] = newChar;
        return  sb.ToString();
    }
    public static string InsertSlashToYYYYMMDD(this string str)
    {
        return str.Left(4) + "/" + str.Substring(4, 2) + "/" + str.Right(2);

    }
    public static string Separate(this string str,int length,bool trim=true,string SeparateChar =",")
    {
        str = str.Trim();
        if (str.Length <= length)
            return SeparateChar+str;
        else
        {
            return str.Left(length) + SeparateChar + str.Substring(length);
        }
    }
    public static IEnumerable<string> Split(this string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
    public static string InsertChunkChar(this string str,string chunkChar=",")
    {
        return string.Join(chunkChar, str.Split(2));
    }
    public static string Repeat(this string str,int count)
    {
        return string.Concat(Enumerable.Repeat(str, count));
    }
    public static string RemoveNonHexNumbers(this string str)
    {
        return Regex.Replace(str, @"[^A-F0-9\r\n]", "");
    }
    public static bool IsHexNumbers(this string str)
    {
        return Regex.IsMatch(str.Replace(",",""),@"\A\b[0-9a-fA-F]+\b\Z");
    }
    public static bool IsNumbers(this string s)
    {
        return s.Where(x=>Char.IsWhiteSpace(x)==false).All(x=> Char.IsDigit(x));
    }
    public static Int16 HexToInt16(this string str)
    {
        Int16 i;
        Int16.TryParse(str, NumberStyles.AllowHexSpecifier, NumberFormatInfo.CurrentInfo, out i);
        return i;
    }
    public static byte[] ConvertLEArray(this string str)
    {
        return str.ToByteArray().Reverse<byte>().ToArray();
    }
    public static string ConvertLEArrayList(this string str)
    {
        return string.Join("",str.Split(4).Select(x=>x.ConvertLEArray().ToHexString()));
    }
    public static string GetRelativePath(this string filespec, string folder)
    {
        if(filespec.Equals(folder,StringComparison.OrdinalIgnoreCase))
            return @".\";
        Uri pathUri = new Uri(filespec);
        // Folders must end in a slash
        if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
        {
            folder += Path.DirectorySeparatorChar;
        }
        Uri folderUri = new Uri(folder);
        return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
    }
    public static DateTime ParseToDateTime(this string str)
    {
        DateTime.TryParse(str, out var result);
        return result;
    }
}//string

public static class Extensions
{
    public static string ToHexString(this byte[] bytes)
    {
        if (bytes == null)
            return "";
        return BitConverter.ToString(bytes).Replace("-", "");
    }
    public static string ToHexString(this IEnumerable<byte> bytes)
    {
        if (bytes == null)
            return "";
        return ToHexString(bytes.ToArray());
    }
    public static List<string> ShortToHexStringList(this byte[] bytes)
    {
        return Enumerable.Range(0, bytes.Length).Where(x => x % 2 == 0).Select(x => BitConverter.ToInt16(bytes, x).ToString("X4")).ToList();
    }

    public static T Copy<T>(this T target) 
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream stream = new MemoryStream())
        {
            binaryFormatter.Serialize(stream, target);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)binaryFormatter.Deserialize(stream);
        }
    }
    public static DataSet ToDataSet<T>(this IList<T> list)
    {
        Type elementType = typeof(T);
        DataSet ds = new DataSet();
        DataTable t = new DataTable();
        ds.Tables.Add(t);

        //add a column to table for each public property on T
        foreach (var propInfo in elementType.GetProperties())
        {
            Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

            t.Columns.Add(propInfo.Name, ColType);
        }

        //go through each property on T and add each value to the table
        foreach (T item in list)
        {
            DataRow row = t.NewRow();

            foreach (var propInfo in elementType.GetProperties())
            {
                row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
            }

            t.Rows.Add(row);
        }

        return ds;
    }
    public static List<T> ToList<T>(this DataTable table) where T : new()
    {
        IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
        List<T> result = new List<T>();

        foreach (var row in table.Rows)
        {
            var item = CreateItemFromRow<T>((DataRow)row, properties);
            result.Add(item);
        }

        return result;
    }

    private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
    {
        T item = new T();
        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(System.DayOfWeek))
            {
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                property.SetValue(item, day, null);
            }
            else
            {
                property.SetValue(item, row[property.Name], null);
            }
        }
        return item;
    }
    public static DataRow FindFirstRow(this DataTable dt,DataRow row,string ColName)
    {
        return dt.AsEnumerable().FirstOrDefault(x => x[ColName].ToString() == row[ColName].ToString());
    }
    public static List<string> reverseStringFormat(string template, string str)
    {
        string pattern = "^" + Regex.Replace(template, @"\{[0-9]+\}", "(.*?)") + "$";

        Regex r = new Regex(pattern);
        Match m = r.Match(str);

        List<string> ret = new List<string>();

        for (int i = 1; i < m.Groups.Count; i++)
        {
            ret.Add(m.Groups[i].Value);
        }

        return ret;
    }
    public static List<string> GetBraces(string str)
    {
        var grp = Regex.Match(str, @"\{([^)]*)\}").Groups;
        return grp.Cast<Group>().Select(x => x.Value.Replace("{", "").Replace("}", "")).ToList();
    }
    public static List<String> GetTokens(string str = "")
    {
        if (string.IsNullOrEmpty(str))
        {
            return new List<string>();
        }
        Regex regex = new Regex(@"(?<=\{)[^}]*(?=\})", RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(str);

        // Results include braces (undesirable)
        return matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();
    }
    public static List<String> SplitCurlyBraces(this string str)
    {
        Regex regex = new Regex(@"{[^}]*}|[^{}]+", RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(str);

        return matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();
    }
    public static string GetMemberName<MemberType>(Expression<Func<MemberType>> expression)
    {
        return ((MemberExpression)expression.Body).Member.Name;
    }
    public static bool ContainsLike(this IEnumerable<string> ss, string s1)
    {
        foreach (string q in ss)
        {
            if (s1.IndexOf(q) > -1) return true;
        }
        return false;
    }
    public static bool In<T>(this T obj, params T[] ary)
    {// like a sql in.
        return ary.Contains(obj);
    }
    public static bool In<T>(this T obj, IEnumerable<T> ary)
    {// like a sql in.
        return ary.Contains(obj);
    }
    public static int RowIndex(this DataRow row, DataTable dt)
    {
        return dt.Rows.IndexOf(row);
    }
    public static int RowIndex(this DataRow row)
    {
        return row.Table.Rows.IndexOf(row);
    }

    public static bool isBetween<T>(this T current, T lower, T higher, bool inclusive = true) where T : IComparable
    {
        if (lower.CompareTo(higher) > 0) Swap(ref lower, ref higher);

        return inclusive ?
            (lower.CompareTo(current) <= 0 && current.CompareTo(higher) <= 0) :
            (lower.CompareTo(current) < 0 && current.CompareTo(higher) < 0);
    }
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    public static T[] Repeat<T>(this T obj, int count)
    {
        return Enumerable.Repeat(obj, count).ToArray();
    }
    public static bool SetProperty(this object target,string name,object value)
    {
        Type type = target.GetType();

        PropertyInfo prop = type.GetProperty(name);
        if (prop == null)
        {
            Trace.WriteLine("プロパティ " + name + "が存在しません。");
            return false;
        }
        if(prop.CanWrite==false)
        {
            Trace.WriteLine("プロパティ " + name + "は書き込めません。");
            return false;
        }
        prop.SetValue(target, value, null);
        return true;
    }
    public static object GetProperty(this object target, string name)
    {
        Type type = target.GetType();

        PropertyInfo prop = type.GetProperty(name);
        if (prop == null)
            return null;
        return prop.GetValue(target);
    }

    public static Type GetPropertyType(this object target, string name)
    {
        Type type = target.GetType();

        PropertyInfo prop = type.GetProperty(name);
        if (prop == null)
            return null;
        return prop.PropertyType;
    }
    public static Type FindAssignableType<T>(this Assembly asm)
    {
        return (from type in asm.GetTypes()
                where type.IsClass && typeof(T).IsAssignableFrom(type)
                select type).FirstOrDefault();
    }
    // -----XOR ----------------------------------------------------------
    public static byte[] xor_key(this byte[] a, byte[] b, int Length = 8)
    {
        return Enumerable.Range(0, Length).Select(n => (byte)(a[n] ^ b[n])).ToArray();
    }
    public static byte[] xor_key(this byte[] a, IEnumerable<byte> b, int Length = 8)
    {
        return xor_key(a, b.ToArray(), Length);
    }
    public static byte[] not_key(this IEnumerable<byte> src)
    {
        return src.Select(x => (byte)~x).ToArray();
    }
    static Random rnd = new Random();
    public static byte[] GetRandomArray(this byte[] array)
    {
        //Random rnd = new Random();
        return Enumerable.Range(0, array.Length).Select(n => (byte)(rnd.Next())).ToArray();
    }
    public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
        return list;
    }
    public static bool IsOverride(this MethodInfo method)
    {
        return !method.Equals(method.GetBaseDefinition());
    }
    //public static Dictionary<string, object>[] ToDictionaryArray(this PropertiesBase[] blocks)
    //{
    //    return blocks.Select(x => x.ToDictionary()).ToArray();
    //}
    public static void trace(this Exception e)
    {
        Trace.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ") + e.GetType().ToString() + " \"" + e.Message + "\"" + Environment.NewLine + e.StackTrace);
    }
    /// <summary>
    /// Gets the safe value associated with the specified key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key of the value to get.</param>
    public static TValue GetSafeValue<TKey, TValue>(this Dictionary<TKey,
                         TValue> dictionary, TKey key)
    {
        return dictionary.GetSafeValue(key, default(TValue));
    }

    /// <summary>
    /// Gets the safe value associated with the specified key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key of the value to get.</param>
    /// <param name="defaultValue">The default value.</param>
    public static TValue GetSafeValue<TKey, TValue>(this Dictionary<TKey,
           TValue> dictionary, TKey key, TValue defaultValue)
    {
        TValue result;
        if (key == null || !dictionary.TryGetValue(key, out result))
            result = defaultValue;
        return result;
    }
    public static T ToEnum<T>(this ValueType val) where T: struct,IConvertible
    {
        return (T)Enum.ToObject(typeof(T),val);
    }
    public static T ToEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value);
    }
    public static int ToInt(this Enum val)
    {
        return Convert.ToInt32(val);
    }
    public static Point ToPoint(this PointF p)
    {
        return Point.Round(p);
    }
    public static Rectangle ToRectangle(this RectangleF rc)
    {
        return Rectangle.Round(rc);
    }
    public static int RoundToInt(this float f)
    {
        return (int)Math.Round(f, 0);
    }
    public static void IncrementHead(this byte[] IDtr)
    {
        UInt16 Snr = BitConverter.ToUInt16(IDtr, 0);
        Snr ++;
        Array.Copy(BitConverter.GetBytes(Snr), IDtr, 2);
    }
    public static string ConvertToX4(this IEnumerable<byte> bytes)
    {
        return BitConverter.ToInt16(bytes.Take(2).ToArray(), 0).ToString("X4");
    }
    public static string ConvertToX8(this IEnumerable<byte> bytes)
    {
        return BitConverter.ToInt32(bytes.Take(4).ToArray(), 0).ToString("X8");
    }
    public static byte[] Padding(this IEnumerable<byte> bytes,int padcount=8)
    {
        if (bytes.Count() % padcount == 0)
            return bytes.ToArray();

        int count = padcount - bytes.Count() % padcount;
        return bytes.Concat(new byte[count]).ToArray();
    }
    public static void AddPadding(this List<byte> lst, int padcount = 8)
    {
        if (lst.Count() % padcount == 0)
            return;

        int count = padcount - lst.Count() % padcount;
        lst.AddRange(new byte[count]);
    }
    public static decimal CountDigit(this decimal number)
    {
        if (number == 0)
            return 1;
        return (decimal)Math.Log10((double)number) + 1;
    }
    public static double ToRoundDown(this double dValue, int iDigits)
    {
        double dCoef = System.Math.Pow(10, iDigits);

        return dValue > 0 ? System.Math.Floor(dValue * dCoef) / dCoef :
                            System.Math.Ceiling(dValue * dCoef) / dCoef;
    }
    public static IEnumerable<T> GetAll<T>(this Control control)
    {
        var controls = control.Controls.Cast<Control>();

        return controls.SelectMany(ctrl => GetAll<T>(ctrl))
                                   .Concat(controls.OfType<T>());
    }
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    private static Random rng = new Random();

    public static string PathWithoutRoot(this string path)
    {
        return path.Substring(Path.GetPathRoot(path).Length);
    }
    private const int WM_SETREDRAW = 0x000B;

    public static void Suspend(this Control control)
    {
        Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

        NativeWindow window = NativeWindow.FromHandle(control.Handle);
        window.DefWndProc(ref msgSuspendUpdate);
    }

    public static void Resume(this Control control)
    {
        IntPtr wparam = new IntPtr(1);
        Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam, IntPtr.Zero);

        NativeWindow window = NativeWindow.FromHandle(control.Handle);
        window.DefWndProc(ref msgResumeUpdate);

        control.Invalidate();
        control.Refresh();
    }
    public static bool IsDesignMode(this Control ctrl)
    {
        bool returnFlag = false;
        if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            returnFlag = true;
        else if (Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV")
            || Process.GetCurrentProcess().ProcessName.ToUpper().Equals("VCSEXPRESS"))
            returnFlag = true;
        //else if (AppDomain.CurrentDomain.FriendlyName == "DefaultDomain")
        //    returnFlag = true;
        return returnFlag;
    }
    public static T GetAttribute<T>(this object target, string name) where T:Attribute
    {
        Type type = target.GetType();

        PropertyInfo prop = type.GetProperty(name);
        if (prop == null)
            return null;
        return prop.GetCustomAttribute(typeof(T)) as T;
    }
    public static bool IsZenkaku(this char c)
    {
        return c.isBetween((char)0x01, (char)0x7E) == false &&
               c.isBetween((char)0xFF61, (char)0xFF9F) == false;
    }
    public static bool IsHankaku(this char c)
    {
        return c.IsZenkaku() == false;
    }
    /// <summary>
    /// 外字判定(unicode)
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool IsGaiji(this char c)
    {
        return c.isBetween('\uE000', '\uE757');
    }
    #region obsolete
    public static bool IsHankakuKana(this char c)
    {
        return c.isBetween('\uFF65', '\uFF9F');
    }
    public static Dictionary<char, char> HanZenTable = new Dictionary<char, char>()
    {
        { 'ｱ', 'ア' }, { 'ｲ', 'イ' }, { 'ｳ', 'ウ' }, { 'ｴ', 'エ' }, { 'ｵ', 'オ' },
        { 'ｶ', 'カ' }, { 'ｷ', 'キ' }, { 'ｸ', 'ク' }, { 'ｹ', 'ケ' }, { 'ｺ', 'コ' },
        { 'ｻ', 'サ' }, { 'ｼ', 'シ' }, { 'ｽ', 'ス' }, { 'ｾ', 'セ' }, { 'ｿ', 'ソ' },
        { 'ﾀ', 'タ' }, { 'ﾁ', 'チ' }, { 'ﾂ', 'ツ' }, { 'ﾃ', 'テ' }, { 'ﾄ', 'ト' },
        { 'ﾅ', 'ナ' }, { 'ﾆ', 'ニ' }, { 'ﾇ', 'ヌ' }, { 'ﾈ', 'ネ' }, { 'ﾉ', 'ノ' },
        { 'ﾊ', 'ハ' }, { 'ﾋ', 'ヒ' }, { 'ﾌ', 'フ' }, { 'ﾍ', 'ヘ' }, { 'ﾎ', 'ホ' },
        { 'ﾏ', 'マ' }, { 'ﾐ', 'ミ' }, { 'ﾑ', 'ム' }, { 'ﾒ', 'メ' }, { 'ﾓ', 'モ' },
        { 'ﾔ', 'ヤ' }, { 'ﾕ', 'ユ' }, { 'ﾖ', 'ヨ' },
        { 'ﾗ', 'ラ' }, { 'ﾘ', 'リ' }, { 'ﾙ', 'ル' }, { 'ﾚ', 'レ' }, { 'ﾛ', 'ロ' },
        { 'ﾜ', 'ワ' }, { 'ｦ', 'ヲ' }, { 'ﾝ', 'ン' },
        { 'ｧ', 'ァ' }, { 'ｨ', 'ィ' }, { 'ｩ', 'ゥ' }, { 'ｪ', 'ェ' }, { 'ｫ', 'ォ' },
        { 'ｬ', 'ャ' }, { 'ｭ', 'ュ' }, { 'ｮ', 'ョ' }, { 'ｯ', 'ッ' },
        { '｡', '。' },
        //{ '｢', '「' }, { '｣', '」' },
        { '､', '、' }, { '･', '・' },
        { 'ｰ', 'ー' }, { 'ﾞ','゛'}, { 'ﾟ','゜'}
    };
    public static char ToZenkaku(this char c)
    {
        return HanZenTable.GetSafeValue(c);
    }
    #endregion
    public static string GetEnumDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false);

        if (attributes != null &&
            attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
    public static T GetAttribute<T>(this PropertyInfo prop) where T : Attribute
    {
        return prop.GetCustomAttribute(typeof(T)) as T;
    }
    public static T[] SubArray<T>(this IEnumerable<T> data, int index, int length)
    {
        return data.ToArray().SubArray(index, length);
    }
    public static T[] SubArray<T>(this T[] data, int index, int length)
    {
        T[] arrCopy = new T[Math.Min(length, data.Length)];

        Array.Copy(data, Math.Min(index,data.Length), arrCopy, 0, Math.Max(Math.Min(length, data.Length-index),0));
        if (typeof(T).IsPrimitive)
            return arrCopy;

        using (MemoryStream ms = new MemoryStream())
        {
            var bf = new BinaryFormatter();
            bf.Serialize(ms, arrCopy);
            ms.Position = 0;
            return (T[])bf.Deserialize(ms);
        }
    }
    public static void Serialize<T>(this T obj,string FileName) where T :class
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var fs = new FileStream(FileName, FileMode.Create))
            serializer.Serialize(fs, obj);
    }
    public static string SerializeToString<T>(this T toSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (StringWriter textWriter = new StringWriter())
        {
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
    }
    public static Control GetRealActiveControl(this ContainerControl parentControl)
    {
        Control ac = parentControl.ActiveControl;
        if (ac == null)
            return parentControl;
        if (ac is ContainerControl)
            return GetRealActiveControl((ContainerControl)ac);
        return ac;
    }
    public static TextBoxBase GetActiveTextBox(this ContainerControl container)
    {
        var tb = container.ActiveControl as TextBoxBase;
        if (tb?.SelectionLength > 0)
        {
            return tb;
        }
        var nu = container.ActiveControl as NumericUpDown;
        if (nu != null)
        {
            var editProp = nu.GetType().GetField("upDownEdit", BindingFlags.Instance | BindingFlags.NonPublic);
            var edit = editProp.GetValue(nu) as TextBox;
            if (edit.SelectionLength > 0)
            {
                return edit;
            }
        }
        return null;
    }
    /// <summary>
    /// 文字列にエンコード　※読めない文字を'･'に変換しているので再度バイナリ戻す用途には使えない
    /// </summary>
    /// <param name="BlockData"></param>
    /// <param name="Encode"></param>
    /// <returns></returns>
    public static string GetEncodeString(this byte[] BlockData,string Encode="shift-jis")
    {
        BlockData = BlockData.Select(x => x.isBetween((byte)0xFD, (byte)0xFF) ? (byte)0x00 : x).ToArray();
        //BlockData = BlockData.Select(x => ( x.isBetween((byte)0x72, (byte)0xAE) || x > 0xDF )? (byte)0x3F : x).ToArray();
        return new string(Encoding.GetEncoding(Encode, new EncoderReplacementFallback("･"),
               DecoderFallback.ReplacementFallback).GetString(BlockData).
               Select(c => char.IsControl(c)? '･' : c).ToArray());
    }
    public static T GetCheckedControl<T>(this Control ctrl)
    {
        return ctrl.Controls.OfType<T>().FirstOrDefault(x => ((dynamic)x).Checked);
    }
}
