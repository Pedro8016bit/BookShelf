using System.Runtime.InteropServices;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing;
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BookShelf
{
    public partial class Tela_princpal : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        public Tela_princpal()
        {
            InitializeComponent();
            timer.Interval = 3000; 
            timer.Tick += timer_Tick;
            timer.Start(); 
        }
        private void PanelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Tela_Cadastro meuUc1 = new Tela_Cadastro();
            Tela_Login meuUc2 = new Tela_Login();
            Usuarios usuario = new Usuarios();

            bool tem = usuario.Verificar_se_User_existe();

            if (tem)
            {
                CarregarUser(meuUc2);
                timer.Stop();
            }
            else
            {
                CarregarUser(meuUc1);
                timer.Stop();
            }
        }

        public void CarregarUser(UserControl uc)
        {
            panel_principal.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel_principal.Controls.Add(uc);
        }
    }
}
