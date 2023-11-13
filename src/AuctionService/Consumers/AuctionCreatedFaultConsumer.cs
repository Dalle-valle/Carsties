using MassTransit;
using Contracts;

namespace AuctionService;

public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>
{ 
    public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
    {
        Console.WriteLine("--> Consuming auction created fault");

        var exception = context.Message.Exceptions.First();   
        


        if (exception.ExceptionType == "System.ArgmuentException")
         {
             context.Message.Message.Model = "FooBar";
             await context.Publish(context.Message.Message);
         } else 

         {
            Console.WriteLine("Not an argument Exception - Update error dashboard somewhere");
         }

}
}
