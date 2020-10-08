using System;
using System.Data;

namespace TesteHubert.Repositories.Extensions
{
    public static class NotNullDataReader
    {
        public static T GetNotNullValue<T>(this IDataReader dataReader, string fieldName)
        {
            T valorRetorno;

            object valor = dataReader[fieldName];

            if (Convert.IsDBNull(valor))
            {
                if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    return default(T);
                }
                if (typeof(T) == typeof(string))
                    valorRetorno = (T)(object)"";
                else
                    valorRetorno = (T)typeof(T).Assembly.CreateInstance(typeof(T).FullName);
            }
            else
            {
                valorRetorno = (T)valor;
            }
            return valorRetorno;
        }
    }
}
