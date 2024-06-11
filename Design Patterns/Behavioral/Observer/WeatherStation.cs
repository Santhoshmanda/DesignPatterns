using System;
namespace Design_Patterns.Behavioral.Observer
{
	//public class NotifyMe
	//{
	//	public NotifyMe()
	//	{
	//	}
	//}

    //weather station
    //stock price change

    /*
	 Observable -> state changes to state1 state2..
	updates to all observers who subscribe to this
	add(regsiter,subscribe),remove(unsubscribe),notify, setdata
	 Observer -> can be multiple
	 update
	 */

    interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }


    interface IObserver
    {
        void Update(float price);
    }

    class StockMarket : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string stockName;
        private float price;

        public StockMarket(string name, float initialPrice)
        {
            stockName = name;
            price = initialPrice;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(price);
            }
        }

        // Simulate price change
        public void PriceChanged(float newPrice)
        {
            price = newPrice;
            NotifyObservers();
        }
    }

    // Concrete Observer
    class StockObserver : IObserver
    {
        private string observerName;

        public StockObserver(string name)
        {
            observerName = name;
        }

        public void Update(float price)
        {
            Console.WriteLine($"Observer {observerName} - Price updated: {price}");
        }
    }

    /*
     * 
     * import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockMarketService {
  private priceUpdatesSubject = new Subject<{ stockName: string, price: number }>();

  constructor() { }

  // Method to simulate price changes
  simulatePriceChange(stockName: string, newPrice: number) {
    this.priceUpdatesSubject.next({ stockName, price: newPrice });
  }

  // Method to get observable for price updates
  getPriceUpdates(): Observable<{ stockName: string, price: number }> {
    return this.priceUpdatesSubject.asObservable();
  }
}
    import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { StockMarketService } from './stock-market.service';

@Component({
  selector: 'app-stock',
  template: `
    <div>
      {{ stockName }}: {{ price }}
    </div>
  `
})
export class StockComponent implements OnInit, OnDestroy {
  stockName: string;
  price: number;
  private subscription: Subscription;

  constructor(private stockMarketService: StockMarketService) {
    this.stockName = 'ABC'; // Initialize with default stock
    this.price = 100; // Initialize with default price
  }

  ngOnInit() {
    this.subscription = this.stockMarketService.getPriceUpdates()
      .subscribe(({ stockName, price }) => {
        if (stockName === this.stockName) {
          this.price = price;
        }
      });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}

     
    */



    class ProgramTest
    {
        static void Maintest(string[] args)
        {
            // Create subject
            var stockMarket = new StockMarket("ABC", 100);

            // Create observers
            var user1 = new StockObserver("User1");
            var user2 = new StockObserver("User2");

            // Register observers
            stockMarket.RegisterObserver(user1);
            stockMarket.RegisterObserver(user2);

            // Simulate price change
            stockMarket.PriceChanged(110);
            stockMarket.PriceChanged(105);

            // Remove an observer
            stockMarket.RemoveObserver(user1);

            // Simulate price change
            stockMarket.PriceChanged(95);

            Console.ReadLine();
        }
    }




}

