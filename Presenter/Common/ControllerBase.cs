using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class ControllerBase
    {
        public BackgroundWorker backgroundWorker;

        public ControllerBase()
        {
            //Initialize BackgroundWorker for running parallel thread
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += UpdateAsync;
            backgroundWorker.RunWorkerAsync();
        }

        public abstract void Update();

        private void UpdateAsync(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!backgroundWorker.CancellationPending)
                {
                    Update();
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
