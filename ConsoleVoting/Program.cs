using Client.Mappers;
using Client.Services;
using ConsoleVoting;
using Core.Database;
using Core.Mappers;
using Core.Services;
using Shared.RsaEncryption;

var keyGenerator = new HardcodedPrimesKeyGenerator();
var serverRsaEncryptionService = new DefaultRsaEncryptionService(keyGenerator);
var database = new HardcodedDatabase();
var candidateEntityToModelMapper = new CandidateEntityToModelMapper();
var stringToBulletinModelMapper = new StringToBulletinModelMapper();
var serverVotingService = new SimpleServerVotingService(serverRsaEncryptionService,
    database, candidateEntityToModelMapper, stringToBulletinModelMapper);

var bulletinModelToStringMapper = new BulletinModelToStringMapper();
var clientRsaEncryptionService = new DefaultRsaEncryptionService(keyGenerator);
var clientVotingService = new SimpleClientVotingService(serverVotingService,
    bulletinModelToStringMapper, clientRsaEncryptionService);

var terminal = new Terminal(clientVotingService);
await terminal.Loop();