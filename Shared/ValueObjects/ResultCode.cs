namespace Shared.ValueObjects;

public enum ResultCode
{
    Success,
    CandidateNotFound,
    VoterNotFound,
    VoterCantVote,
    VoterAlreadyVoted,
    DataMismatch,
}