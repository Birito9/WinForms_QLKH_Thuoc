using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace FormQLKH
{
    public partial class UC_Loading : UserControl
    {
        private Timer animationTimer = new Timer();
        private int animationIndex = 0;
        private string[] loadingAnimations = { ".", "..", "..." };
        public UC_Loading()
        {
            InitializeComponent();

            animationTimer.Interval = 500;
            animationTimer.Tick += AnimationTimer_Tick;

            animationTimer.Start();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            lbLoad.Text = "Xin vui lòng chờ trong giây lát " + loadingAnimations[animationIndex];

            animationIndex = (animationIndex + 1) % loadingAnimations.Length;
        }
    }
}
