using System;
namespace Design_Patterns.Behavioral.Mediator
{

	/*
	 It encourage loose coupling by keeping objects from referring to each other
	explicitly and allows them to communicate through a mediator object
	Auction, Airline Traffic Management,Chat App
	colleagues...
	Mediator..
	This looks similar to observer and Proxy pattern
	but observer:any change in observable it notify all;intent is diff;
	Proxy:
	 */

	public interface IColleague
	{
		void PlaceBid(int bidAmount);
		void ReceiveBidNotification(int bidAmount);
		string GetName();
	}

    public class Bidder : IColleague
    {
		string name;
		AuctionMediator auctionMediator;
		public Bidder(string name, AuctionMediator auctionMediator)
		{
			this.auctionMediator = auctionMediator;
			this.auctionMediator.AddBidder(this);
		}

        public void PlaceBid(int bidAmount)
        {
			auctionMediator.PlaceBid(this, bidAmount);
        }

        public string GetName()
        {
			return name;
        }



        public void ReceiveBidNotification(int bidAmount)
        {
			Console.WriteLine($"Bidder: {name} got the notfication that someone has put bid of: {bidAmount}");
            
        }
    }

	public interface IAuctionMediator
	{
		void AddBidder(IColleague bidder);
		void PlaceBid(IColleague bidder, int bidAmount);
	}

	public class AuctionMediator : IAuctionMediator
    {
		List<IColleague> colleagues = new List<IColleague>();
		public AuctionMediator()
		{

		}

        public void AddBidder(IColleague bidder)

        {
			this.colleagues.Add(bidder);
        }

        public void PlaceBid(IColleague bidder, int bidAmount)
        {
            foreach(var colleague in colleagues)
			{
				if (colleague.GetName() != bidder.GetName())
				{
					bidder.ReceiveBidNotification(bidAmount);
				}
			}
        }
    }



}

 