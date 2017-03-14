using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Task2Form : Form
    {
        public Task2Form()
        {
            InitializeComponent();
            treeView.HideSelection = false;
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonRename.Enabled = false;
        }

        public void UpdateTree()
        {
            treeView.BeginUpdate();
            treeView.Nodes.Add("Модель");
            for (int i = 0; i < Program.Model.Count; i++)
            {
                treeView.Nodes[0].Nodes.Add(Program.Model[i].Name);
                for (int j = 0; j < Program.Model[i].Files.Count; j++)
                {
                    treeView.Nodes[0].Nodes[i].Nodes.Add(Program.Model[i].Files[j].Name);
                    for (int k = 0; k < Program.Model[i].Files[j].Classes.Count; k++)
                    {
                        treeView.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(Program.Model[i].Files[j].Classes[k].Name);
                    }
                }
            }
            treeView.EndUpdate();
        }

        public void Delete()
        {
            treeView.Nodes.Remove(treeView.SelectedNode);
        }

        public void Rename()
        {
            treeView.SelectedNode.Text = textBoxName.Text;
        }

        public void Add()
        {
            treeView.SelectedNode.Nodes.Add(textBoxName.Text);
        }
        public void FillModel(int p)
        {

            List<File> files;
            List<Class> classes;
            Program.Model = new List<Project>();

            for (int i = 0; i < p; i++)
            {
                files = new List<File>();
                for (int j = 0; j < p; j++)
                {
                    classes = new List<Class>();
                    for (int k = 0; k < p; k++)
                    {
                        classes.Add(new Class("Класс " + k));
                    }
                    files.Add(new File("Файл " + j, classes));
                }
                Program.Model.Add(new Project("Проект " + i, files));
            }

            UpdateTree();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
                Add();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void buttonFillModel_Click(object sender, EventArgs e)
        {
            int p = -1;
            int.TryParse(textBoxCount.Text, out p);
            if (p>0)
            {
                treeView.Nodes.Clear();
                FillModel(p);
            }

        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonAdd.Enabled = true;
            buttonDelete.Enabled = true;
            buttonRename.Enabled = true;

        }
    }
}
