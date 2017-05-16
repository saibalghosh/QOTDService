using System;
using QOTDService.Helpers;
using System.Data;
using System.Net;

namespace QOTDService
{
    public class RandomQuotation : IRandomQuotation
    {
        DataTable dtQuotations;
        string[,] listOfQuotations;

        string[][] IRandomQuotation.GetRandomQuotation()
        {
            return ArrayConverter.ToJaggedArray<string>(RetrieveRandomQuotation());
        }

        private string[,] RetrieveRandomQuotation()
        {
            try
            {
                DatabaseManager dbManager = new DatabaseManager();
                dtQuotations = dbManager.ExecuteSelectQueryByProcedureName("GetRandomQuotation", null);

                if (dtQuotations != null)
                {
                    listOfQuotations = new string[dtQuotations.Rows.Count, 3];

                    for (int i = 0; i < dtQuotations.Rows.Count; i++)
                    {
                        listOfQuotations[i, 0] = (String)(dtQuotations.Rows[i]).ItemArray[0];
                        listOfQuotations[i, 1] = (String)(dtQuotations.Rows[i]).ItemArray[1];
                        listOfQuotations[i, 2] = (String)(dtQuotations.Rows[i]).ItemArray[2];
                    }
                }

                else
                {
                    throw new Exception("Error retrieving data from the database.");
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }

            return listOfQuotations;
        }
    }
}