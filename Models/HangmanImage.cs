namespace Hangman.Models
{
    public class HangmanImage
    {
        private readonly List<string> _image;

        public string Image => string.Join("\n", _image);

        public HangmanImage()
        {
            _image = [
                "  _______   ",
                " |/      |  ",
                " |          ",
                " |          ",
                " |          ",
                " |          ",
                "_|___       "
            ];
        }

        private void DrawHead()
        {
            _image[2] = " |      (_) ";
        }

        private void DrawNeck()
        {
            _image[3] = " |       |  ";
            _image[4] = " |       |  ";
        }

        private void DrawFirstArm()
        {
            _image[3] = " |      \\|  ";
        }

        private void DrawSecondArm()
        {
            _image[3] = " |      \\|/ ";
        }

        private void DrawFirstLeg()
        {
            _image[5] = " |      /   ";
        }

        private void DrawSecondLeg()
        {
            _image[5] = " |      / \\ ";
        }

        public void Update(int remainingAttempts)
        {
            switch (remainingAttempts)
            {
                case 5:
                    DrawHead();
                    break;
                case 4:
                    DrawNeck();
                    break;
                case 3:
                    DrawFirstArm();
                    break;
                case 2:
                    DrawSecondArm();
                    break;
                case 1:
                    DrawFirstLeg();
                    break;
                case 0:
                    DrawSecondLeg();
                    break;
            }
        }
    }
}