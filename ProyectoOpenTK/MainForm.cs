using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProyectoOpenTK.GameLogic;
using ProyectoOpenTK.Utils;
using System.IO;
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
            return FileHelper.loadFromJson("./Resources/initial_state.json");
        }

        private static Stage LoadFromJsonString(string fileContent)
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
            juego.stage = LoadFromJsonString(fileContent);
            juego.stage.objects["bird"].resize(-0.05f, -0.05f, -0.05f);
            juego.stage.objects["bird"].rotate(-50,-1, 0, 0);
            juego.stage.objects["bird"].rotate(90,0, 0, -1);
            juego.stage.objects["bird"].moveTo(-10, 10, 0);
            
            juego.stage.objects["car"].rotate(90,0, 1,0 );
            juego.stage.objects["car"].moveTo(5, 0, 0);

            juego.moveTo(7, 0 , 0);
            generateCheckBoxes(juego.stage);

            juego.Run(60);
        }

        private void generateCheckBoxes(Stage stage)
        {
            treeView1.Nodes.Clear();

            TreeNode parent = new TreeNode();
            parent.Text = "Escenario";
            parent.Checked = true;


            foreach (var objectx in stage.objects)
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


            treeView1.CheckBoxes = true;
            treeView1.ExpandAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Game juego = new Game(800, 600, "Demo OpenTK");
            // juego.stage = LoadFromJson();
            // // juego.stage = LoadStage();
            //  // FileHelper.mapToJson(juego.stage);
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
                // string jsonString = JsonConvert.SerializeObject(juego.stage, Formatting.Indented);
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
                var stage = juego.stage;
                Console.WriteLine(node.Text);

                foreach (TreeNode nodeObject in node.Nodes)
                {
                    var objectX = stage.objects[nodeObject.Text];

                    Console.WriteLine("     " + nodeObject.Text);

                    foreach (TreeNode nodePart in nodeObject.Nodes)
                    {
                        var part = objectX.parts[nodePart.Text];
                        // part.selected = nodePart.Checked;

                        Console.WriteLine("     " + "     " + nodePart.Text);
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

            this.ejecutor = new Ejecutor(libreto, juego.generateObjectsDetailFromStages());

            MessageBox.Show("El archivo ha sido cargado correctamente.", "Confirmación", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void PlayLibreto_Click(object sender, EventArgs e)
        {
            this.ejecutor.Play();
        }
    }
}