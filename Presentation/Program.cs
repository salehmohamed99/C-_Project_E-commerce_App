using System.Windows.Forms;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Presentation.Forms;

namespace Presentation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new Mapper().Map();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginForm());
        }
    }
}
