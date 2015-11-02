using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Dafny15Puzzle
{
    public partial class Form1 : Form
    {
        private readonly int[] _bordersNums = { 0, 4, 8, 12, 3, 7, 11, 15 };
        private int MoveablePTFlag, TurnCounter;
        OpenFileDialog openFileDialog = null;
        Image image;
        PictureBox picBoxWhole = null;
        PictureBox[] picBoxes = null;
        PuzzleTile[] PT = null;
        const int BOX_NUM = 16;
        private Game game;
        Boolean Solved= true;


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void NewGame()
        {
            BigInteger[] initArray = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            game = new Game();
            game.Init(initArray);
            game.BoardSolved(out Solved);
            isSolved(Solved);

        }

        private void Scramble()
        {

        }

        void TimerTick(object sender, EventArgs e)
        {
            
        }
        /*
         * Vertauscht das Bild einer PicBox mit dem Bild der MoveAble PicBox 
         */
        void SwapBoxes(int BoxNumber)
        {   PuzzleTile dummy = PT[BoxNumber];
            BigInteger FlagDummy = MoveablePTFlag;

            game.CanMove((BigInteger)BoxNumber, out FlagDummy);
            if (FlagDummy == 16)
            {
                labelStatus.Text = "Ungültiger Zug";
                return;
            }
            game.MoveItem(BoxNumber,MoveablePTFlag);
            PT[BoxNumber] = PT[MoveablePTFlag];
            picBoxes[BoxNumber].Image = PT[BoxNumber].PuzzleTileImage;

            PT[MoveablePTFlag] = dummy;
            picBoxes[MoveablePTFlag].Image = dummy.PuzzleTileImage;
            MoveablePTFlag = BoxNumber;
            TurnCounter++;
            TurnCounterUpdate();

            game.BoardSolved(out Solved);
            isSolved(Solved);
        }

        private void isSolved(bool Solved)
        {   
            if (Solved)
            {
                labelStatus.Text = "Solved";
            }
            else labelStatus.Text = "Unsolved";
        }
        /*
         * Click event auf eine PicBox
         */
        void picBoxes_click(object sender, EventArgs e)
        {
            PictureBox dummy = (PictureBox)sender;
            SwapBoxes(Array.IndexOf(picBoxes, dummy));


         }


        void TurnCounterUpdate()
        {
            TurnCounterLabel.Text = TurnCounter.ToString();
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
                textboxImagePath.Text = openFileDialog.FileName;
                if (picBoxWhole == null)
                {
                    picBoxWhole = new PictureBox();
                    picBoxWhole.Height  =   PuzzleBox.Height;
                    picBoxWhole.Width   =   PuzzleBox.Width;
                    PuzzleBox.Controls.Add(picBoxWhole);
                }


                splitImagesToPicBoxes();
                MoveablePTFlag = 15;
                clearBox(picBoxes[15]);
                TurnCounter = 0;
                TurnCounterUpdate();
                NewGame();
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
                PT = new PuzzleTile[BOX_NUM];
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
                    picBoxes[i].Click += new EventHandler(picBoxes_click);
                }
                    
                picBoxes[i].Width = unitX;
                picBoxes[i].Height = unitY;

                PT[i] = new PuzzleTile();
                PT[i].ID= i;
                PT[i].PuzzleTileImage = CreateBitmapImage(image,i, numRow, numCol, unitX, unitY);
                picBoxes[i].Image = PT[i].PuzzleTileImage;
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
