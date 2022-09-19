using System.Data;
using System.Data.Common;

namespace Service.Core.DB
{
    public interface IDbProvider
    {
        DbConnection CreateConnection(string connectionString);
        DbParameter AddParameter(string parameterName, object value, ParameterDirection direction);
        DbParameter DeleteParameter(string parameterName);
        DbParameter ClearParameters();
        DataSet ExecuteDatasetSP(string storeProcedureName);
        DataTable ExecuteDatatableSP(string storeProcedureName);
    }
}
