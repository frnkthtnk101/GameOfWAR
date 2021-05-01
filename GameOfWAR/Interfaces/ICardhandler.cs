namespace GameOfWAR.Interfaces
{
    public interface ICardhandler
    {
        void ShuffleCards();
        void Split(int numOfPlayers = 2);
        void GetPlayerDeck(int Player);
    }
}
