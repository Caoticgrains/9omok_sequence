

namespace Common
{


    public class Constants
    {
        public enum ModeType
        {
            SinglePlay,
            MultiPlay
        }

        public enum TurnType
        {
            None,
            Player1,
            Player2
        }

        public enum SerialIndex
        {
            LT = 0,
            RT = 7,
            LB = 56,
            RB = 63
        }

        public enum SerialCard
        {
            Unicorn = 18,
            Dragon = 19
        }

        public const int cardMaxCountOnPlayerHand = 7;
        public const int pieceMaxCountOnPlayerHand = 40;

    }
}