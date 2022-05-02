using CSharpStudyNetFramework.Helpers;
using MetroFramework.Forms;

namespace CSharpStudyNetFramework.Forms
{
    public partial class Form_Data : MetroForm
    {
        public Form_Data()
        {
            this.InitializeComponent();
        }

        private void Form_Data_Load(object sender, System.EventArgs e)
        {
            this.Grid_Data.DataSource = DatabaseHelper.db_context.authors;
        }
    }
}
