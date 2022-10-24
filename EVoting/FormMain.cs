using Client.Services;
using Shared.Models;

namespace EVoting
{
    public partial class FormMain : Form
    {
        private readonly IClientVotingService votingService;

        public FormMain(IClientVotingService votingService)
        {
            InitializeComponent();

            this.votingService = votingService;
            listBoxCandidates.DataSource = votingService.GetAllCandidatesAsync().Result;
        }

        private async void buttonVote_Click(object sender, EventArgs e)
        {
            var date = dateTimePickerBirthDate.Value;
            BulletinModel bulletin = new()
            {
                GovernmentId = textBoxGovernmentId.Text,
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                BirthDate = DateOnly.FromDateTime(date),
                CandidateId = (listBoxCandidates.SelectedItem as CandidateModel)?.Id ?? 0
            };
            var voteTask = votingService.Vote(bulletin);
            MessageBox.Show("Vote sent.");
            await voteTask;
        }
    }
}