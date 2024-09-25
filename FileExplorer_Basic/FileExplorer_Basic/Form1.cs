using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileExplorer_Basic
{
    public partial class Form1 : Form
    {
        private string currentPath;
        private List<string> itemsToCopy = new List<string>();
        private List<string> itemsToCut = new List<string>();
        private Stack<string> backStack = new Stack<string>();
        private Stack<string> forwardStack = new Stack<string>();
        private string clipboardPath;
        private bool isCutOperation = false;

        public Form1()
        {
            InitializeComponent();
            currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 
            pathtb.Text = currentPath;
            ShowTreeViewItems(currentPath); 
            ShowDirectoryItems(currentPath);
            listView1.MouseClick += listView1_MouseClick;
        }

        private void ShowTreeViewItems(string path)
        {
            
        }

        private void LoadSubDirectories(TreeNode node)
        {
            var directoryInfo = new DirectoryInfo(node.Tag.ToString());
            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var newNode = new TreeNode(directory.Name) { Tag = directory.FullName };
                    node.Nodes.Add(newNode);
                    LoadSubDirectories(newNode);
                }
            }
            catch (UnauthorizedAccessException) { }
        }


        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name) { Tag = directoryInfo.FullName };
            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }
            return directoryNode;
        }

        private void ShowDirectoryItems(string path)
        {
            
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
 
        }


        private void btnForward_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    backStack.Push(currentPath);
                    forwardStack.Clear();
                    currentPath = fbd.SelectedPath;
                    pathtb.Text = currentPath;
                    ShowDirectoryItems(currentPath);
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenuStrip();
                var copyItem = new ToolStripMenuItem("Copy");
                var cutItem = new ToolStripMenuItem("Cut");
                var pasteItem = new ToolStripMenuItem("Paste");
                var deleteItem = new ToolStripMenuItem("Delete");
                var newFolderItem = new ToolStripMenuItem("New Folder");

                copyItem.Click += (s, args) => CopySelectedItems();
                cutItem.Click += (s, args) => CutSelectedItems();
                pasteItem.Click += (s, args) => PasteItems();
                deleteItem.Click += (s, args) => DeleteSelectedItems();
                newFolderItem.Click += (s, args) => CreateNewFolder();

                contextMenu.Items.Add(copyItem);
                contextMenu.Items.Add(cutItem);
                contextMenu.Items.Add(pasteItem);
                contextMenu.Items.Add(deleteItem);
                contextMenu.Items.Add(newFolderItem);
                
                contextMenu.Show(listView1, e.Location);
            }
        }


        private void DeleteSelectedItems()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected items?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        string path = Path.Combine(currentPath, item.Text);
                        if (Directory.Exists(path))
                        {
                            Directory.Delete(path, true);
                        }
                        else if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                    ShowDirectoryItems(currentPath);
                }
            }
        }

        private void CreateNewFolder()
        {

        }
    
        private void CopySelectedItems()
        {

        }

        private void CutSelectedItems()
        {

        }
        private async void PasteItems()
        {
            if (itemsToCopy.Count == 0 && itemsToCut.Count == 0)
                return;

            string destinationPath = currentPath;

            foreach (var itemPath in itemsToCopy)
            {
                string destinationFilePath = Path.Combine(destinationPath, Path.GetFileName(itemPath));
                await CopyFileAsync(itemPath, destinationFilePath);
            }

            foreach (var itemPath in itemsToCut)
            {
                string destinationFilePath = Path.Combine(destinationPath, Path.GetFileName(itemPath));
                await CopyFileAsync(itemPath, destinationFilePath);
                File.Delete(itemPath); 
            }

            itemsToCopy.Clear();
            itemsToCut.Clear();
            ShowDirectoryItems(currentPath);
        }

        private async Task CopyFileAsync(string sourcePath, string destinationPath)
        {
            if (File.Exists(sourcePath))
            {
                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }
            }
            else if (Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(destinationPath);
                foreach (var file in Directory.GetFiles(sourcePath))
                {
                    string destFile = Path.Combine(destinationPath, Path.GetFileName(file));
                    await CopyFileAsync(file, destFile);
                }

                foreach (var directory in Directory.GetDirectories(sourcePath))
                {
                    string destDir = Path.Combine(destinationPath, Path.GetFileName(directory));
                    await CopyFileAsync(directory, destDir);
                }
            }
        }
    }

    }