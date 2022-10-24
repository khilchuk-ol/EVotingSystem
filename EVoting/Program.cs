using Client.Mappers;
using Client.Services;
using Core.Database;
using Core.Mappers;
using Core.Services;
using Shared.Encryption;

namespace EVoting
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(MainForm());
        }

        private static Form MainForm()
        {
            var keyGenerator = new HardcodedPrimesKeyGenerator();
            var serverRsaEncryptionService = new DefaultRsaEncryptionService(keyGenerator);
            var database = new HardcodedDatabase();
            var candidateEntityToModelMapper = new CandidateEntityToModelMapper();
            var stringToBulletinModelMapper = new StringToBulletinModelMapper();
            var serverVotingService = new DefaultServerVotingService(serverRsaEncryptionService, 
                database, candidateEntityToModelMapper, stringToBulletinModelMapper);

            var bulletinModelToStringMapper = new BulletinModelToStringMapper();
            var clientRsaEncryptionService = new DefaultRsaEncryptionService(keyGenerator);
            var clientVotingService = new DefaultClientVotingService(serverVotingService,
                bulletinModelToStringMapper, clientRsaEncryptionService);

            var mainForm = new FormMain(clientVotingService);
            return mainForm;
        }
    }
}