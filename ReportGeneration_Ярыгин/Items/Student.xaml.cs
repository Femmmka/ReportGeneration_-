using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReportGeneration_Ярыгин.Classes;
using ReportGeneration_Ярыгин.Pages;

namespace ReportGeneration_Ярыгин.Items
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : UserControl
    {
        private StudentContext student;
        private Main main;

        public Student()
        {
            InitializeComponent();
        }

        public Student(StudentContext student, Main main)
        {
            this.student = student;
            this.main = main;
        }
    }
}
