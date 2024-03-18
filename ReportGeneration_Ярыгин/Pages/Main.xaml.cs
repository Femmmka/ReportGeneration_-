using System.Collections.Generic;
using System.Windows.Controls;
using ReportGeneration_Ярыгин.Classes;

namespace ReportGeneration_Ярыгин.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public List<GroupContext> AllGroups = GroupContext.AllGroups();

        public List<StudentContext> AllStudents = StudentContext.AllStudent();

        public List<WorkContext> AllWorks = WorkContext.AllWorks();

        public List<EvaluationContext> AllEvaluations = EvaluationContext.AllEvaluations();

        public List<DisciplineContext> AllDisciplines = DisciplineContext.AllDisciplines();
        public Main()
        {
            InitializeComponent();
            CreateGroupUI();


        }
        public void CreateGroupUI()
        {
            foreach (GroupContext Group in AllGroups)
                CBGroups.Items.Add(Group.Name);

            CBGroups.Items.Add("Выберите");
            CBGroups.SelectedIndex = CBGroups.Items.Count - 1;
        }
        public void CreateStudents(List<StudentContext> AllStudents)
        {
            Parent.Children.Clear();
            foreach (StudentContext Student in AllStudents)
                Parent.Children.Add(new Items.Student(Student, this));
        }
        private void SelectGroup(object sender, SelectionChangedEventArgs e)
        {
            if (CBGroups.SelectedIndex != CBGroups.Items.Count - 1)
            {
                int IdGroup = AllGroups.Find(x => x.Name == CBGroups.SelectedItem).Id;
                CreateStudents(AllStudents.FindAll(x => x.IdGroup == IdGroup));
            }
        }
        private void SelectStudents(object sender, System.Windows.Input.KeyEventArgs e)
        {
            List<StudentContext> SearchStudent = AllStudents;
            if (CBGroups.SelectedIndex != CBGroups.Items.Count - 1)
            {
                int IdGroup = AllGroups.Find(x => x.Name == CBGroups.SelectedItem).Id;
                SearchStudent = AllStudents.FindAll(x => x.IdGroup == IdGroup);
            }
            CreateStudents(SearchStudent.FindAll(x => $"{x.Lastname} {x.Firstname}".Contains(TBFIO.Text)));
        }

        private void ReportGeneration(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CBGroups.SelectedIndex != CBGroups.Items.Count - 1)
            {

                int IdGroup = AllGroups.Find(x => x.Name == CBGroups.SelectedItem).Id;

                Classes.Common.Report.Group(IdGroup, this);
            }
        }
    }
}