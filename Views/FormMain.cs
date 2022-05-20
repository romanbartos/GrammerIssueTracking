using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrammerIssueTracking.Repositories;

namespace GrammerIssueTracking.Views
{
    public partial class FormMain : Form
    {
        private readonly ILogger<FormMain> logger;
        private readonly IssueRepository issueRepository;
        private readonly KnihaRepository knihaRepository;
        private readonly FormAdmin formAdmin;

        public FormMain(ILogger<FormMain> logger, FormAdmin formAdmin, IssueRepository issueRepository, KnihaRepository knihaRepository)
        {
            // logger
            this.logger = logger;
            this.issueRepository = issueRepository;
            this.knihaRepository = knihaRepository;

            // Forms
            this.formAdmin = formAdmin;

            InitializeComponent();
        }

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            logger.LogInformation("Creating new Admin window");
            this.formAdmin.ShowDialog();
        }
    }
}
