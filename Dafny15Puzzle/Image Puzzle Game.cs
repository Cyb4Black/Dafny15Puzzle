using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dafny15Puzzle
{
    public partial class Form1 : Form
    {
        private readonly int[] _bordersNums = { 0, 4, 8, 12, 3, 7, 11, 15 };
        private int MoveableBox;
        OpenFileDialog openFileDialog = null;
        Image image;
        PictureBox picBoxWhole = null;
        PictureBox[] picBoxes = null;
        Image[] images = null;
        const int BOX_NUM = 16;



        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void NewGame()
        {   
        }

        void TimerTick(object sender, EventArgs e)
        {
            
        }
        /*
         * Vertauscht das Bild einer PicBox mit dem Bild der MoveAble PicBox 
         */
        void SwapBoxes(int BoxNumber)
        {   Image dummy = picBoxes[BoxNumber].Image;

            picBoxes[BoxNumber].Image = picBoxes[MoveableBox].Image;
            picBoxes[MoveableBox].Image = dummy;
            MoveableBox = BoxNumber;

        }

        void picBoxes_click(object sender, MouseEventArgs e)
        {
           
        }



        /*
         * Click-Event des ChooseImageButtons
         */
        private void buttonImageBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog == null)
                openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image = CreateBitmapImage(Image.FromFile(openFileDialog.FileName));

                if (picBoxWhole == null)
                {
                    picBoxWhole = new PictureBox();
                    picBoxWhole.Height  =   PuzzleBox.Height;
                    picBoxWhole.Width   =   PuzzleBox.Width;
                    PuzzleBox.Controls.Add(picBoxWhole);
                }


                splitImagesToPicBoxes();
                MoveableBox = 15;
                clearBox(picBoxes[15]);
    
            }
        }

        /*
         * Löscht das Image einer PicBox
         */
        private void clearBox(PictureBox pictureBox)
        {
            Graphics objGraphics = Graphics.FromImage(pictureBox.Image);
            objGraphics.Clear(Color.White); 
        }

   

        /*
         * Zerteilt das Bild in 16 PictureBoxen mit jeweils 16 Images
         */
        private void splitImagesToPicBoxes()
        {
            if (picBoxWhole != null)
            {
                PuzzleBox.Controls.Remove(picBoxWhole);
                picBoxWhole.Dispose();
                picBoxWhole = null;
            }
            if (picBoxes == null)
            {
                images = new Image[BOX_NUM];
                picBoxes = new PictureBox[BOX_NUM];
            }
            int numRow = 4;
            int numCol = 4;
            int unitX = PuzzleBox.Width / numRow;
            int unitY = PuzzleBox.Height / numCol;
            int[] indice = new int[BOX_NUM];
            for (int i = 0; i < BOX_NUM; i++)
            {
                indice[i] = i;
                if (picBoxes[i] == null)
                {
                    picBoxes[i] = new PictureBox();
                    picBoxes[i].BorderStyle = BorderStyle.Fixed3D;
                }
                    
                picBoxes[i].Width = unitX;
                picBoxes[i].Height = unitY;


                picBoxes[i].Image = CreateBitmapImage(image,i, numRow, numCol, unitX, unitY);
                picBoxes[i].Location = new Point(unitX * (i % numCol), unitY * (i / numCol));
                PuzzleBox.Controls.Add(picBoxes[i]);
            }

        }
        /*
         * Erzeugt eine skalierte Bitmap für die PicBoxWhole aus einem Image 
         */
        private Bitmap CreateBitmapImage(Image image)
        {
            Bitmap objBmpImage = new Bitmap(PuzzleBox.Width, PuzzleBox.Height);
            Graphics objGraphics = Graphics.FromImage(objBmpImage);
            objGraphics.Clear(Color.White);
            objGraphics.DrawImage(image, new Rectangle(0, 0, PuzzleBox.Width, PuzzleBox.Height));
            objGraphics.Flush();

            return objBmpImage;
        }
        /*
         * Erzeugt eine Skalierte Bitmap für die jeweiligen kleinen PicBoxen
         */
        private Bitmap CreateBitmapImage(Image image, int index, int numRow, int numCol, int unitX, int unitY)
        {
            Bitmap objBmpImage = new Bitmap(unitX, unitY);
            Graphics objGraphics = Graphics.FromImage(objBmpImage);
            objGraphics.Clear(Color.White);

            objGraphics.DrawImage(image, new Rectangle(0, 0, unitX, unitY), new Rectangle(unitX * (index % numCol), unitY * (index / numCol), unitX, unitY), GraphicsUnit.Pixel);
            objGraphics.Flush();

            return objBmpImage;
        }

        /*
         * Click-Event des RestartButtons
         */
        private void restart_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            SwapBoxes(rand.Next(15));
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       



    }
}
