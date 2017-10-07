using finQuick.Secrets;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.UpdateRequest;

namespace finQuick
{
    class Program
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Test Monies Sheet";

        static void Main(string[] args)
        {
            #region Google Stuffs
            UserCredential credential;

            string secretsFilePath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\Secrets\client_secret.json");

            using (var stream =
                new FileStream(secretsFilePath, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);


                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            #endregion


            String spreadsheetId = HereBeDragons.SpreadsheetId;
            String range = "Test!B1";
            ValueRange valueRange = new ValueRange
            {
                MajorDimension = "COLUMNS"//"ROWS";//COLUMNS
            };

            var oblist = new List<object>() { "My Cell Text" };//the stuff to write goes here

            valueRange.Values = new List<IList<object>> { oblist };

            SpreadsheetsResource.ValuesResource.UpdateRequest update =
                service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);

            update.ValueInputOption = ValueInputOptionEnum.RAW;
            update.Execute();
        }
    }
}