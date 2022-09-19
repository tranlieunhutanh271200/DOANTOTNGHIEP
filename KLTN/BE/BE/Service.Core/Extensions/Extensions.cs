using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Extensions
{
    public static class Extensions
    {
        public static string GenerateUsername(this string str, string id = "")
        {
            var temp = string.Concat(str.Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
            var splitted = temp.Split(" ");
            StringBuilder t = new StringBuilder();
            t.Append(splitted[splitted.Count() - 1].ToLower());
            for (int i = 0; i < splitted.Count() - 2; i++)
            {
                t.Append(char.ToLower(splitted[i][0]));
            }
            if (!string.IsNullOrEmpty(id))
            {
                t.Append(id);
            }
            return t.ToString();
        }
        ///<summary>
        ///<para>Đọc file từ excel chỉ nhận các file *.csv hoặc *.xlsx</para>
        ///</summary>
        public static async Task<DataSet> ReadExcel(this IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    return result;
                }
            }
        }
        public static bool IsDisposed(this DbContext context)
        {
            var result = true;

            var typeDbContext = typeof(DbContext);
            var typeInternalContext = typeDbContext.Assembly.GetType("Microsoft.EntityFrameworkCore.Internal.DbContextLease");

            var fi_InternalContext = typeDbContext.GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance);
            var pi_IsDisposed = typeInternalContext.GetProperty("_disposed");

            var ic = fi_InternalContext.GetValue(context);

            if (ic != null)
            {
                result = (bool)pi_IsDisposed.GetValue(ic);
            }

            return result;
        }
    }
}
