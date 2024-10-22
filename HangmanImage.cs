namespace Hangman
{
    public class HangmanImage
    {
        private readonly string[] _image;

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

        public void Update(int remainingAttempts)
        {
            switch (remainingAttempts)
            {
                case 5:
                    _image[2] = " |      (_) ";
                    break;
                case 4:
                    _image[3] = " |       |  ";
                    _image[4] = " |       |  ";
                    break;
                case 3:
                    _image[3] = " |      \\|  ";
                    break;
                case 2:
                    _image[3] = " |      \\|/ ";
                    break;
                case 1:
                    _image[5] = " |      /   ";
                    break;
                case 0:
                    _image[5] = " |      / \\ ";
                    break;
            }
        }
    }
}