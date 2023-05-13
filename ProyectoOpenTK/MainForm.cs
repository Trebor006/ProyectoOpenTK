using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using ProyectoOpenTK.GameLogic;
using Newtonsoft.Json;
using OpenTK;
using ProyectoOpenTK.Utils;
using System;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Pipes;
using static System.Windows.Forms.AxHost;
using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Input;
using ProyectoOpenTK.AnimationLogic;


namespace ProyectoOpenTK
{
    public partial class MainForm : Form
    {
        private Game juego;
        private Ejecutor ejecutor;


        public MainForm()
        {
            InitializeComponent();
        }

        private static Dictionary<string, Stage> LoadFromJson()
        {
            return FileHelper.loadFromJson("./Resources/archivito.json");
        }

        private static Dictionary<string, Stage> LoadFromJsonString(string fileContent)
        {
            return FileHelper.loadFromJsonString(fileContent);
        }

        private void FileSelectorButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "json files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog1.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

            //Console.WriteLine(fileContent);

            juego = new Game(800, 600, "Demo OpenTK");
            juego.stages = LoadFromJsonString(fileContent);

            generateCheckBoxes(juego.stages);

            juego.Run(60);
        }

        private void generateCheckBoxes(Dictionary<string, Stage> stages)
        {
            treeView1.Nodes.Clear();


            foreach (var stage in stages)
            {
                TreeNode parent = new TreeNode();
                parent.Text = stage.Key;
                parent.Checked = true;


                foreach (var objectx in stage.Value.objects)
                {
                    TreeNode child = new TreeNode();
                    child.Text = objectx.Key;


                    foreach (var part in objectx.Value.parts)
                    {
                        TreeNode childNewLevel = new TreeNode();
                        childNewLevel.Text = part.Key;


                        child.Nodes.Add(childNewLevel);
                    }

                    parent.Nodes.Add(child);
                }

                treeView1.Nodes.Add(parent);
            }


            treeView1.CheckBoxes = true;
            treeView1.ExpandAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Game juego = new Game(800, 600, "Demo OpenTK");
            // juego.stages = LoadFromJson();
            // // juego.stages = LoadStage();
            //  // FileHelper.mapToJson(juego.stages);
            //  juego.Run(60);
        }

        private void SaveState_Click(object sender, EventArgs e)
        {
            /* SaveFileDialog saveFileDialog1 = new SaveFileDialog();
             saveFileDialog1.InitialDirectory = @"D:\";
             saveFileDialog1.Title = "Save Json Files";
             saveFileDialog1.CheckFileExists = true;
             saveFileDialog1.CheckPathExists = true;
             saveFileDialog1.DefaultExt = "json";
             saveFileDialog1.Filter = "Json files (*.json)|*.json";
             saveFileDialog1.FilterIndex = 2;
             saveFileDialog1.RestoreDirectory = true;
             if (saveFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 //textBox1.Text = saveFileDialog1.FileName;
                // string jsonString = JsonConvert.SerializeObject(juego.stages, Formatting.Indented);
 //                File.WriteAllText(saveFileDialog1.FileName, jsonString);
             }
            */


            //SaveFileDialog dialogoGuardar = new SaveFileDialog();
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            float x = 0;
            float y = 0;
            float z = 0;


            juego.moveTo(x, y, z);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                CheckAllSubNodes(e.Node, e.Node.Checked);
            }

            updateAllSelectedStatus();
        }

        private void updateAllSelectedStatus()
        {
            Console.WriteLine("");
            Console.WriteLine("");

            foreach (TreeNode node in treeView1.Nodes)
            {
                var stage = juego.stages[node.Text];
                stage.selected = node.Checked;
                Console.WriteLine(node.Text + " :: " + stage.selected);

                foreach (TreeNode nodeObject in node.Nodes)
                {
                    var objectX = stage.objects[nodeObject.Text];
                    objectX.selected = nodeObject.Checked;

                    Console.WriteLine("     " + nodeObject.Text + " :: " + objectX.selected);

                    foreach (TreeNode nodePart in nodeObject.Nodes)
                    {
                        var part = objectX.parts[nodePart.Text];
                        part.selected = nodePart.Checked;

                        Console.WriteLine("     " + "     " + nodePart.Text + " :: " + part.selected);
                    }
                }
            }
        }

        private void CheckAllSubNodes(TreeNode nodex, bool isChecked)
        {
            //// Check/uncheck the current node
            //node.Checked = isChecked;

            //// Check/uncheck all child nodes
            //foreach (TreeNode childNode in node.Nodes)
            //{
            //    CheckAllSubNodes(childNode, isChecked);
            //}

            foreach (TreeNode node in nodex.Nodes)
            {
                node.Checked = isChecked;
                CheckAllSubNodes(node, isChecked);
            }

            if (nodex.Parent != null)
            {
                bool allChecked = true;
                foreach (TreeNode node in nodex.Parent.Nodes)
                {
                    if (!node.Checked)
                    {
                        allChecked = false;
                        break;
                    }
                }

                nodex.Parent.Checked = allChecked;
            }
        }

        private void degressValueNum_ValueChanged(object sender, EventArgs e)
        {
            juego.degreesValue = (int)degressValueNum.Value;
        }

        private void movementValNum_ValueChanged(object sender, EventArgs e)
        {
            juego.movementValue = (int)movementValNum.Value;
        }

        private void incDecValNum_ValueChanged(object sender, EventArgs e)
        {
            juego.increaseValue = (int)incDecValNum.Value;
        }

        private void selectLibreto_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Seleccione Libreto",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "json files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog1.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }


            var libreto = FileHelper.loadLibreto(fileContent);

            this.ejecutor = new Ejecutor(libreto);
            
            MessageBox.Show("El archivo ha sido cargado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void PlayLibreto_Click(object sender, EventArgs e)
        {
            this.ejecutor.Play(this.juego);
        }
    }
}