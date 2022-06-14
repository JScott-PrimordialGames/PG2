using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackjackObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackClassLibrary;

namespace BlackjackObjects.Tests
{
    [TestClass()]
    public class BlackjackHandTests
    {
            [TestMethod()]
        public void AddCardTest()
        {
            //Add code here to unit test the AddCard method of the BlackjackHand class
            BlackjackHand hand = new BlackjackHand(false);
            BlackjackCard card = new BlackjackCard(CardFace._A, CardSuit.Spades);
            BlackjackCard card2 = new BlackjackCard(CardFace._8, CardSuit.Spades);
            BlackjackCard card3 = new BlackjackCard(CardFace._10, CardSuit.Spades);
            
            hand.AddCard(card);
            hand.AddCard(card2);
            hand.PrintHand(0, 2);
            
            hand.AddCard(card3);
            hand.PrintHand(0, 3);

            Console.ReadKey();
            Assert.Fail();
        }
    }
}