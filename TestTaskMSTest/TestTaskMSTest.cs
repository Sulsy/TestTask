using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTaskModel;

namespace TestTaskMSTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void CreateNewPlayer()
        {
            //arange
            var namePlayer = "Oleg";
            //act
            System.IO.File.Delete(Player.Path);
            var player = new Player(namePlayer);
            //assert   
            Assert.AreEqual(player.NamePlayer,namePlayer);
        }
        [TestMethod]
        public void LoadPlayer()
        {
            System.IO.File.Delete(Player.Path);
            //arange
            var namePlayer = "Oleg";
            var player = new Player(namePlayer);
            Player.Instance = player;
            //act
            Player.SaveData();
            player=Player.LoadData();
            //assert   
            Assert.AreEqual(player.NamePlayer, namePlayer);
            System.IO.File.Delete(Player.Path);
        }
        [TestMethod]
        public void PlayerProgress()
        {
            //arange
            string namePlayer = "Oleg";
            var player = new Player(namePlayer);
            Player.Instance = player;
            //act
            Player.Instance.SetDeck("0");
            Player.Instance.DeckPlayer[0].SetCard(0,"1","1");
            Player.Instance.DeckPlayer[0].DeckCard[0].IsCardLearned();
            //assert   
            Assert.AreEqual(Player.Progress, 1);
            System.IO.File.Delete(Player.Path);
        }
    }
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void CreateDeck()
        {
            //arange
            const string deckName = "0";
            CreatePlayer();
            //act
            Player.Instance.SetDeck(deckName);
            //assert   
            Assert.AreEqual(Player.Instance.DeckPlayer[0].DeckName, deckName);
        }
        private static void CreatePlayer()
        {
            var player = new Player("Oleg");
            Player.Instance = player;
        }
    }
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CreateCard()
        {
            //arange
            const string deckName = "0", cardName = "1";
            CreatePlayer();
            //act
            Player.Instance.SetDeck(deckName);
            Player.Instance.DeckPlayer[0].SetCard(1, cardName, cardName);
            //assert   
            Assert.AreEqual(Player.Instance.DeckPlayer[0].DeckCard[0].BackText, cardName);
        }
        private static void CreatePlayer()
        {
            var player = new Player("Oleg");
            Player.Instance = player;
        }
    }
}
