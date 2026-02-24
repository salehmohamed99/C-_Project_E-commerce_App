using Application.DTOs.OrderDTOs;
using Application.DTOs.OrderProductDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Presentation.Forms;
using System.Windows.Forms;

namespace Presentation
{
    static class Program
    {
        [STAThread]
        static async Task Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginForm());


            
        }
    }
}
